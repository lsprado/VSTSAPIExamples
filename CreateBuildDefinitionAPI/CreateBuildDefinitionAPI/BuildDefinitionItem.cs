using CreateBuildDefinitionAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateBuildDefinitionAPI
{
    public class BuildDefinitionItem
    {
        [JsonProperty(PropertyName = "uri")]
        public String Uri { get; set; }

        [JsonProperty(PropertyName = "queue")]
        public BuildQueue Queue { get; set; }

        [JsonProperty(PropertyName = "variables")]
        public BuidVariables Variables { get; set; }

        [JsonProperty(PropertyName = "type")]
        public String Type { get; set; }

        [JsonProperty(PropertyName = "quality")]
        public String Quality { get; set; }

        //[JsonProperty(PropertyName = "definitionType")]
        //public String DefinitionType { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public String Name { get; set; }

        //[JsonProperty(PropertyName = "url")]
        //public String Url { get; set; }
    }
}
