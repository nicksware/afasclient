using System.Text.Json.Serialization;

namespace DutchGrit.Afas
{
    class AfasVersion
    {

        [JsonPropertyName("version")]
        public string Version { get; set; }
    }


}
