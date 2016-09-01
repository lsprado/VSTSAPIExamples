using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateBuildDefinitionAPI
{
    public class ApiCollection<T>
    {
        [JsonProperty(PropertyName = "value")]
        public IEnumerable<T> Value { get; set; }

        [JsonProperty(PropertyName = "count")]
        public int Count { get; set; }
    }
}