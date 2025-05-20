using System.Text.Json.Serialization;

namespace DutchGrit.Afas.DTO
{
    public class OtpValidationResponse
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }
    }
}
