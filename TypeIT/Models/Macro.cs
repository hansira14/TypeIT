public class Macro
{
    public string Name { get; set; }
    public List<KeyAction> Actions { get; set; } = new List<KeyAction>();
    public int DelayBetweenActions { get; set; } = 50; // Default delay in ms

    public class KeyAction
    {
        public string Key { get; set; }
        public ActionType Type { get; set; }
        public int? CustomDelay { get; set; }
    }

    public enum ActionType
    {
        KeyPress,
        KeyDown,
        KeyUp,
        Delay
    }

    public void AddAction(string key, ActionType type, int? customDelay = null)
    {
        Actions.Add(new KeyAction 
        { 
            Key = key, 
            Type = type,
            CustomDelay = customDelay 
        });
    }

    public async Task PlayAsync()
    {
        foreach (var action in Actions)
        {
            switch (action.Type)
            {
                case ActionType.KeyPress:
                    SendKeys.SendWait(action.Key);
                    break;
                case ActionType.KeyDown:
                    // Implement using Windows API if needed
                    break;
                case ActionType.KeyUp:
                    // Implement using Windows API if needed
                    break;
                case ActionType.Delay:
                    if (action.CustomDelay.HasValue)
                    {
                        await Task.Delay(action.CustomDelay.Value);
                    }
                    break;
            }

            // Default delay between actions
            if (action.Type != ActionType.Delay)
            {
                await Task.Delay(DelayBetweenActions);
            }
        }
    }
}