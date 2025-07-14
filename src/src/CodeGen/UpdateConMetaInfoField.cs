using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;

namespace DutchGrit.Afas
{
    public class UpdateConMetaInfoField : IMergeable<UpdateConMetaInfoField>
    {
        public UpdateConMetaInfoField() { }
        
        [JsonPropertyName("fieldId")]
        public string FieldId {get;set;}

        [JsonPropertyName("primaryKey")]
        public string PrimaryKey { get; set; }

        [JsonPropertyName("dataType")]
        public string DataType { get; set; }

        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("mandatory")]
        public bool Mandatory { get; set; }

        [JsonPropertyName("length")]
        public int Length { get; set; }

        [JsonPropertyName("controlType")]
        public int ControlType { get; set; }

        [JsonPropertyName("decimals")]
        public int Decimals { get; set; }

        [JsonPropertyName("notzero")]
        public bool NotZero { get; set; }

        [JsonPropertyName("values")]
        public MetaInfoValue[] Values { get; set; }

        public void MergeWith(UpdateConMetaInfoField other)
        {
            //Checks
            if (this.FieldId != other.FieldId) { throw new ArgumentOutOfRangeException("FieldId should match."); }
            if (this.DataType != other.DataType) { throw new ArgumentOutOfRangeException("DataType should match."); }
            
            //Properties
            this.PrimaryKey = other.PrimaryKey == "true" ? "true" : this.PrimaryKey;
            this.Label = MergeUtils.MergeString(this.Label, other.Label);
            this.Mandatory = this.Mandatory || other.Mandatory;
            this.NotZero = this.NotZero || other.NotZero;

            //Values -> not merged, but we pick the longest list.
            var valuesThis = new List<MetaInfoValue>();
            if (this.Values!=null) { valuesThis.AddRange(this.Values); }
            var valuesOther = new List<MetaInfoValue>();
            if (other.Values!=null ) { valuesOther.AddRange(other.Values); }
            this.Values = (valuesThis.Count >= valuesOther.Count) ? valuesThis.ToArray() : valuesOther.ToArray();
            if (this.Values.Length==0) { this.Values = null; }


        }
    }


}
