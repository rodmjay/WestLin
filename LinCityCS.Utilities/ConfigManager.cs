using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace LinCityCS.Utilities
{
    /// <summary>
    /// Manages configuration settings for the game.
    /// </summary>
    public class ConfigManager
    {
        private Dictionary<string, object> settings;
        private string configFilePath;

        /// <summary>
        /// Initializes a new instance of the ConfigManager class.
        /// </summary>
        /// <param name="configFilePath">The path to the configuration file.</param>
        public ConfigManager(string configFilePath)
        {
            this.configFilePath = configFilePath;
            settings = new Dictionary<string, object>();
            LoadConfig();
        }

        /// <summary>
        /// Loads the configuration from the file.
        /// </summary>
        public void LoadConfig()
        {
            if (File.Exists(configFilePath))
            {
                try
                {
                    string json = File.ReadAllText(configFilePath);
                    settings = JsonSerializer.Deserialize<Dictionary<string, object>>(json);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading configuration: {ex.Message}");
                    settings = new Dictionary<string, object>();
                }
            }
            else
            {
                // Create default settings
                settings = new Dictionary<string, object>
                {
                    { "ScreenWidth", 1280 },
                    { "ScreenHeight", 720 },
                    { "Fullscreen", false },
                    { "MusicVolume", 0.5 },
                    { "SoundVolume", 0.7 },
                    { "WorldSize", 100 },
                    { "SimulationSpeed", 1 }
                };
                SaveConfig();
            }
        }

        /// <summary>
        /// Saves the configuration to the file.
        /// </summary>
        public void SaveConfig()
        {
            try
            {
                string json = JsonSerializer.Serialize(settings, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(configFilePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving configuration: {ex.Message}");
            }
        }

        /// <summary>
        /// Gets a setting value.
        /// </summary>
        /// <typeparam name="T">The type of the setting value.</typeparam>
        /// <param name="key">The key of the setting.</param>
        /// <param name="defaultValue">The default value to return if the setting is not found.</param>
        /// <returns>The setting value, or the default value if the setting is not found.</returns>
        public T GetSetting<T>(string key, T defaultValue)
        {
            if (settings.TryGetValue(key, out object value))
            {
                try
                {
                    return (T)Convert.ChangeType(value, typeof(T));
                }
                catch
                {
                    return defaultValue;
                }
            }
            return defaultValue;
        }

        /// <summary>
        /// Sets a setting value.
        /// </summary>
        /// <typeparam name="T">The type of the setting value.</typeparam>
        /// <param name="key">The key of the setting.</param>
        /// <param name="value">The value to set.</param>
        public void SetSetting<T>(string key, T value)
        {
            settings[key] = value;
        }
    }
}
