using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LinCityCS.SimulationCore;

namespace LinCityCS.RenderingUI
{
    /// <summary>
    /// Manages the user interface for the game.
    /// </summary>
    public class UIManager
    {
        private SpriteBatch spriteBatch;
        private SpriteFont font;
        private SimulationEngine engine;
        private World world;
        private InputManager inputManager;
        private List<UIElement> uiElements;
        private Dictionary<string, Texture2D> uiTextures;

        /// <summary>
        /// Initializes a new instance of the UIManager class.
        /// </summary>
        /// <param name="spriteBatch">The sprite batch to use for rendering.</param>
        /// <param name="font">The font to use for text.</param>
        /// <param name="engine">The simulation engine.</param>
        /// <param name="world">The world.</param>
        /// <param name="inputManager">The input manager.</param>
        /// <param name="graphicsDevice">The graphics device to use for rendering.</param>
        public UIManager(SpriteBatch spriteBatch, SpriteFont font, SimulationEngine engine, World world, InputManager inputManager, GraphicsDevice graphicsDevice)
        {
            this.spriteBatch = spriteBatch;
            this.font = font;
            this.engine = engine;
            this.world = world;
            this.inputManager = inputManager;
            uiElements = new List<UIElement>();
            uiTextures = new Dictionary<string, Texture2D>();
            
            // Create UI elements
            InitializeUI(graphicsDevice);
        }
        
        /// <summary>
        /// Initializes the UI elements.
        /// </summary>
        /// <param name="graphicsDevice">The graphics device to use for rendering.</param>
        private void InitializeUI(GraphicsDevice graphicsDevice)
        {
            // Create panel textures
            Texture2D panelTexture = new Texture2D(graphicsDevice, 1, 1);
            panelTexture.SetData(new[] { Color.White });
            
            // Create status panel
            StatusPanel statusPanel = new StatusPanel(
                new Vector2(10, 10),
                new Vector2(200, 150),
                panelTexture,
                new Color(0, 0, 0, 128),
                engine,
                font
            );
            AddElement(statusPanel);
            
            // Create mini-map
            MiniMap miniMap = new MiniMap(
                new Vector2(10, 170),
                new Vector2(200, 200),
                world,
                camera,
                graphicsDevice
            );
            AddElement(miniMap);
            
            // Create toolbar panel
            ToolbarPanel toolbarPanel = new ToolbarPanel(
                new Vector2(10, 380),
                new Vector2(200, 300),
                panelTexture,
                new Color(0, 0, 0, 128),
                inputManager,
                font
            );
            AddElement(toolbarPanel);
            
            // Create context menu
            ContextMenu contextMenu = new ContextMenu(
                Vector2.Zero,
                new Vector2(150, 100),
                panelTexture,
                new Color(0, 0, 0, 192)
            );
            AddElement(contextMenu);
            inputManager.SetContextMenu(contextMenu);
            
            // Create info panel
            InfoPanel infoPanel = new InfoPanel(
                new Vector2(graphicsDevice.Viewport.Width - 210, 10),
                new Vector2(200, 150),
                panelTexture,
                new Color(0, 0, 0, 128),
                world,
                font,
                graphicsDevice
            );
            AddElement(infoPanel);
            
            // Create settings panel
            ConfigManager configManager = new ConfigManager("config.json");
            SettingsPanel settingsPanel = new SettingsPanel(
                new Vector2(graphicsDevice.Viewport.Width / 2 - 150, graphicsDevice.Viewport.Height / 2 - 150),
                new Vector2(300, 300),
                panelTexture,
                new Color(0, 0, 0, 192),
                engine,
                configManager,
                font,
                graphicsDevice
            );
            AddElement(settingsPanel);
            
            // Create main menu
            MainMenu mainMenu = new MainMenu(
                new Vector2(graphicsDevice.Viewport.Width / 2 - 200, graphicsDevice.Viewport.Height / 2 - 200),
                new Vector2(400, 400),
                panelTexture,
                new Color(0, 0, 0, 192),
                font,
                settingsPanel,
                graphicsDevice
            );
            AddElement(mainMenu);
            
            // Register UI elements with input manager
            foreach (var element in uiElements)
            {
                inputManager.AddUIElement(element);
            }
        }

