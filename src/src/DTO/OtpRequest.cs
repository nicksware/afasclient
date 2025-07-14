using System.Text.Json.Serialization;

namespace DutchGrit.Afas.DTO
{
    public class OtpRequest
    {
        public OtpRequest() { }

        [JsonPropertyName("apiKey")]
        public string ApiKey { get; set; }

        [JsonPropertyName("userid")]
        public string UserId { get; set; }

        [JsonPropertyName("apiToken")]
        public string ApiToken { get; set; }
    
    }

}
