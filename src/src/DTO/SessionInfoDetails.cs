using System.Text.Json.Serialization;

namespace DutchGrit.Afas
{
    [JsonUnmappedMemberHandling(JsonUnmappedMemberHandling.Disallow)]
    public class SessionInfoDetails
    {
        public SessionInfoDetails() { }

        [JsonPropertyName("envid")]
        public string EnvironmentID { get; set; }

        [JsonPropertyName("appName")]
        public string ApplicationName { get; set; }

        [JsonPropertyName("group")]
        public string Group { get; set; }

        [JsonPropertyName("tokenExpiry")]
        public string TokenExpiry { get; set; }

    }
}
