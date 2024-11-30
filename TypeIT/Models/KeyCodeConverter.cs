using System;
using System.Collections.Generic;
using System.Text;

namespace TypeIT.Models
{
    public static class KeyCodeConverter
    {
        private static readonly Dictionary<int, string> LeftFingerMap = new Dictionary<int, string>
        {
            {0, "Lpinky"},
            {1, "Lring"},
            {2, "Lmiddle"},
            {3, "Lindex"},
            {4, "Lthumb"}
        };

        private static readonly Dictionary<int, string> RightFingerMap = new Dictionary<int, string>
        {
            {5, "Rthumb"},
            {6, "Rindex"},
            {7, "Rmiddle"},
            {8, "Rring"},
            {9, "Rpinky"}
        };

        public static string ConvertToFingerCombination(string keyCode)
        {
            // Remove 'S' prefix and 'E' suffix
            if (keyCode.Length != 12 || !keyCode.StartsWith("S") || !keyCode.EndsWith("E"))
                return keyCode; // Return original if invalid format

            string binaryPart = keyCode.Substring(1, 10);
            List<string> activeFingers = new List<string>();

            for (int i = 0; i < binaryPart.Length; i++)
            {
                if (binaryPart[i] == '1')
                {
                    if (i < 5 && LeftFingerMap.ContainsKey(i))
                        activeFingers.Add(LeftFingerMap[i]);
                    else if (RightFingerMap.ContainsKey(i))
                        activeFingers.Add(RightFingerMap[i]);
                }
            }

            return activeFingers.Count > 0 ? string.Join(" + ", activeFingers) : "None";
        }
    }
} 