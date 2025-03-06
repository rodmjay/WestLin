using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace LinCityCS.Utilities
{
    /// <summary>
    /// Manages game settings.
    /// </summary>
    public class GameSettings
    {
        private static GameSettings instance;
        private Dictionary<string, object> settings;
        private string settingsFilePath;

        /// <summary>
        /// Gets the instance of the GameSettings class.
        /// </summary>
        public static GameSettings Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameSettings();
                }
                return instance;
            }
        }

        /// <summary>
        /// Initializes a new instance of the GameSettings class.
        /// </summary>
        private GameSettings()
        {
            settings = new Dictionary<string, object>();
            settingsFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "LinCityCS", "settings.json");
            LoadSettings();
        }

        /// <summary>
        /// Loads settings from the settings file.
        /// </summary>
        public void LoadSettings()
        {
            try
            {
                if (File.Exists(settingsFilePath))
                {
                    string json = File.ReadAllText(settingsFilePath);
                    settings = JsonSerializer.Deserialize<Dictionary<string, object>>(json);
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
                    SaveSettings();
                }
            }
            catch (Exception ex)
            {
                Logger.Error($"Error loading settings: {ex.Message}");
                
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
            }
        }

        /// <summary>
        /// Saves settings to the settings file.
        /// </summary>
        public void SaveSettings()
        {
            try
            {
                string directory = Path.GetDirectoryName(settingsFilePath);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                string json = JsonSerializer.Serialize(settings, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(settingsFilePath, json);
            }
            catch (Exception ex)
            {
                Logger.Error($"Error saving settings: {ex.Message}");
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
