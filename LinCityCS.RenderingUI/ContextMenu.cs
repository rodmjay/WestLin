using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LinCityCS.RenderingUI
{
    /// <summary>
    /// Represents a context menu that appears when right-clicking on a tile.
    /// </summary>
    public class ContextMenu : Panel
    {
        private List<MenuItem> menuItems;
        private bool isVisible;
        private Vector2 targetPosition;

        /// <summary>
        /// Initializes a new instance of the ContextMenu class.
        /// </summary>
        /// <param name="position">The position of the context menu.</param>
        /// <param name="size">The size of the context menu.</param>
        /// <param name="texture">The texture of the context menu.</param>
        /// <param name="backgroundColor">The background color of the context menu.</param>
        public ContextMenu(Vector2 position, Vector2 size, Texture2D texture, Color backgroundColor)
            : base(position, size, texture, backgroundColor)
        {
            menuItems = new List<MenuItem>();
            isVisible = false;
            targetPosition = position;
            IsVisible = false;
        }

        /// <summary>
        /// Shows the context menu at the specified position.
        /// </summary>
        /// <param name="position">The position to show the context menu at.</param>
        public void Show(Vector2 position)
        {
            targetPosition = position;
            Position = position;
            isVisible = true;
            IsVisible = true;
        }

        /// <summary>
        /// Hides the context menu.
        /// </summary>
        public void Hide()
        {
            isVisible = false;
            IsVisible = false;
        }

        /// <summary>
        /// Adds a menu item to the context menu.
        /// </summary>
        /// <param name="text">The text of the menu item.</param>
        /// <param name="action">The action to perform when the menu item is clicked.</param>
        /// <param name="font">The font for the menu item text.</param>
        public void AddMenuItem(string text, Action action, SpriteFont font)
        {
            MenuItem menuItem = new MenuItem(
                new Vector2(Position.X, Position.Y + menuItems.Count * 20),
                new Vector2(Size.X, 20),
                text,
                action,
                font
            );
            
            menuItems.Add(menuItem);
            AddChild(menuItem);
        }

        /// <summary>
        /// Updates the context menu.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            if (!isVisible)
            {
                return;
            }

            // Update menu item positions
            for (int i = 0; i < menuItems.Count; i++)
            {
                menuItems[i].Position = new Vector2(targetPosition.X, targetPosition.Y + i * 20);
            }
            
            // Check if the user clicked outside the menu
            MouseState mouseState = Mouse.GetState();
            Point mousePosition = new Point(mouseState.X, mouseState.Y);
            
            if (mouseState.LeftButton == ButtonState.Pressed && !Contains(mousePosition))
            {
                Hide();
            }
            
            base.Update(gameTime);
        }

        /// <summary>
        /// Represents a menu item in a context menu.
        /// </summary>
        private class MenuItem : UIElement
        {
            private string text;
            private Action action;
            private SpriteFont font;
            private bool isHovered;

            /// <summary>
            /// Initializes a new instance of the MenuItem class.
            /// </summary>
            /// <param name="position">The position of the menu item.</param>
            /// <param name="size">The size of the menu item.</param>
            /// <param name="text">The text of the menu item.</param>
            /// <param name="action">The action to perform when the menu item is clicked.</param>
            /// <param name="font">The font for the menu item text.</param>
            public MenuItem(Vector2 position, Vector2 size, string text, Action action, SpriteFont font)
                : base(position, size)
            {
                this.text = text;
                this.action = action;
                this.font = font;
                isHovered = false;
            }

            /// <summary>
            /// Updates the menu item.
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
                
                // Check if the mouse is hovering over the menu item
                isHovered = Contains(mousePosition);
                
                // Check if the menu item is clicked
                if (isHovered && mouseState.LeftButton == ButtonState.Pressed)
                {
                    action?.Invoke();
                }
            }

            /// <summary>
            /// Draws the menu item.
            /// </summary>
            /// <param name="spriteBatch">The sprite batch to use for rendering.</param>
            public override void Draw(SpriteBatch spriteBatch)
            {
                if (!IsVisible)
                {
                    return;
                }

                // Draw the menu item background
                Texture2D pixel = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
                pixel.SetData(new[] { Color.White });
                spriteBatch.Draw(pixel, new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y), isHovered ? Color.Gray : Color.DarkGray);
                
                // Draw the menu item text
                if (font != null)
                {
                    spriteBatch.DrawString(font, text, new Vector2(Position.X + 5, Position.Y + 2), Color.White);
                }
            }
        }
    }
}
