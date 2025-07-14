using System.Linq;
using System.Text.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DutchGrit.Afas
{

    static class AfasUpdateWriter
    {
        public static string Write(IUpdateEntity value, IUpdateEntity[] elements)
        {
            var root = new Dictionary<string, object>();
            var mainObj = new Dictionary<string, object>();

            List<object> elementList = new List<object>();

            // Serialize fields, ignoring nulls
            // Updated JsonSerializerOptions to use DefaultIgnoreCondition
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                // Controls how null values are handled during serialization
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                // Fail on any JSON properties not mapped to your model
                UnmappedMemberHandling = JsonUnmappedMemberHandling.Disallow,
                WriteIndented = true
            };

            foreach (var element in elements)
            {
                var elementObj = new Dictionary<string, object>();

                // Get KeyFieldName
                var keyFields = KeyFieldAttribute.GetFieldNames(element);
                if (keyFields != null)
                {
                    foreach (var keyField in keyFields)
                    {
                        var keyValue = element.GetType().GetProperty(keyField).GetValue(element, null);
                        if (keyValue != null)
                        {
                            elementObj["@" + keyField] = keyValue;
                        }
                    }
                }

                var fieldsJson = JsonSerializer.Serialize(element, options);
                elementObj["Fields"] = JsonDocument.Parse(fieldsJson).RootElement;

                if (element.Objects != null)
                {
                    var objectsArr = new List<object>();
                    var uniqueObjects = element.Objects.Select(x => x.GetType().Name).Distinct().ToArray();
                    foreach (var uniqueObject in uniqueObjects)
                    {
                        var subelements = element.Objects.Where(x => x.GetType().Name == uniqueObject).ToArray();
                        var subJson = Write(subelements[0], subelements);
                        objectsArr.Add(JsonDocument.Parse(subJson).RootElement);
                    }
                    elementObj["Objects"] = objectsArr;
                }

                elementList.Add(elementObj);
            }

            // If only one element, don't wrap in array
            mainObj["Element"] = elements.Length > 1 ? elementList : elementList.First();

            root[value.GetType().Name] = mainObj;

            var rootJson = JsonSerializer.Serialize(root, options);
            return rootJson;
        }
    }
}

