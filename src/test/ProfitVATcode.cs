using System.Text.Json.Serialization;

namespace DutchGrit.Afas.Tests
{
    [ConnectorName("Profit_VAT_code")]
    public class ProfitVATcode : IGetEntity
    {
        public ProfitVATcode() { }

        /// <summary>
        /// Btw-code
        /// </summary>

        [JsonPropertyName("VatCode")]
        public virtual string VatCode { get; set; }


        /// <summary>
        /// Omschrijving
        /// </summary>

        [JsonPropertyName("Description")]
        public virtual string Description { get; set; }


        /// <summary>
        /// Rekening
        /// </summary>

        [JsonPropertyName("AccountNr")]
        public virtual string AccountNr { get; set; }


        /// <summary>
        /// Tarief
        /// </summary>

        [JsonPropertyName("VatPerc")]
        public virtual double? VatPerc { get; set; }


        /// <summary>
        /// Btw-plicht
        /// </summary>

        [JsonPropertyName("VatDuty")]
        public virtual string VatDuty { get; set; }


        /// <summary>
        /// Geblokkeerd
        /// </summary>

        [JsonPropertyName("Blocked")]
        public virtual bool? Blocked { get; set; }


        /// <summary>
        /// Berekeningsmethode
        /// </summary>

        [JsonPropertyName("VatMethod")]
        public virtual string VatMethod { get; set; }


        /// <summary>
        /// Code inkoop/verkoop code
        /// </summary>

        [JsonPropertyName("VatType")]
        public virtual string VatType { get; set; }

    }
}
