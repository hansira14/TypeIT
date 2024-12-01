using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using TypeIT.Models;

public class KeyMappingProfileJson
{
    public string name { get; set; }
    public List<KeyMappingSetJson> sets { get; set; }

    public class KeyMappingSetJson
    {
        [JsonPropertyName("activation key")]
        public string activationKey { get; set; }
        public Dictionary<string, List<string>> mappings { get; set; }
    }

    public static KeyMappingProfileJson FromKeyMappingProfile(KeyMappingProfile profile)
    {
        var jsonProfile = new KeyMappingProfileJson
        {
            name = profile.Name,
            sets = new List<KeyMappingSetJson>()
        };

        foreach (var set in profile.Sets)
        {
            var jsonSet = new KeyMappingSetJson
            {
                activationKey = set.Value.ActivationKey,
                mappings = set.Value.KeyMappings
            };
            jsonProfile.sets.Add(jsonSet);
        }

        return jsonProfile;
    }
} 