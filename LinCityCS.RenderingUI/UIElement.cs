using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LinCityCS.RenderingUI
{
    /// <summary>
    /// Base class for UI elements.
    /// </summary>
    public abstract class UIElement
    {
        private Vector2 position;
        private Vector2 size;
        private bool isVisible;

        /// <summary>
        /// Gets or sets the position of the UI element.
        /// </summary>
        public Vector2 Position
        {
            get => position;
            set => position = value;
        }

        /// <summary>
        /// Gets or sets the size of the UI element.
        /// </summary>
        public Vector2 Size
        {
            get => size;
            set => size = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the UI element is visible.
        /// </summary>
        public bool IsVisible
        {
            get => isVisible;
            set => isVisible = value;
        }

        /// <summary>
        /// Initializes a new instance of the UIElement class.
        /// </summary>
        /// <param name="position">The position of the UI element.</param>
        /// <param name="size">The size of the UI element.</param>
        public UIElement(Vector2 position, Vector2 size)
        {
            this.position = position;
            this.size = size;
            isVisible = true;
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
        /// Checks if the UI element contains the specified point.
        /// </summary>
        /// <param name="point">The point to check.</param>
        /// <returns>True if the UI element contains the point, false otherwise.</returns>
        public bool Contains(Point point)
        {
            return new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y).Contains(point);
        }
    }
}
