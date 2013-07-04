using System.Collections.Generic;

namespace JsonParsers
{
    public class JsonObjectType
    {
        private readonly string _name;
        private readonly bool _namedType;
        private readonly Dictionary<string, JsonObjectField> _fields = new Dictionary<string, JsonObjectField>();

        public JsonObjectType(string name, bool namedType )
        {
            _name = name;
            _namedType = namedType;
        }

        public string Name
        {
            get { return _name; }
        }

        public Dictionary<string,JsonObjectField> Fields
        {
            get { return _fields; }
        }

        public bool NamedType
        {
            get { return _namedType; }
        }

        public bool HasField(string fieldName)
        {
            return Fields.ContainsKey(fieldName);
        }
    }
}