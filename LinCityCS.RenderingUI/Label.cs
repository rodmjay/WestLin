using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LinCityCS.RenderingUI
{
    /// <summary>
    /// Represents a label UI element.
    /// </summary>
    public class Label : UIElement
    {
        private SpriteFont font;
        private string text;
        private Color textColor;

        /// <summary>
        /// Gets or sets the text of the label.
        /// </summary>
        public string Text
        {
            get => text;
            set => text = value;
        }

        /// <summary>
        /// Gets or sets the color of the label text.
        /// </summary>
        public Color TextColor
        {
            get => textColor;
            set => textColor = value;
        }

        /// <summary>
        /// Initializes a new instance of the Label class.
        /// </summary>
        /// <param name="position">The position of the label.</param>
        /// <param name="font">The font for the label text.</param>
        /// <param name="text">The text of the label.</param>
        /// <param name="textColor">The color of the label text.</param>
        public Label(Vector2 position, SpriteFont font, string text, Color textColor)
            : base(position, font != null ? font.MeasureString(text) : Vector2.Zero)
        {
            this.font = font;
            this.text = text;
            this.textColor = textColor;
        }

        /// <summary>
        /// Updates the label.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // Labels don't need to be updated
        }

        /// <summary>
        /// Draws the label.
        /// </summary>
        /// <param name="spriteBatch">The sprite batch to use for rendering.</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!IsVisible || font == null || string.IsNullOrEmpty(text))
            {
                return;
            }

            spriteBatch.DrawString(font, text, Position, textColor);
        }
    }
}
