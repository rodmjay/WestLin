using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LinCityCS.RenderingUI
{
    /// <summary>
    /// Represents a slider UI element.
    /// </summary>
    public class Slider : UIElement
    {
        private Texture2D trackTexture;
        private Texture2D thumbTexture;
        private float minValue;
        private float maxValue;
        private float value;
        private bool isDragging;
        private Action<float> onValueChanged;

        /// <summary>
        /// Gets or sets the value of the slider.
        /// </summary>
        public float Value
        {
            get => value;
            set
            {
                this.value = MathHelper.Clamp(value, minValue, maxValue);
                onValueChanged?.Invoke(this.value);
            }
        }

        /// <summary>
        /// Initializes a new instance of the Slider class.
        /// </summary>
        /// <param name="position">The position of the slider.</param>
        /// <param name="size">The size of the slider.</param>
        /// <param name="trackTexture">The texture of the slider track.</param>
        /// <param name="thumbTexture">The texture of the slider thumb.</param>
        /// <param name="minValue">The minimum value of the slider.</param>
        /// <param name="maxValue">The maximum value of the slider.</param>
        /// <param name="initialValue">The initial value of the slider.</param>
        /// <param name="onValueChanged">The action to perform when the slider value changes.</param>
        public Slider(Vector2 position, Vector2 size, Texture2D trackTexture, Texture2D thumbTexture, float minValue, float maxValue, float initialValue, Action<float> onValueChanged)
            : base(position, size)
        {
            this.trackTexture = trackTexture;
            this.thumbTexture = thumbTexture;
            this.minValue = minValue;
            this.maxValue = maxValue;
            this.value = MathHelper.Clamp(initialValue, minValue, maxValue);
            this.onValueChanged = onValueChanged;
            isDragging = false;
        }

        /// <summary>
        /// Updates the slider.
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

            // Check if the mouse is over the thumb
            Rectangle thumbRect = GetThumbRectangle();
            bool isOverThumb = thumbRect.Contains(mousePosition);

            // Handle mouse input
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                if (isOverThumb || isDragging)
                {
                    isDragging = true;
                    
                    // Calculate the new value based on the mouse position
                    float normalizedPosition = MathHelper.Clamp((mousePosition.X - Position.X) / Size.X, 0, 1);
                    Value = minValue + normalizedPosition * (maxValue - minValue);
                }
                else if (Contains(mousePosition))
                {
                    // Clicked on the track, move the thumb to that position
                    float normalizedPosition = MathHelper.Clamp((mousePosition.X - Position.X) / Size.X, 0, 1);
                    Value = minValue + normalizedPosition * (maxValue - minValue);
                }
            }
            else
            {
                isDragging = false;
            }
        }

        /// <summary>
        /// Draws the slider.
        /// </summary>
        /// <param name="spriteBatch">The sprite batch to use for rendering.</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!IsVisible)
            {
                return;
            }

            // Draw the track
            if (trackTexture != null)
            {
                spriteBatch.Draw(trackTexture, new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y), Color.White);
            }
            else
            {
                // Draw a colored rectangle if no texture is provided
                Texture2D pixel = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
                pixel.SetData(new[] { Color.White });
                spriteBatch.Draw(pixel, new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y), Color.Gray);
            }

            // Draw the thumb
            Rectangle thumbRect = GetThumbRectangle();
            if (thumbTexture != null)
            {
                spriteBatch.Draw(thumbTexture, thumbRect, Color.White);
            }
            else
            {
                // Draw a colored rectangle if no texture is provided
                Texture2D pixel = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
                pixel.SetData(new[] { Color.White });
                spriteBatch.Draw(pixel, thumbRect, Color.White);
            }
        }

        /// <summary>
        /// Gets the rectangle for the thumb.
        /// </summary>
        /// <returns>The rectangle for the thumb.</returns>
        private Rectangle GetThumbRectangle()
        {
            float normalizedValue = (value - minValue) / (maxValue - minValue);
            int thumbX = (int)(Position.X + normalizedValue * Size.X - 10); // Assuming 20x20 thumb
            int thumbY = (int)(Position.Y + Size.Y / 2 - 10);
            return new Rectangle(thumbX, thumbY, 20, 20);
        }
    }
}