        /// <summary>
        /// Loads UI content.
        /// </summary>
        /// <param name="content">The content manager.</param>
        public void LoadContent(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            // Load UI textures
            // This would be implemented based on the C++ logic
            // For now, just a placeholder
        }

        /// <summary>
        /// Updates the UI.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public void Update(GameTime gameTime)
        {
            // Update UI elements
            foreach (var element in uiElements)
            {
                element.Update(gameTime);
            }
        }

        /// <summary>
        /// Draws the UI.
        /// </summary>
        public void Draw()
        {
            // Begin sprite batch
            spriteBatch.Begin();

            // Draw UI elements
            foreach (var element in uiElements)
            {
                element.Draw(spriteBatch);
            }

            // Draw status information
            DrawStatusInfo();

            // End sprite batch
            spriteBatch.End();
        }

        /// <summary>
        /// Draws status information.
        /// </summary>
        private void DrawStatusInfo()
        {
            // Draw simulation time
            string timeText = $"Year: {engine.Economy.Year} Month: {engine.Economy.Month}";
            spriteBatch.DrawString(font, timeText, new Vector2(10, 10), Color.White);

            // Draw money
            string moneyText = $"Money: {engine.Economy.Money}";
            spriteBatch.DrawString(font, moneyText, new Vector2(10, 30), Color.White);

            // Draw population
            string populationText = $"Population: {engine.Economy.Population}";
            spriteBatch.DrawString(font, populationText, new Vector2(10, 50), Color.White);

            // Draw tech level
            string techLevelText = $"Tech Level: {engine.Economy.TechLevel}";
            spriteBatch.DrawString(font, techLevelText, new Vector2(10, 70), Color.White);

            // Draw simulation speed
            string speedText = $"Speed: {engine.SimulationSpeed}x";
            spriteBatch.DrawString(font, speedText, new Vector2(10, 90), Color.White);

            // Draw pause status
            string pauseText = engine.IsPaused ? "PAUSED" : "RUNNING";
            spriteBatch.DrawString(font, pauseText, new Vector2(10, 110), engine.IsPaused ? Color.Red : Color.Green);
        }

        /// <summary>
        /// Adds a UI element.
        /// </summary>
        /// <param name="element">The UI element to add.</param>
        public void AddElement(UIElement element)
        {
            uiElements.Add(element);
        }

        /// <summary>
        /// Removes a UI element.
        /// </summary>
        /// <param name="element">The UI element to remove.</param>
        public void RemoveElement(UIElement element)
        {
            uiElements.Remove(element);
        }
    }

    /// <summary>
    /// Base class for UI elements.
    /// </summary>
    public abstract class UIElement
    {
        /// <summary>
        /// The position of the UI element.
        /// </summary>
        public Vector2 Position { get; set; }

        /// <summary>
        /// The size of the UI element.
        /// </summary>
        public Vector2 Size { get; set; }

        /// <summary>
        /// Indicates whether the UI element is visible.
        /// </summary>
        public bool IsVisible { get; set; }

        /// <summary>
        /// Initializes a new instance of the UIElement class.
        /// </summary>
        /// <param name="position">The position of the UI element.</param>
        /// <param name="size">The size of the UI element.</param>
        protected UIElement(Vector2 position, Vector2 size)
        {
            Position = position;
            Size = size;
            IsVisible = true;
        }

        /// <summary>
        /// Updates the UI element.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public abstract void Update(GameTime gameTime);

        /// <summary>
        /// Draws the UI element.
        /// </summary>
        /// <param name="spriteBatch">The sprite batch to use for rendering.</param>
        public abstract void Draw(SpriteBatch spriteBatch);

        /// <summary>
        /// Checks if a point is inside the UI element.
        /// </summary>
        /// <param name="point">The point to check.</param>
        /// <returns>True if the point is inside the UI element, false otherwise.</returns>
        public bool Contains(Point point)
        {
            return new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y).Contains(point);
        }
    }
}
