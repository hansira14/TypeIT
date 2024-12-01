using System.Collections.Generic;

namespace TypeIT.Models
{
    public static class KeyboardConstants
    {
        // Basic Keys
        public static readonly Dictionary<string, string> BasicKeys = new Dictionary<string, string>
        {
            // Letters
            {"A", "A"}, {"B", "B"}, {"C", "C"}, {"D", "D"}, {"E", "E"},
            {"F", "F"}, {"G", "G"}, {"H", "H"}, {"I", "I"}, {"J", "J"},
            {"K", "K"}, {"L", "L"}, {"M", "M"}, {"N", "N"}, {"O", "O"},
            {"P", "P"}, {"Q", "Q"}, {"R", "R"}, {"S", "S"}, {"T", "T"},
            {"U", "U"}, {"V", "V"}, {"W", "W"}, {"X", "X"}, {"Y", "Y"},
            {"Z", "Z"},

            // Numbers
            {"0", "0"}, {"1", "1"}, {"2", "2"}, {"3", "3"}, {"4", "4"},
            {"5", "5"}, {"6", "6"}, {"7", "7"}, {"8", "8"}, {"9", "9"},

            // Special Characters
            {"`", "`"}, {"-", "-"}, {"=", "="}, {"[", "["}, {"]", "]"},
            {"\\", "\\"}, {";", ";"}, {"'", "'"}, {",", ","}, {".", "."},
            {"/", "/"}, {"~", "{~}"}, {"!", "{!}"}, {"@", "{@}"},
            {"#", "{#}"}, {"$", "{$}"}, {"%", "{%}"}, {"^", "{^}"},
            {"&", "{&}"}, {"*", "{*}"}, {"(", "{(}"}, {")", "{)}"},
            {"_", "{_}"}, {"+", "{+}"}, {"{", "{{}"}, {"}", "{}}"},
            {"|", "{|}"}, {":", "{:}"}, {"\"", "{\"}"}, {"<", "{<}"},
            {">", "{>}"}, {"?", "{?}"}
        };

        // Function Keys
        public static readonly Dictionary<string, string> FunctionKeys = new Dictionary<string, string>
        {
            {"F1", "{F1}"}, {"F2", "{F2}"}, {"F3", "{F3}"}, {"F4", "{F4}"},
            {"F5", "{F5}"}, {"F6", "{F6}"}, {"F7", "{F7}"}, {"F8", "{F8}"},
            {"F9", "{F9}"}, {"F10", "{F10}"}, {"F11", "{F11}"}, {"F12", "{F12}"}
        };

        // Special Commands
        public static readonly Dictionary<string, string> SpecialKeys = new Dictionary<string, string>
        {
            {"ENTER", "{ENTER}"},
            {"TAB", "{TAB}"},
            {"SPACE", " "},
            {"BACKSPACE", "{BACKSPACE}"},
            {"DELETE", "{DELETE}"},
            {"ESC", "{ESC}"},
            {"HOME", "{HOME}"},
            {"END", "{END}"},
            {"PGUP", "{PGUP}"},
            {"PGDN", "{PGDN}"},
            {"INSERT", "{INS}"},
            {"CAPSLOCK", "{CAPSLOCK}"},
            {"NUMLOCK", "{NUMLOCK}"},
            {"SCROLLLOCK", "{SCROLLLOCK}"},
            {"PRINTSCREEN", "{PRTSC}"},
            {"PAUSE", "{PAUSE}"},
            {"UP", "{UP}"},
            {"DOWN", "{DOWN}"},
            {"LEFT", "{LEFT}"},
            {"RIGHT", "{RIGHT}"}
        };

        // Common Key Combinations
        public static readonly Dictionary<string, string[]> CommonCombinations = new Dictionary<string, string[]>
        {
            {"Cut", new[] {"^", "X"}},                    // Ctrl+X
            {"Copy", new[] {"^", "C"}},                   // Ctrl+C
            {"Paste", new[] {"^", "V"}},                  // Ctrl+V
            {"Undo", new[] {"^", "Z"}},                   // Ctrl+Z
            {"Redo", new[] {"^", "Y"}},                   // Ctrl+Y
            {"Select All", new[] {"^", "A"}},             // Ctrl+A
            {"Save", new[] {"^", "S"}},                   // Ctrl+S
            {"Find", new[] {"^", "F"}},                   // Ctrl+F
            {"New", new[] {"^", "N"}},                    // Ctrl+N
            {"Print", new[] {"^", "P"}},                  // Ctrl+P
            {"Bold", new[] {"^", "B"}},                   // Ctrl+B
            {"Italic", new[] {"^", "I"}},                 // Ctrl+I
            {"Underline", new[] {"^", "U"}},              // Ctrl+U
            {"Close", new[] {"%", "F4"}},                 // Alt+F4
            {"Switch Window", new[] {"%", "TAB"}},        // Alt+Tab
            {"Windows Menu", new[] {"^", "{ESC}"}},       // Ctrl+Esc
            {"Lock Windows", new[] {"#", "L"}},           // Win+L
            {"Task Manager", new[] {"^", "+", "{ESC}"}},  // Ctrl+Shift+Esc
        };

        // Modifier Keys for combinations
        public static readonly Dictionary<string, string> ModifierKeys = new Dictionary<string, string>
        {
            {"CTRL", "^"},
            {"ALT", "%"},
            {"SHIFT", "+"},
            {"WIN", "#"}
        };
    }
} 