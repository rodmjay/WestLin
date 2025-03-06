using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using LinCityCS.SimulationCore;

namespace LinCityCS.RenderingUI
{
    /// <summary>
    /// Represents a mini-map of the game world.
    /// </summary>
    public class MiniMap : UIElement
    {
        private World world;
        private Camera camera;
        private Texture2D mapTexture;
        private Color[] mapPixels;
        private bool isDragging;
        private Vector2 lastMousePosition;

        /// <summary>
        /// Initializes a new instance of the MiniMap class.
        /// </summary>
        /// <param name="position">The position of the mini-map.</param>
        /// <param name="size">The size of the mini-map.</param>
        /// <param name="world">The world to display.</param>
        /// <param name="camera">The camera to control.</param>
        /// <param name="graphicsDevice">The graphics device to use for rendering.</param>
        public MiniMap(Vector2 position, Vector2 size, World world, Camera camera, GraphicsDevice graphicsDevice)
            : base(position, size)
        {
            this.world = world;
            this.camera = camera;
            isDragging = false;
            
            // Create the map texture
            mapTexture = new Texture2D(graphicsDevice, world.Len(), world.Len());
            mapPixels = new Color[world.Len() * world.Len()];
            
            // Initialize the map pixels
            UpdateMapTexture();
        }

        /// <summary>
        /// Updates the mini-map.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            if (!IsVisible)
            {
                return;
            }

            // Update the map texture
            UpdateMapTexture();
            
            // Handle mouse input
            MouseState mouseState = Mouse.GetState();
            Point mousePosition = new Point(mouseState.X, mouseState.Y);
            
            if (Contains(mousePosition))
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    if (!isDragging)
                    {
                        isDragging = true;
                        lastMousePosition = mousePosition.ToVector2();
                    }
                    
                    // Move the camera based on the mini-map click
                    Vector2 mapPosition = mousePosition.ToVector2() - Position;
                    float worldX = mapPosition.X / Size.X * world.Len();
                    float worldY = mapPosition.Y / Size.Y * world.Len();
                    
                    // Set the camera position
                    camera.Position = new Vector2(worldX * 32, worldY * 32); // Assuming 32 pixel tiles
                }
                else
                {
                    isDragging = false;
                }
            }
            else
            {
                isDragging = false;
            }
            
            lastMousePosition = mousePosition.ToVector2();
        }

        /// <summary>
        /// Draws the mini-map.
        /// </summary>
        /// <param name="spriteBatch">The sprite batch to use for rendering.</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!IsVisible)
            {
                return;
            }

            // Draw the map texture
            spriteBatch.Draw(mapTexture, new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y), Color.White);
            
            // Draw the camera viewport
            Rectangle viewport = new Rectangle(
                (int)(Position.X + camera.Position.X / (world.Len() * 32) * Size.X),
                (int)(Position.Y + camera.Position.Y / (world.Len() * 32) * Size.Y),
                (int)(Size.X * camera.Zoom),
                (int)(Size.Y * camera.Zoom)
            );
            
            // Draw a rectangle representing the camera viewport
            Texture2D pixel = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
            pixel.SetData(new[] { Color.White });
            spriteBatch.Draw(pixel, viewport, Color.White * 0.5f);
        }

        /// <summary>
        /// Updates the map texture based on the world state.
        /// </summary>
        private void UpdateMapTexture()
        {
            for (int y = 0; y < world.Len(); y++)
            {
                for (int x = 0; x < world.Len(); x++)
                {
                    MapTile tile = world[x, y];
                    
                    // Set the pixel color based on the tile type
                    Color color = GetColorForTile(tile);
                    mapPixels[y * world.Len() + x] = color;
                }
            }
            
            // Update the texture
            mapTexture.SetData(mapPixels);
        }

        /// <summary>
        /// Gets the color for a tile.
        /// </summary>
        /// <param name="tile">The tile to get the color for.</param>
        /// <returns>The color for the tile.</returns>
        private Color GetColorForTile(MapTile tile)
        {
            // This would be implemented based on the C++ logic
            // For now, just a placeholder
            if (tile.Construction != null)
            {
                // Use the construction color
                return new Color(tile.Construction.Group.Colour);
            }
            else if (tile.Ground != null)
            {
                // Use the ground color
                switch (tile.Ground.Type)
                {
                    case Ground.GroundType.Water:
                        return Color.Blue;
                    case Ground.GroundType.Desert:
                        return Color.Yellow;
                    case Ground.GroundType.Tree:
                        return Color.Green;
                    default:
                        return Color.Brown;
                }
            }
            
            return Color.Black;
        }
    }
}
