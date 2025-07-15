using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Text;
using System;

namespace DutchGrit.Afas
{
    [JsonUnmappedMemberHandling(JsonUnmappedMemberHandling.Disallow)]
    public class GetConMetaInfo
    {
        public GetConMetaInfo() { }

        [JsonPropertyName("fields")]
        public GetConMetaInfoField[] Fields { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
