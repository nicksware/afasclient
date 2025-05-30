﻿using System.Text.Json.Serialization;

namespace DutchGrit.Afas
{
    public class GetConMetaInfo
    {
        [JsonPropertyName("fields")]
        public GetConMetaInfoField[] Fields { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
