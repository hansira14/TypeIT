using System;
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
        public Dictionary<string, MacroJson> macros { get; set; }
    }

    public class MacroJson
    {
        public string name { get; set; }
        public List<KeyActionJson> actions { get; set; }
        public int delayBetweenActions { get; set; }
    }

    public class KeyActionJson
    {
        public string key { get; set; }
        public string type { get; set; }
        public int? customDelay { get; set; }
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
                mappings = set.Value.KeyMappings,
                macros = set.Value.Macros.ToDictionary(
                    kvp => kvp.Key,
                    kvp => new MacroJson
                    {
                        name = kvp.Value.Name,
                        delayBetweenActions = kvp.Value.DelayBetweenActions,
                        actions = kvp.Value.Actions.Select(a => new KeyActionJson
                        {
                            key = a.Key,
                            type = a.Type.ToString(),
                            customDelay = a.CustomDelay
                        }).ToList()
                    }
                )
            };
            jsonProfile.sets.Add(jsonSet);
        }

        return jsonProfile;
    }

    public static KeyMappingProfile FromJsonManual(JsonElement json)
    {
        var profile = new KeyMappingProfile
        {
            Name = json.GetProperty("name").GetString()
        };

        var sets = json.GetProperty("sets").EnumerateArray();
        foreach (var setElement in sets)
        {
            var keyMappingSet = new KeyMappingSet
            {
                ActivationKey = setElement.GetProperty("activation key").GetString()
            };

            var mappings = setElement.GetProperty("mappings").EnumerateObject();
            foreach (var mapping in mappings)
            {
                keyMappingSet.KeyMappings[mapping.Name] = mapping.Value.EnumerateArray().Select(x => x.GetString()).ToList();
            }

            if (setElement.TryGetProperty("macros", out var macrosElement))
            {
                foreach (var macro in macrosElement.EnumerateObject())
                {
                    var macroObj = macro.Value;
                    var newMacro = new Macro
                    {
                        Name = macroObj.GetProperty("name").GetString(),
                        DelayBetweenActions = macroObj.GetProperty("delayBetweenActions").GetInt32()
                    };

                    var actions = macroObj.GetProperty("actions").EnumerateArray();
                    foreach (var action in actions)
                    {
                        newMacro.AddAction(
                            action.GetProperty("key").GetString(),
                            Enum.Parse<Macro.ActionType>(action.GetProperty("type").GetString()),
                            action.TryGetProperty("customDelay", out var delay) ? delay.GetInt32() : null
                        );
                    }

                    keyMappingSet.Macros[macro.Name] = newMacro;
                }
            }

            profile.Sets[keyMappingSet.ActivationKey] = keyMappingSet;
        }

        return profile;
    }
}