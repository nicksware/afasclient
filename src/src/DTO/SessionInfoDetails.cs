﻿using System.Text.Json.Serialization;

namespace DutchGrit.Afas
{
    public class SessionInfoDetails
    {
        [JsonPropertyName("envid")]
        public string EnvironmentID { get; set; }

        [JsonPropertyName("appName")]
        public string ApplicationName { get; set; }

        [JsonPropertyName("group")]
        public string Group { get; set; }

        [JsonPropertyName("tokenExpiry")]
        public string TokenExpiry { get; set; }

    }


}
