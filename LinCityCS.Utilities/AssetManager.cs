using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LinCityCS.Utilities
{
    /// <summary>
    /// Manages game assets.
    /// </summary>
    public class AssetManager
    {
        private ContentManager content;
        private Dictionary<string, Texture2D> textures;
        private Dictionary<string, SpriteFont> fonts;

        /// <summary>
        /// Initializes a new instance of the AssetManager class.
        /// </summary>
        /// <param name="content">The content manager.</param>
        public AssetManager(ContentManager content)
        {
            this.content = content;
            textures = new Dictionary<string, Texture2D>();
            fonts = new Dictionary<string, SpriteFont>();
        }

        /// <summary>
        /// Loads all game assets.
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
        /// Unloads all content.
        /// </summary>
        public void UnloadContent()
        {
            content.Unload();
            textures.Clear();
            fonts.Clear();
        }
    }
}
