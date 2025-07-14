using System.Text.Json.Serialization;

namespace DutchGrit.Afas
{
    class AfasVersion
    {
        public AfasVersion() { }

        [JsonPropertyName("version")]
        public string Version { get; set; }
    }


}
