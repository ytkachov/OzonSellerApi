using System;
using System.Collections.Generic;
using System.IO;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OzonSellerApi
{
    public static class JsonToolkit
    {
        private static JsonSerializer _serializer = new JsonSerializer();

        public static string ToPrettyJson(this object inputObject, params JsonConverter[] converters)
        {
            var serializer = new JsonSerializer
            {
                Formatting = Formatting.Indented
            };
            return inputObject.ToJson(serializer, converters);
        }

        public static string ToJson(this object inputObject, params JsonConverter[] converters)
        {
            return inputObject.ToJson((converters?.Length ?? 0) == 0 ? _serializer : new JsonSerializer(), converters);
        }

        private static string ToJson(this object inputObject,
            JsonSerializer serializer, params JsonConverter[] converters)
        {
            foreach (var converter in converters)
                serializer.Converters.Add(converter);

            using var stringWriter = new StringWriter();

            serializer.Serialize(stringWriter, inputObject);

            return stringWriter.ToString();
        }

        public static T ParseAsJson<T>(this string jsonString, params JsonConverter[] jsonConverters)
        {
            if (string.IsNullOrWhiteSpace(jsonString))
            {
                return default;
            }

            var jsonSerializer = (jsonConverters?.Length ?? 0) == 0 ? _serializer : new JsonSerializer();

            if (jsonConverters != null)
            {
                foreach (var converter in jsonConverters)
                {
                    jsonSerializer.Converters.Add(converter);
                }
            }

            using (var stringReader = new StringReader(jsonString))
            {
                using (var reader = new JsonTextReader(stringReader))
                {
                    return jsonSerializer.Deserialize<T>(reader);
                }
            }
        }

        public static object ParseAsJson(this string jsonString,
            Type objectType = null, params JsonConverter[] jsonConverters)
        {
            if (string.IsNullOrWhiteSpace(jsonString))
                return null;

            var jsonSerializer = (jsonConverters?.Length ?? 0) == 0 ? _serializer : new JsonSerializer();

            foreach (var converter in jsonConverters)
                jsonSerializer.Converters.Add(converter);

            using var stringReader = new StringReader(jsonString);
            return jsonSerializer.Deserialize(stringReader, objectType);
        }
    }

    internal class PropertyBasedJavaScriptConverter : JsonConverter
    {
        private readonly string _propertyName;
        private readonly Type _type;
        private readonly Dictionary<string, Type> _types;
        private readonly JsonConverter[] _converters;

        internal PropertyBasedJavaScriptConverter(
            string propertyName, Type type, JsonConverter[] converters, Dictionary<string, Type> types)
        {
            _propertyName = propertyName;
            _type = type;
            _types = types;
            _converters = converters;
        }

        public override bool CanConvert(Type objectType)
        {
            return _type.IsAssignableFrom(objectType);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartObject)
            {
                var dictionary = JObject.Load(reader);
                var targetType = dictionary[_propertyName] != null
                    ? _types[(string)dictionary[_propertyName]]
                    : objectType;

                var newSerializer = new JsonSerializer();

                if (_converters != null)
                {
                    foreach (var converter in _converters)
                    {
                        newSerializer.Converters.Add(converter);
                    }
                }

                return newSerializer.Deserialize(dictionary.CreateReader(), targetType);
            }

            return null;
        }
    }

    public class PropertyTypeBasedJavaScriptConverter : JsonConverter
    {
        private readonly Type _parentType;
        private readonly Dictionary<string, Type> _types;
        private readonly JsonConverter[] _converters;

        internal PropertyTypeBasedJavaScriptConverter(Type parentType,
            Dictionary<string, Type> types, JsonConverter[] converters = null)
        {
            _parentType = parentType;
            _types = types;
            _converters = converters;
        }

        public override bool CanConvert(Type type)
        {
            return _parentType.Equals(type);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            JObject dictionary;

            try
            {
                dictionary = JObject.Load(reader);
            }
            catch (JsonReaderException)
            {
                return null;
            }

            foreach (var pair in _types)
            {
                if (dictionary[pair.Key] != null)
                {
                    var type = pair.Value;
                    var newSerializer = new JsonSerializer();

                    if (_converters != null)
                    {
                        foreach (var converter in _converters)
                        {
                            newSerializer.Converters.Add(converter);
                        }
                    }

                    return newSerializer.Deserialize(dictionary.CreateReader(), type);
                }
            }

            return null;
        }
    }
}

