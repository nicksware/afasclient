using System.Text.Json.Serialization;

namespace DutchGrit.Afas.DTO
{
    public class OtpValidationResponse
    {
        public OtpValidationResponse() { }
        
        [JsonPropertyName("token")]
        public string Token { get; set; }
    }
}
