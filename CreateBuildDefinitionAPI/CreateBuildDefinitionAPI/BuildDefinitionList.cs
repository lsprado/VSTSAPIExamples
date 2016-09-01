using CreateBuildDefinitionAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateBuildDefinitionAPI
{
    public class BuildDefinitionList
    {
        [JsonProperty(PropertyName = "uri")]
        public String Uri { get; set; }

        [JsonProperty(PropertyName = "queue")]
        public BuildQueue Queue { get; set; }

        [JsonProperty(PropertyName = "triggerType")]
        public String TriggerType { get; set; }

        [JsonProperty(PropertyName = "defaultDropLocation")]
        public String DefaultDropLocation { get; set; }

        [JsonProperty(PropertyName = "dateCreated")]
        public DateTime DateCreated { get; set; }

        [JsonProperty(PropertyName = "definitionType")]
        public String DefinitionType { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public String Name { get; set; }

        [JsonProperty(PropertyName = "url")]
        public String Url { get; set; }
    }
}
