using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JsonParsers.Tests
{
    [TestClass]
    public class JsonParserTest
    {
        [TestMethod]
        public void BasicParserTest()
        {
            var parser = new JsonParser();
            var result = parser.Parse("[0,1,null,true,false]");
            result.IsInstanceOf<ArrayValue>();
            var array = result as ArrayValue;
            array.Values.Count.Is(5);
            array.Values[0].IsInstanceOf<NumericValue>();
            var num = array.Values[0] as NumericValue;
            num.Value.Is(0);
            array.Values[1].IsInstanceOf<NumericValue>();
            num = array.Values[1] as NumericValue;
            num.Value.Is(1);

            array.Values[2].IsInstanceOf<NullValue>();
            array.Values[3].IsInstanceOf<BoolValue>();
            var boolVal = array.Values[3] as BoolValue;
            boolVal.Value.IsTrue();
            boolVal = array.Values[4] as BoolValue;
            boolVal.Value.IsFalse();

            result = parser.Parse("{\"aa\":\"xx\"}");
            result.IsInstanceOf<ObjectValue>();
            var objValue = result as ObjectValue;
            objValue.Fields.Count.Is(1);
            objValue.Fields[0].Name.Is("aa");
            objValue.Fields[0].Value.IsInstanceOf<StringValue>();
            var strVal = objValue.Fields[0].Value as StringValue;
            strVal.Value.Is("xx");

            var fields = result.MapValue((ObjectValue o) => o.Fields);
            fields.IsNotNull();

            var type = TypeRepository.CreateTypeWithName("test", objValue);
            type.Name.Is("test");
            var field = type.Fields["aa"];
            field.IsNotNull();
            field.TypeName.Is("string");
        }

        [TestMethod]
        public void TypeRepositoryTest()
        {
            TypeRepository.Clear();

            var objValue = new ObjectValue(new List<JsonField>()
                {
                    new JsonField("aa", new NullValue()),
                    new JsonField("bb", new BoolValue(true)),
                    new JsonField("cc", new NumericValue(0))
                });
            var typ = TypeRepository.CreateType(objValue);
            typ.Fields["aa"].TypeName.Is("null");
            typ.Fields["bb"].TypeName.Is("bool");
            typ.Fields["cc"].TypeName.Is("double");
            objValue = new ObjectValue(new List<JsonField>()
                {
                    new JsonField("aa", new StringValue("test")),
                    new JsonField("bb", new NullValue()),
                    new JsonField("cc", new NumericValue(0))
                });
            var name = objValue.TypeName;
            name.Is(typ.Name);
            typ.Fields["aa"].TypeName.Is("string", "null -> string への昇格");
            typ.Fields["bb"].TypeName.Is("bool?", "bool -> bool? への昇格");
        }
    }
}
