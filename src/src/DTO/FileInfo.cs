using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Text;

namespace DutchGrit.Afas
{
    public class FileInfo
    {
        public FileInfo() { }

        [JsonPropertyName("filename")]
        public string FileName { get; set; }

        [JsonPropertyName("filedata")]
        public string FileDataBase64 { get; set; }

        [JsonPropertyName("mimetype")]
        public string mimetype { get; set; }
    }
}
