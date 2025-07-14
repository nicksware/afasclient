using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Linq;

namespace DutchGrit.Afas
{

    public static class MergeUtils
    {
        public static string MergeString(string s1, string s2)
        {
            if (s1==null) { return s2; }
            if (s2==null) { return s1; }
            return (s1.Length>s2.Length) ? s1 :s2; 
        }
    }


    public class UpdateConMetaInfo  : IMergeable<UpdateConMetaInfo>
    {
        public UpdateConMetaInfo() { }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("fields")]
        public UpdateConMetaInfoField[] Fields { get; set; }

        [JsonPropertyName("objects")]
        public UpdateConMetaInfo[] Objects { get; set; }


        /// <summary>
        /// Used by generator to know if this MetaInfo comes from the mainitem in an UpdateConnector, 
        /// or from a sub-part within a mainitem. 
        /// </summary>
        [JsonIgnore]
        public bool IsConnected { get; set; } = false;

        //[JsonIgnore]
        //public string ConnectorName { get; set; }

        public void MergeWith(UpdateConMetaInfo other)
        {
            //merge the properties
            this.IsConnected = this.IsConnected || other.IsConnected;
            this.Description = MergeUtils.MergeString(this.Description, other.Description);
            this.Name = MergeUtils.MergeString(this.Name, other.Name);
            this.Id = MergeUtils.MergeString(this.Id, other.Id);
            //this.ConnectorName = MergeUtils.MergeString(this.ConnectorName, other.ConnectorName);

            //merge the fields.. 
            var newfields = new List<UpdateConMetaInfoField>();
            if (this.Fields!=null) { newfields.AddRange(this.Fields); }
            if (other.Fields != null)
            {
                foreach (var otherField in other.Fields)
                {
                    var thisField = newfields.Where(x => x.FieldId == otherField.FieldId).FirstOrDefault();
                    if (thisField == null)
                    {
                        newfields.Add(otherField);
                    }
                    else
                    {
                        thisField.MergeWith(otherField);
                    }

                }
            }
            this.Fields = newfields.ToArray();


            //merg the objects..
            var newobjects = new List<UpdateConMetaInfo>();
            if (this.Objects!=null) { newobjects.AddRange(this.Objects); }
            if (other.Objects != null)
            {
                foreach (var otherObject in other.Objects)
                {
                    var thisObject = newobjects.Where(x => x.Name == otherObject.Name).FirstOrDefault();
                    if (thisObject == null)
                    {
                        newobjects.Add(otherObject);
                    }
                }
            }
            this.Objects = newobjects.ToArray();

        }
    }

    public class MetaInfoValue
    {
        public MetaInfoValue() { }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

    }


}
