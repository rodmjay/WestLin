using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using LinCityCS.SimulationCore;
using LinCityCS.Utilities;

namespace LinCityCS.RenderingUI
{
    /// <summary>
    /// Main game class that coordinates rendering, input, and simulation.
    /// </summary>
    public class LinCityGame : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private World world;
        private SimulationEngine engine;
        private GameEngine gameEngine;
        private Camera camera;
        private InputManager inputManager;
        private UIManager uiManager;
        private SpriteFont font;

        /// <summary>
        /// Initializes a new instance of the LinCityGame class.
        /// </summary>
        public LinCityGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        /// <summary>
        /// Initializes the game.
        /// </summary>
        protected override void Initialize()
        {
            // Initialize logger
            Logger.Initialize("LinCityCS.log");
            Logger.Info("Initializing game");
            
            // Load settings
            GameSettings settings = GameSettings.Instance;
            
            // Set up window size
            graphics.PreferredBackBufferWidth = settings.GetSetting("ScreenWidth", 1280);
            graphics.PreferredBackBufferHeight = settings.GetSetting("ScreenHeight", 720);
            graphics.IsFullScreen = settings.GetSetting("Fullscreen", false);
            graphics.ApplyChanges();

            // Create world and engine
            world = new World(100); // 100x100 world
            engine = new SimulationEngine(world);
            gameEngine = new GameEngine(world.Len());
            gameEngine.Initialize();

            // Create camera
            camera = new Camera(GraphicsDevice.Viewport);

            base.Initialize();
        }

        /// <summary>
        /// Loads game content.
        /// </summary>
        protected override void LoadContent()
        {
            Logger.Info("Loading content");
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            // Create content loader
            ContentLoader contentLoader = new ContentLoader(Content, GraphicsDevice);
            
            // Load font
            try
            {
                font = contentLoader.LoadFont("Font");
                if (font == null)
                {
                    Logger.Warning("Font not found in content. Creating placeholder font.");
                    // Create a placeholder font texture
                    Texture2D fontTexture = contentLoader.CreateSolidColorTexture(Color.White);
                }
            }
            catch (Exception ex)
            {
                Logger.Error($"Error loading font: {ex.Message}");
            }
            
            // Create input manager
            inputManager = new InputManager(this, engine, world, camera);
            
            // Create UI manager
            uiManager = new UIManager(spriteBatch, font, engine, world, inputManager, GraphicsDevice);
            uiManager.LoadContent(Content);
            
            Logger.Info("Content loaded successfully");
        }

        /// <summary>
        /// Updates the game.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            try
            {
                // Handle input
                inputManager.Update(gameTime);
                
                // Update UI
                uiManager.Update(gameTime);
                
                // Update simulation
                if (!engine.IsPaused)
                {
                    // Calculate how many simulation steps to perform based on simulation speed
                    int steps = engine.SimulationSpeed;
                    for (int i = 0; i < steps; i++)
                    {
                        engine.DoSimStep();
                    }
                    
                    // Animate only once per frame regardless of simulation speed
                    engine.DoAnimate();
                }
                
                base.Update(gameTime);
            }
            catch (Exception ex)
            {
                Logger.Error($"Error in Update: {ex.Message}\n{ex.StackTrace}");
            }
        }

        /// <summary>
        /// Draws the game.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            try
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);
                
                // Begin sprite batch with camera transformation
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, camera.Transform);
                
                // Render the world
                RenderWorld();
                
                // End sprite batch
                spriteBatch.End();
                
                // Draw UI
                uiManager.Draw();
                
                base.Draw(gameTime);
            }
            catch (Exception ex)
            {
                Logger.Error($"Error in Draw: {ex.Message}\n{ex.StackTrace}");
            }
        }

        /// <summary>
        /// Renders the world.
        /// </summary>
        private void RenderWorld()
        {
            // Calculate visible tiles based on camera position and viewport
            Vector2 cameraPosition = camera.Position;
            Rectangle viewport = GraphicsDevice.Viewport.Bounds;
            int tileSize = 32; // Default tile size in pixels
            
            int startX = Math.Max(0, (int)((cameraPosition.X - viewport.Width / 2) / tileSize));
            int startY = Math.Max(0, (int)((cameraPosition.Y - viewport.Height / 2) / tileSize));
            int endX = Math.Min(world.Len() - 1, (int)((cameraPosition.X + viewport.Width / 2) / tileSize));
            int endY = Math.Min(world.Len() - 1, (int)((cameraPosition.Y + viewport.Height / 2) / tileSize));
            
            // Render visible tiles
            for (int y = startY; y <= endY; y++)
            {
                for (int x = startX; x <= endX; x++)
                {
                    RenderTile(x, y);
                }
            }
        }

        /// <summary>
        /// Renders a tile.
        /// </summary>
        /// <param name="x">The x-coordinate of the tile.</param>
        /// <param name="y">The y-coordinate of the tile.</param>
        private void RenderTile(int x, int y)
        {
            MapTile tile = world[x, y];
            int tileSize = 32; // Default tile size in pixels
            
            // Get the texture for the tile
            Texture2D texture = GetTextureForTile(tile);
            
            // Calculate the position of the tile
            Vector2 position = new Vector2(x * tileSize, y * tileSize);
            
            // Draw the tile
            if (texture != null)
            {
                spriteBatch.Draw(texture, position, Color.White);
            }
            else
            {
                // Draw a placeholder colored rectangle for now
                Texture2D pixel = new Texture2D(GraphicsDevice, 1, 1);
                pixel.SetData(new[] { Color.Green }); // Default color for empty tiles
                spriteBatch.Draw(pixel, new Rectangle((int)position.X, (int)position.Y, tileSize, tileSize), Color.White);
            }
            
            // Draw any extra frames
            foreach (var frame in tile.Frames)
            {
                if (frame.Frame >= 0 && frame.ResourceGroup != null)
                {
                    Texture2D frameTexture = GetTextureForFrame(frame);
                    if (frameTexture != null)
                    {
                        Vector2 framePosition = position + new Vector2(frame.MoveX, frame.MoveY);
                        spriteBatch.Draw(frameTexture, framePosition, Color.White);
                    }
                }
            }
        }

        /// <summary>
        /// Gets the texture for a tile.
        /// </summary>
        /// <param name="tile">The tile to get the texture for.</param>
        /// <returns>The texture for the tile.</returns>
        private Texture2D GetTextureForTile(MapTile tile)
        {
            // This would be implemented based on the C++ logic
            // For now, just a placeholder
            return null;
        }

        /// <summary>
        /// Gets the texture for a frame.
        /// </summary>
        /// <param name="frame">The frame to get the texture for.</param>
        /// <returns>The texture for the frame.</returns>
        private Texture2D GetTextureForFrame(ExtraFrame frame)
        {
            // This would be implemented based on the C++ logic
            // For now, just a placeholder
            return null;
        }
    }
}
