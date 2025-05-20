using System.Text.Json.Serialization;

namespace DutchGrit.Afas.DTO
{
    class OtpValidation : OtpRequest
    {

        [JsonPropertyName("Otp")]
        public string OTP { get; set; }

    }


}
