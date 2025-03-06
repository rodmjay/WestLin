using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LinCityCS.RenderingUI
{
    /// <summary>
    /// Represents a panel UI element that can contain other UI elements.
    /// </summary>
    public class Panel : UIElement
    {
        private Texture2D texture;
        private Color backgroundColor;
        private List<UIElement> children;

        /// <summary>
        /// Initializes a new instance of the Panel class.
        /// </summary>
        /// <param name="position">The position of the panel.</param>
        /// <param name="size">The size of the panel.</param>
        /// <param name="texture">The texture of the panel.</param>
        /// <param name="backgroundColor">The background color of the panel.</param>
        public Panel(Vector2 position, Vector2 size, Texture2D texture, Color backgroundColor)
            : base(position, size)
        {
            this.texture = texture;
            this.backgroundColor = backgroundColor;
            children = new List<UIElement>();
        }

        /// <summary>
        /// Adds a child UI element to the panel.
        /// </summary>
        /// <param name="element">The UI element to add.</param>
        public void AddChild(UIElement element)
        {
            children.Add(element);
        }

        /// <summary>
        /// Removes a child UI element from the panel.
        /// </summary>
        /// <param name="element">The UI element to remove.</param>
        public void RemoveChild(UIElement element)
        {
            children.Remove(element);
        }

        /// <summary>
        /// Updates the panel and its children.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            if (!IsVisible)
            {
                return;
            }

            // Update children
            foreach (var child in children)
            {
                child.Update(gameTime);
            }
        }

        /// <summary>
        /// Draws the panel and its children.
        /// </summary>
        /// <param name="spriteBatch">The sprite batch to use for rendering.</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!IsVisible)
            {
                return;
            }

            // Draw the panel background
            if (texture != null)
            {
                spriteBatch.Draw(texture, new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y), backgroundColor);
            }
            else
            {
                // Draw a colored rectangle if no texture is provided
                Texture2D pixel = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
                pixel.SetData(new[] { Color.White });
                spriteBatch.Draw(pixel, new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y), backgroundColor);
            }

            // Draw children
            foreach (var child in children)
            {
                child.Draw(spriteBatch);
            }
        }
    }
}
