using Newtonsoft.Json;
using System;

namespace CreateBuildDefinitionAPI
{
    public class BuildPool
    {
        [JsonProperty(PropertyName = "id")]
        public int id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public String Name { get; set; }
    }
}