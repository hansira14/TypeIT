using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TypeIT.Models
{
    public class KeyMappingSet
    {
        public string ActivationKey;

        public Dictionary<string, List<string>> KeyMappings;

    }
}
