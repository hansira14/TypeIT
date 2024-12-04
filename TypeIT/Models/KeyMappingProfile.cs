using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TypeIT.Models
{
    public class KeyMappingProfile
    {
        public string Name; //Name of the profile
        //public string? CurrentActivationKeySelected;
        public KeyMappingSet CurrentMappingsSelected;
        public Dictionary<string, KeyMappingSet> Sets = new Dictionary<string, KeyMappingSet>(); // Initialize the Sets dictionary for key mappings
        public Dictionary<string, Macro> Macros { get; set; } = new Dictionary<string, Macro>();

        // Custom manual deserialization method
        public static KeyMappingProfile FromJsonManual(string jsonContent)
        {
            var profile = new KeyMappingProfile();

            try
            {
                // Parse the JSON using JsonDocument
                using (JsonDocument doc = JsonDocument.Parse(jsonContent))
                {
                    // Extract the name and current activation key selected
                    profile.Name = doc.RootElement.GetProperty("name").GetString();

                    // Get the sets array and iterate over it
                    var setsArray = doc.RootElement.GetProperty("sets").EnumerateArray();

                    // Set the first activationKey from the sets array as the CurrentActivationKeySelected


                    foreach (var setElement in setsArray)
                    {
                        // Extract each set's ActivationKey
                        string activationKey = setElement.GetProperty("activation key").GetString();

                        // Create a new KeyMappingSet
                        var keyMappingSet = new KeyMappingSet
                        {
                            ActivationKey = activationKey,
                            KeyMappings = new Dictionary<string, List<string>>()
                        };

                        // Get the mappings for the current set
                        var mappingsObject = setElement.GetProperty("mappings");

                        foreach (var mapping in mappingsObject.EnumerateObject())
                        {
                            // Deserialize the list of strings from the mapping value
                            var valuesArray = mapping.Value.EnumerateArray();
                            var valuesList = new List<string>();

                            foreach (var value in valuesArray)
                            {
                                valuesList.Add(value.GetString());
                            }

                            keyMappingSet.KeyMappings[mapping.Name] = valuesList;
                        }

                        // Add the set to the dictionary
                        profile.Sets[activationKey] = keyMappingSet;
                    }

                    // Assign the first set as the current mappings selected, if available
                    var firstSet = profile.Sets.Values.FirstOrDefault();
                    if (firstSet != null)
                    {
                        profile.CurrentMappingsSelected = firstSet;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error during manual deserialization: {ex.Message}");
            }

            return profile;
        }

        public void AddMacro(string name, Macro macro)
        {
            Macros[name] = macro;
        }

        public bool TryGetMacro(string name, out Macro macro)
        {
            return Macros.TryGetValue(name, out macro);
        }
    }
}
