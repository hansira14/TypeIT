using System.Diagnostics;
using TypeIT.Models;

namespace TypeIT
{
    internal static class Program
    {
        //To make the selected mapping profile globally acessible, put it here
        public static List<KeyMappingProfile> KeyMappingProfiles = new List<KeyMappingProfile>();//Preload all of the DefaultKeyMappingProfiles
        public static KeyMappingProfile CurrentSelectedMappingProfile;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            PreloadDefaultKeyMappingProfiles();
            Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);
            ApplicationConfiguration.Initialize();
            Application.Run(new Home());
        }

        private static void PreloadDefaultKeyMappingProfiles()
        {
            string projectFolder = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;

            // Relative path to the DefaultKeyMappingProfiles folder
            string folderPath = Path.Combine(projectFolder, "DefaultKeyMappingProfiles");

            // Check if the folder exists
            if (Directory.Exists(folderPath))
            {
                // Get all .json files in the directory
                string[] jsonFiles = Directory.GetFiles(folderPath, "*.json");

                foreach (string filePath in jsonFiles)
                {
                    try
                    {
                        // Read the content of each JSON file
                        string jsonContent = File.ReadAllText(filePath);
                        KeyMappingProfile profile = KeyMappingProfile.FromJsonManual(jsonContent);
                        Program.KeyMappingProfiles.Add(profile); //Add the default profile to the Program

                        Debug.WriteLine($"Profile Name: {profile.Name}");
                        Debug.WriteLine($"Selected Activation Key: {profile.CurrentMappingsSelected.ActivationKey}");

                        if (profile.Name == "Default Profile: Touch Typist")
                        {
                            CurrentSelectedMappingProfile = profile; //By Default the activated KeyMappingProfile must be the Touch Typist
                        }

                        // Ensure that the 'CurrentActivationKeySelected' exists in the dictionary
                        if (profile.CurrentMappingsSelected != null)
                        {

                            // Iterate over the key mappings in this set
                            foreach (var mapping in profile.CurrentMappingsSelected.KeyMappings)
                            {
                                string values = string.Join(", ", mapping.Value);
                                Debug.WriteLine($"Key: {mapping.Key}, Value: {values}");
                            }
                        }
                        else
                        {
                            Debug.WriteLine($"No current key mappings was selected for the current profile selected.");
                        }

                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"Failed to read file: {Path.GetFileName(filePath)}. Error: {ex.Message}");
                    }
                }
            }
            else
            {
                Debug.WriteLine($"Directory not found: {folderPath}");
            }
        }
    }
}