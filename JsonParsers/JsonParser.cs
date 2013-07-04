using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParserCombinator;
using Lex = ParserCombinator.Parsers<char>;
namespace JsonParsers
{
    public class JsonParser
    {
        private readonly Parser<char, string> _idParser;
        private readonly Parser<char, Unit> _quote;
        private readonly Parser<char, char> _escapedChar;
        private readonly Parser<char, char> _charValue;
        private readonly Parser<char, JsonValue> _stringValue;
        private readonly Parser<char, JsonValue> _numericValue;
        private readonly Parser<char, JsonValue> _nullValue;
        private readonly Parser<char, JsonValue> _booleanValue;
        private readonly Parser<char, JsonValue> _valueParser;
        private readonly Parser<char, JsonField> _fieldParser;
        private readonly Parser<char, IList<JsonField>> _objectParser;
        private readonly Parser<char, IList<JsonValue>> _arrayParser;
        private static readonly Parser<char, IList<char>> _delimiterParser = Lex.Many(Lex.Generic(char.IsWhiteSpace));

        private static Parser<char, T> WithDelimiter<T>(Parser<char, T> itemParser)
        {
            return Lex.Map(_delimiterParser, itemParser, _delimiterParser,
                           (delimHead, arg2, delimTail) => arg2);
        }

        public JsonParser()
        {
            var colonParser = WithDelimiter( Lex.Is(':') );
            var commaParser = WithDelimiter( Lex.Is(',') );
            var openBraceParser = WithDelimiter(Lex.Is('{'));
            var closeBraceParser = WithDelimiter(Lex.Is('}'));
            var openBraketParser = WithDelimiter(Lex.Is('['));
            var closeBraketParser = WithDelimiter(Lex.Is(']'));

            _quote = Lex.Is('\"');
            var anycharExcludeQuote = Lex.Generic(ch => ch != '\"');
            _idParser = WithDelimiter( Lex.Map(
                _quote, Lex.Some(anycharExcludeQuote), _quote,
                (unit, c, arg3) => c.AsString()));
            _escapedChar = Lex.Map(
                Lex.Is('\\'), Lex.Generic(ch => true), (unit, c) => GetEscaped(c) );

            _charValue = Lex.Or(
                    _escapedChar, _=>_,
                    anycharExcludeQuote, _=>_
                );
            _stringValue = Lex.Map(
                    _quote,Lex.Many( _charValue ), _quote, (unit, list, arg3) => new StringValue(list.AsString()) as JsonValue
                );
            _numericValue = Lex.Map(
                Lex.Some(Lex.Generic(char.IsDigit)), c => new NumericValue(Double.Parse(c.AsString())) as JsonValue
                );
            _nullValue = Lex.Map(
                Lex.String("null"), unit => new NullValue() as JsonValue
                );
            _booleanValue = Lex.Map(
                Lex.Or( 
                    Lex.String("true"), _=> true,
                    Lex.String("false" ), _=> false ) , b=> new BoolValue(b) as JsonValue ) ;
            var arrayParser = Lex.Foward<IList<JsonValue>>();
            var objectParser = Lex.Foward<IList<JsonField>>();
            _objectParser = objectParser;

            _arrayParser = arrayParser;
            _valueParser = WithDelimiter( Lex.Or(
                    _stringValue, _=>_,
                    _numericValue, _=>_,
                    _booleanValue, _=>_,
                    _nullValue , _=>_,
                    _arrayParser, _ => new ArrayValue( _ ) as JsonValue,
                    _objectParser, _ => new ObjectValue( _ ) as JsonValue
                ) );
            _fieldParser = Lex.Map(
                _idParser, colonParser , _valueParser, (name,unit,value)=> new JsonField(name,value) );
            objectParser.FowardTo = Lex.Map(
                openBraceParser, Lex.Some(_fieldParser, commaParser ), closeBraceParser, (unit, list, arg3) => list
                );
            arrayParser.FowardTo = Lex.Map(
                openBraketParser, Lex.Many(_valueParser, commaParser), closeBraketParser, (unit, list, arg3) => list
                );
        }

        public JsonValue Parse(string jsonText)
        {
            JsonValue result;
            int endInput;
            if (_valueParser.Parse(new List<char>(jsonText), 0, out endInput, out result))
            {
                return result;
            }
            return null;
        }

