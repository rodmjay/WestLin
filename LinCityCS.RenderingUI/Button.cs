using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LinCityCS.RenderingUI
{
    /// <summary>
    /// Represents a button UI element.
    /// </summary>
    public class Button : UIElement
    {
        private Texture2D texture;
        private Texture2D hoverTexture;
        private SpriteFont font;
        private string text;
        private Color textColor;
        private bool isHovered;
        private Action onClick;

        /// <summary>
        /// Initializes a new instance of the Button class.
        /// </summary>
        /// <param name="position">The position of the button.</param>
        /// <param name="size">The size of the button.</param>
        /// <param name="texture">The texture of the button.</param>
        /// <param name="hoverTexture">The texture of the button when hovered.</param>
        /// <param name="font">The font for the button text.</param>
        /// <param name="text">The text of the button.</param>
        /// <param name="textColor">The color of the button text.</param>
        /// <param name="onClick">The action to perform when the button is clicked.</param>
        public Button(Vector2 position, Vector2 size, Texture2D texture, Texture2D hoverTexture, SpriteFont font, string text, Color textColor, Action onClick)
            : base(position, size)
        {
            this.texture = texture;
            this.hoverTexture = hoverTexture;
            this.font = font;
            this.text = text;
            this.textColor = textColor;
            this.onClick = onClick;
            isHovered = false;
        }

        /// <summary>
        /// Updates the button.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            if (!IsVisible)
            {
                return;
            }

            MouseState mouseState = Mouse.GetState();
            Point mousePosition = new Point(mouseState.X, mouseState.Y);

            // Check if the mouse is hovering over the button
            isHovered = Contains(mousePosition);

            // Check if the button is clicked
            if (isHovered && mouseState.LeftButton == ButtonState.Pressed)
            {
                onClick?.Invoke();
            }
        }

        /// <summary>
        /// Draws the button.
        /// </summary>
        /// <param name="spriteBatch">The sprite batch to use for rendering.</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!IsVisible)
            {
                return;
            }

            // Draw the button texture
            Texture2D currentTexture = isHovered ? (hoverTexture ?? texture) : texture;
            if (currentTexture != null)
            {
                spriteBatch.Draw(currentTexture, new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y), Color.White);
            }

            // Draw the button text
            if (font != null && !string.IsNullOrEmpty(text))
            {
                Vector2 textSize = font.MeasureString(text);
                Vector2 textPosition = new Vector2(
                    Position.X + (Size.X - textSize.X) / 2,
                    Position.Y + (Size.Y - textSize.Y) / 2
                );
                spriteBatch.DrawString(font, text, textPosition, textColor);
            }
        }
    }
}
