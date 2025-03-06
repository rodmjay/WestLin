using System;

namespace LinCityCS.SimulationCore
{
    /// <summary>
    /// Represents the game world.
    /// </summary>
    public class World
    {
        private MapTile[,] tiles;

        /// <summary>
        /// Gets the width of the world.
        /// </summary>
        public int Width { get; private set; }

        /// <summary>
        /// Gets the height of the world.
        /// </summary>
        public int Height { get; private set; }

        /// <summary>
        /// Gets the tiles in the world.
        /// </summary>
        public MapTile[,] Tiles => tiles;

        /// <summary>
        /// Initializes a new instance of the World class.
        /// </summary>
        /// <param name="width">The width of the world.</param>
        /// <param name="height">The height of the world.</param>
        public World(int width, int height)
        {
            Width = width;
            Height = height;
            tiles = new MapTile[width, height];

            // Initialize tiles
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    tiles[x, y] = new MapTile(x, y);
                }
            }
        }

        /// <summary>
        /// Checks if the specified coordinates are inside the world.
        /// </summary>
        /// <param name="x">The x-coordinate.</param>
        /// <param name="y">The y-coordinate.</param>
        /// <returns>True if the coordinates are inside the world, false otherwise.</returns>
        public bool IsInside(int x, int y)
        {
            return x >= 0 && x < Width && y >= 0 && y < Height;
        }

        /// <summary>
        /// Gets the tile at the specified coordinates.
        /// </summary>
        /// <param name="x">The x-coordinate.</param>
        /// <param name="y">The y-coordinate.</param>
        /// <returns>The tile at the specified coordinates.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the coordinates are outside the world.</exception>
        public MapTile GetTile(int x, int y)
        {
            if (!IsInside(x, y))
            {
                throw new ArgumentOutOfRangeException($"Coordinates ({x}, {y}) are outside the world.");
            }

            return tiles[x, y];
        }
    }
}
