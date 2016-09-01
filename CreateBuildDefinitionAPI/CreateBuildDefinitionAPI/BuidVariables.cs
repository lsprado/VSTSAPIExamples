using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateBuildDefinitionAPI
{
    public class BuidVariables
    {
        [JsonProperty(PropertyName = "System.Debug")]
        public SystemDebug SystemDebug { get; set; }
        public Buildconfiguration BuildConfiguration { get; set; }
        public Buildplatform BuildPlatform { get; set; }
    }

    public class SystemDebug
    {
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

        [JsonProperty(PropertyName = "allowOverride")]
        public bool AllowOverride { get; set; }
    }

    public class Buildconfiguration
    {
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }
        [JsonProperty(PropertyName = "allowOverride")]
        public bool AllowOverride { get; set; }
    }

    public class Buildplatform
    {
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }
        [JsonProperty(PropertyName = "allowOverride")]
        public bool AllowOverride { get; set; }
    }

}