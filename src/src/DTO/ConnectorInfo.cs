using System.Text.Json.Serialization;

namespace DutchGrit.Afas
{
    public class ConnectorInfo
    {
        public ConnectorInfo() { }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }


}
