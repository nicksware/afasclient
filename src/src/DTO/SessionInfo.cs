using System.Text.Json.Serialization;

namespace DutchGrit.Afas
{
    [JsonUnmappedMemberHandling(JsonUnmappedMemberHandling.Disallow)]
    public class SessionInfo
    {
        public SessionInfo() { }

        [JsonPropertyName("updateConnectors")]
        public ConnectorInfo[] UpdateConnectors { get; set; }

        [JsonPropertyName("getConnectors")]
        public ConnectorInfo[] GetConnectors { get; set; }

        [JsonPropertyName("info")]
        public SessionInfoDetails Info { get; set; }
    }

}
