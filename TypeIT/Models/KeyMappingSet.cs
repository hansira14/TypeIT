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
        public Dictionary<string, Macro> Macros { get; set; } = new Dictionary<string, Macro>();

        public KeyMappingSet()
        {
            KeyMappings = new Dictionary<string, List<string>>();
            Macros = new Dictionary<string, Macro>();
        }

        public void AddMacro(string fingerCombination, Macro macro)
        {
            Macros[fingerCombination] = macro;
        }

        public bool TryGetMacro(string fingerCombination, out Macro macro)
        {
            return Macros.TryGetValue(fingerCombination, out macro);
        }
    }
}
