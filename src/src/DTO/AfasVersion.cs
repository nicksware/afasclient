using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Text;

namespace DutchGrit.Afas
{
    class AfasVersion
    {
        public AfasVersion() { }

        [JsonPropertyName("version")]
        public string Version { get; set; }
    }
}
