using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Timers;

namespace TypeIT.Models
{
    public class KeyInputProcessor
    {
        private const int COMBINATION_WINDOW_MS = 50; // Time window for combining keypresses
        private string currentState = "S0000000000E";
        private string pendingState = "S0000000000E";
        private System.Timers.Timer combinationTimer;
        private bool isProcessing = false;

        public event EventHandler<string> KeyStateProcessed;

        public KeyInputProcessor()
        {
            combinationTimer = new System.Timers.Timer(COMBINATION_WINDOW_MS);
            combinationTimer.AutoReset = false;
            combinationTimer.Elapsed += ProcessPendingState;
        }

        public void ProcessInput(string input)
        {
            if (!IsValidInput(input))
            {
                Debug.WriteLine($"Invalid input format: {input}");
                return;
            }

            // If it's a release state (all zeros), process immediately
            if (input == "S0000000000E")
            {
                ProcessFinalState(input);
                return;
            }

            // Combine the new input with any pending state
            pendingState = CombineStates(pendingState, input);
            
            // Reset and restart the combination timer
            combinationTimer.Stop();
            combinationTimer.Start();
        }

        private void ProcessPendingState(object sender, ElapsedEventArgs e)
        {
            if (isProcessing) return;
            isProcessing = true;

            try
            {
                // Only emit if state has changed
                if (pendingState != currentState)
                {
                    ProcessFinalState(pendingState);
                }
            }
            finally
            {
                isProcessing = false;
            }
        }

        private void ProcessFinalState(string state)
        {
            currentState = state;
            pendingState = state;
            KeyStateProcessed?.Invoke(this, state);
        }

        private bool IsValidInput(string input)
        {
            return input != null && 
                   input.Length == 12 && 
                   input.StartsWith("S") && 
                   input.EndsWith("E") &&
                   input.Substring(1, 10).All(c => c == '0' || c == '1');
        }

        private string CombineStates(string state1, string state2)
        {
            if (state1.Length != 12 || state2.Length != 12)
                return state1;

            char[] combined = new char[12];
            combined[0] = 'S';
            combined[11] = 'E';

            // Combine the middle 10 characters using OR operation
            for (int i = 1; i <= 10; i++)
            {
                combined[i] = (state1[i] == '1' || state2[i] == '1') ? '1' : '0';
            }

            return new string(combined);
        }
    }
} 