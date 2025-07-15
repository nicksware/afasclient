using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Text;

namespace DutchGrit.Afas
{
    public class QueryResult<T>
    {
        public QueryResult() { }

        [JsonPropertyName("skip")]
        public int Skip { get; set; }

        [JsonPropertyName("take")]
        public int Take { get; set; }

        [JsonPropertyName("rows")]
        public T[] Row { get; set; }
    }
}
