using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace LinCityCS.Utilities
{
    /// <summary>
    /// Handles loading and managing game content.
    /// </summary>
    public class ContentLoader
    {
        private ContentManager content;
        private Dictionary<string, Texture2D> textures;
        private Dictionary<string, SpriteFont> fonts;
        private Dictionary<string, SoundEffect> sounds;

        /// <summary>
        /// Initializes a new instance of the ContentLoader class.
        /// </summary>
        /// <param name="content">The content manager.</param>
        public ContentLoader(ContentManager content)
        {
            this.content = content;
            textures = new Dictionary<string, Texture2D>();
            fonts = new Dictionary<string, SpriteFont>();
            sounds = new Dictionary<string, SoundEffect>();
        }

        /// <summary>
        /// Loads all game content.
        /// </summary>
        public void LoadContent()
        {
            // Load fonts
            LoadFont("MainFont", "Fonts/MainFont");

            // Load building textures
            LoadTexture("ResidenceLL", "Textures/Buildings/residence_ll");
            LoadTexture("ResidenceML", "Textures/Buildings/residence_ml");
            LoadTexture("ResidenceHL", "Textures/Buildings/residence_hl");
            LoadTexture("PowerCoal", "Textures/Buildings/power_coal");
            LoadTexture("PowerSolar", "Textures/Buildings/power_solar");
            LoadTexture("PowerWind", "Textures/Buildings/power_wind");
            LoadTexture("Market", "Textures/Buildings/market");
            LoadTexture("IndustryLight", "Textures/Buildings/industry_light");
            LoadTexture("IndustryHeavy", "Textures/Buildings/industry_heavy");
            LoadTexture("Road", "Textures/Buildings/road");

            // Load terrain textures
            LoadTexture("Grass", "Textures/Terrain/grass");
            LoadTexture("Water", "Textures/Terrain/water");

            // Load UI textures
            LoadTexture("Button", "Textures/UI/button");
            LoadTexture("Panel", "Textures/UI/panel");

            // Load sounds
            LoadSound("Build", "Sounds/build");
            LoadSound("Bulldoze", "Sounds/bulldoze");
            LoadSound("Click", "Sounds/click");
            LoadSound("Error", "Sounds/error");
        }

        /// <summary>
        /// Loads a texture.
        /// </summary>
        /// <param name="name">The name of the texture.</param>
        /// <param name="path">The path to the texture.</param>
        private void LoadTexture(string name, string path)
        {
            try
            {
                textures[name] = content.Load<Texture2D>(path);
            }
            catch (Exception ex)
            {
                Logger.Log($"Failed to load texture {name} from {path}: {ex.Message}");
            }
        }

        /// <summary>
        /// Loads a font.
        /// </summary>
        /// <param name="name">The name of the font.</param>
        /// <param name="path">The path to the font.</param>
        private void LoadFont(string name, string path)
        {
            try
            {
                fonts[name] = content.Load<SpriteFont>(path);
            }
            catch (Exception ex)
            {
                Logger.Log($"Failed to load font {name} from {path}: {ex.Message}");
            }
        }

        /// <summary>
        /// Loads a sound.
        /// </summary>
        /// <param name="name">The name of the sound.</param>
        /// <param name="path">The path to the sound.</param>
        private void LoadSound(string name, string path)
        {
            try
            {
                sounds[name] = content.Load<SoundEffect>(path);
            }
            catch (Exception ex)
            {
                Logger.Log($"Failed to load sound {name} from {path}: {ex.Message}");
            }
        }

        /// <summary>
        /// Gets a texture.
        /// </summary>
        /// <param name="name">The name of the texture.</param>
        /// <returns>The texture.</returns>
        public Texture2D GetTexture(string name)
        {
            if (textures.TryGetValue(name, out Texture2D texture))
            {
                return texture;
            }

            Logger.Log($"Texture {name} not found.");
            return null;
        }

        /// <summary>
        /// Gets a font.
        /// </summary>
        /// <param name="name">The name of the font.</param>
        /// <returns>The font.</returns>
        public SpriteFont GetFont(string name)
        {
            if (fonts.TryGetValue(name, out SpriteFont font))
            {
                return font;
            }

            Logger.Log($"Font {name} not found.");
            return null;
        }

        /// <summary>
        /// Gets a sound.
        /// </summary>
        /// <param name="name">The name of the sound.</param>
        /// <returns>The sound.</returns>
        public SoundEffect GetSound(string name)
        {
            if (sounds.TryGetValue(name, out SoundEffect sound))
            {
                return sound;
            }

            Logger.Log($"Sound {name} not found.");
            return null;
        }

        /// <summary>
        /// Plays a sound.
        /// </summary>
        /// <param name="name">The name of the sound.</param>
        public void PlaySound(string name)
        {
            SoundEffect sound = GetSound(name);
            if (sound != null)
            {
                sound.Play();
            }
        }

        /// <summary>
        /// Unloads all content.
        /// </summary>
        public void UnloadContent()
        {
            content.Unload();
            textures.Clear();
            fonts.Clear();
            sounds.Clear();
        }
    }
}
