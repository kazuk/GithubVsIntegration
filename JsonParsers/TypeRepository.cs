using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace JsonParsers
{
    public class TypeRepository
    {
        private static readonly List<JsonObjectType> _types = new List<JsonObjectType>();
        private static int _tempCount;

        public static void Clear()
        {
            _types.Clear();
            _tempCount = 0;
        }

        public static IEnumerable<JsonObjectType> NamedTypes()
        {
            return _types.Where(t => t.NamedType);
        }

        public static JsonObjectType GetType(string name)
        {
            return _types.SingleOrDefault(t => t.Name==name);
        }

        public static IEnumerable<JsonObjectType> GetTypeFromFieldNames(IEnumerable<string> fieldNames)
        {
            var fieldNamesArray = fieldNames as string[] ?? fieldNames.ToArray();
            return _types.OrderByDescending(t=>t.NamedType) .Where(objectType => fieldNamesArray.All(objectType.HasField));
        }

        public static JsonObjectType CreateTypeWithName(string name, ObjectValue objectValue)
        {
            var jsonObjectType = new JsonObjectType(name, true );
            foreach (var field in objectValue.Fields)
            {
                jsonObjectType.Fields.Add(field.Name, new JsonObjectField(field.Value.TypeName));
            }
            _types.Add(jsonObjectType);
            return jsonObjectType;
        }

        public static JsonObjectType CreateType(ObjectValue objectValue)
        {
            var jsonObjectType = new JsonObjectType( CreateTmpolaryName(),false );
            foreach (var field in objectValue.Fields)
            {
                jsonObjectType.Fields.Add(field.Name, new JsonObjectField( field.Value.TypeName ) );
            }
            _types.Add(jsonObjectType);
            return jsonObjectType;
        }

        private static string CreateTmpolaryName()
        {
            return string.Format("TempClass{0:d4}", Interlocked.Increment(ref _tempCount));
        }
    }
}