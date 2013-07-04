namespace JsonParsers
{
    public class JsonObjectField
    {
        private string _typeName;

        public JsonObjectField(string typeName)
        {
            _typeName = typeName;
        }

        public string TypeName
        {
            get { return _typeName; }
        }

        public bool Compatible(string typeName)
        {
            if (TypeName == typeName) return true;

            if (TypeName == "double" && typeName == "double?") return true;
            if (TypeName == "bool" && typeName == "bool?") return true;
            if (TypeName == "double?" && typeName == "double") return true;
            if (TypeName == "bool?" && typeName == "bool") return true;
            if (TypeName == "double" && typeName == "null") return true;
            if (TypeName == "bool" && typeName == "null") return true;
            if (TypeName == "string" && typeName == "null") return true;
            if (TypeName == "null" && typeName == "double") return true;
            if (TypeName == "null" && typeName == "string") return true;
            if (TypeName == "null" && typeName == "bool") return true;

            return false;
        }

        public void MakeCompatible(string typeName)
        {
            if(TypeName==typeName ) return;

            if (TypeName == "null")
            {
                if (typeName == "string")
                {
                    _typeName = "string";
                    return;
                }
                if (typeName == "double" || typeName == "double?")
                {
                    _typeName = "double?";
                    return;
                }
                if (typeName == "bool" || typeName == "bool?")
                {
                    _typeName = "bool?";
                    return;
                }
            }

            if (TypeName == "string")
            {
                if( typeName=="null") return;
            }

            if (TypeName == "double")
            {
                if (typeName == "double?")
                {
                    _typeName = "double?";
                    return;
                }
                if (typeName == "null")
                {
                    _typeName = "double?";
                    return;
                }
            }

            if (TypeName == "bool")
            {
                if (typeName == "bool?")
                {
                    _typeName = "bool?";
                    return;
                }
                if (typeName == "null")
                {
                    _typeName = "bool?";
                    return;
                }
            }

        }
    }
}