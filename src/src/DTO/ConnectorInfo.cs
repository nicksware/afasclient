using System.Text.Json.Serialization;

namespace DutchGrit.Afas
{
    [JsonUnmappedMemberHandling(JsonUnmappedMemberHandling.Disallow)]
    public class ConnectorInfo
    {
        public ConnectorInfo() { }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