        private char GetEscaped(char c)
        {
            if ('a' <= c && c <= 'z')
            {
                return (char) (c - 'a' + '\a');
            }
            return c;
        }
    }

    public class ObjectValue : JsonValue
    {
        private readonly IList<JsonField> _jsonFields;

        public ObjectValue(IList<JsonField> jsonFields)
        {
            _jsonFields = jsonFields;
        }

        public IList<JsonField> Fields
        {
            get { return _jsonFields; }
        }

        public IEnumerable<string>  FieldNames
        {
            get { return _jsonFields.Select(f => f.Name); }
        }

        public string[] FieldNameTypes
        {
            get { return _jsonFields.Select(f => f.Name +":"+ f.Value.TypeName).ToArray(); }
        }

        public JsonValue this[ string name ]
        {
            get { return _jsonFields.Single(f => f.Name==name).Value; }
        }

        public override string TypeName
        {
            get {
                var types = TypeRepository.GetTypeFromFieldNames(FieldNames);
                if (types.Count()==0 )
                {
                    var type = TypeRepository.CreateType(this);
                    return type.Name;
                }
                foreach (var type in types)
                {
                    bool isCompat = true;
                    foreach (var jsonField in Fields)
                    {
                        if (type.Fields[jsonField.Name].Compatible(jsonField.Value.TypeName)) continue;
                        isCompat = false;
                        break;
                    }
                    if (isCompat)
                    {
                        foreach (var jsonField in Fields)
                        {
                            type.Fields[jsonField.Name].MakeCompatible(jsonField.Value.TypeName);
                        }
                        return type.Name;
                    }
                }
                return TypeRepository.CreateType(this).Name;
            }
        }
    }

    public class ArrayValue : JsonValue
    {
        private readonly IList<JsonValue> _jsonValues;

        public ArrayValue(IList<JsonValue> jsonValues)
        {
            _jsonValues = jsonValues;
        }

        public IList<JsonValue> Values
        {
            get { return _jsonValues; }
        }

        public override string TypeName
        {
            get 
            {
                var valueTypeNames = _jsonValues.Select(v => v.TypeName).Distinct().ToList();
                if (valueTypeNames.Contains("null"))
                {
                    valueTypeNames.Remove("null");
                    if (valueTypeNames.Count() == 1)
                    {
                        return EnsureNullable(valueTypeNames.First()) + "[]";
                    }
                    return "object[]";
                }
                if (valueTypeNames.Count() == 1)
                {
                    return valueTypeNames.First() + "[]";
                }
                return "object[]";
            }
        }

        private string EnsureNullable(string typeName)
        {
            if (typeName == "bool") return "bool?";
            if (typeName == "double") return "double?";
            return typeName;
        }
    }

    public class BoolValue : JsonValue
    {
        private readonly bool _value;

        public BoolValue(bool value)
        {
            _value = value;
        }

        public bool Value
        {
            get { return _value; }
        }

        public override string TypeName
        {
            get { return "bool"; }
        }
    }

    public class JsonField
    {
        private readonly string _name;
        private readonly JsonValue _value;

        public JsonField(string name, JsonValue value)
        {
            _name = name;
            _value = value;
        }

        public string Name
        {
            get { return _name; }
        }

        public JsonValue Value
        {
            get { return _value; }
        }
    }

    public class NullValue : JsonValue
    {
        public override string TypeName
        {
            get { return "null"; }
        }
    }

    public class NumericValue : JsonValue
    {
        private readonly double _value;

        public NumericValue(double value)
        {
            _value = value;
        }

        public double Value
        {
            get { return _value; }
        }

        public override string TypeName
        {
            get { return "double"; }
        }
    }

    public class StringValue : JsonValue
    {
        private readonly string _value;

        public StringValue(string value)
        {
            _value = value;
        }

        public string Value
        {
            get { return _value; }
        }

        public override string TypeName
        {
            get { return "string"; }
        }
    }

    public abstract class JsonValue
    {
        public void MapValue<T>(Action<T> action) where T : JsonValue
        {
            if (this is T)
            {
                action(this as T);
            }
        }

        public TResult MapValue<T, TResult>(Func<T, TResult> func) where T : JsonValue
        {
            if (this is T)
            {
                return func(this as T);
            }
            return default(TResult);
        }

        public abstract string TypeName { get; }
    }

    internal static class Utilities
    {
        internal static string AsString(this IList<char> chars)
        {
            return new string(chars.ToArray());
        }
    }
}
