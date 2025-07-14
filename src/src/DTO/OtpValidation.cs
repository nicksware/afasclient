using System.Text.Json.Serialization;

namespace DutchGrit.Afas.DTO
{
    class OtpValidation : OtpRequest
    {
        public OtpValidation() { }

        [JsonPropertyName("Otp")]
        public string OTP { get; set; }

    }


}
