using System.Text.Json;

namespace LoftwareFixer
{
    public static class InitFile
    {
        // A function that takes a JSON string and a folder name and saves the file in a subfolder
        private static void SaveFile(string filePath)
        {

            // Parse the object to string
            string jsonString = JsonSerializer.Serialize(GetDefault());

            // Write the JSON string to the file
            File.WriteAllText(filePath, jsonString);
        }

        // A function that reads the settings.json file and returns a Setting object
        public static Setting ReadSettingsFile(string folderPath)
        {
            Setting? setting = null;

            // Create the subfolder if it doesn't exist
            Directory.CreateDirectory(folderPath);

            // Create the file path
            string filePath = GetPath(folderPath);

            if(File.Exists(filePath)) { 

                // Read the JSON string from the file
                string jsonString = File.ReadAllText(filePath);

                // Parse the JSON string to a Setting object
                setting = JsonSerializer.Deserialize<Setting>(jsonString);
            }
            else
            {
                SaveFile(filePath);
            }

            // Return the Setting object
            return setting ?? GetDefault();
        }

        // Generate a default object
        private static Setting GetDefault()
        {
            return new Setting
            {
                DelayTime = 5000,
                Path = "C:\\Users\\Public\\",
                AllowedFileType = new string[] { ".pass" }
            };
        }

        // Get file full path
        public static string GetPath(string folderPath)
        {
            return Path.Combine(folderPath, "settings.json");
        }
    }

    // Setting class for LoftwareFixer
    public class Setting
    {
        public string[]? AllowedFileType { set; get; }
        public int DelayTime { set; get; }
        public string? Path { set; get; }
    }
}
