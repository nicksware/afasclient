using System.Text.Json.Serialization;

namespace DutchGrit.Afas
{
    public class GetConMetaInfoField
    {

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("fieldId")]
        public string FieldId { get; set; }

        [JsonPropertyName("dataType")]
        public string DataType { get; set; }

        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("length")]
        public int Length { get; set; }

        [JsonPropertyName("controlType")]
        public int ControlType { get; set; }

        [JsonPropertyName("decimals")]
        public int Decimals { get; set; }

        [JsonPropertyName("decimalsFieldId")]
        public string DecimalsFieldId { get; set; }


    }
}
