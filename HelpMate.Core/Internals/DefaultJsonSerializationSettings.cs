using System.Text.Json;

namespace HelpMate.Core.Internals
{
    internal class DefaultJsonSerializationSettings
    {
        public static JsonSerializerOptions GetSerializerOptions(JsonNamingPolicy jsonNamingPolicy, bool ignoreNullValues = true)
            => new JsonSerializerOptions
            {
                IgnoreNullValues = ignoreNullValues,
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = jsonNamingPolicy,
                DictionaryKeyPolicy = jsonNamingPolicy,
                WriteIndented = true
            };
    }
}
