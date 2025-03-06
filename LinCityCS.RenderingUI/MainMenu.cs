using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LinCityCS.RenderingUI
{
    /// <summary>
    /// Represents the main menu of the game.
    /// </summary>
    public class MainMenu : Panel
    {
        private SpriteFont font;
        private SettingsPanel settingsPanel;
        private Button newGameButton;
        private Button loadGameButton;
        private Button settingsButton;
        private Button exitButton;
        private Label titleLabel;

        /// <summary>
        /// Initializes a new instance of the MainMenu class.
        /// </summary>
        /// <param name="position">The position of the main menu.</param>
        /// <param name="size">The size of the main menu.</param>
        /// <param name="texture">The texture of the main menu.</param>
        /// <param name="backgroundColor">The background color of the main menu.</param>
        /// <param name="font">The font for labels and buttons.</param>
        /// <param name="settingsPanel">The settings panel to show when the settings button is clicked.</param>
        /// <param name="graphicsDevice">The graphics device to use for rendering.</param>
        public MainMenu(Vector2 position, Vector2 size, Texture2D texture, Color backgroundColor, SpriteFont font, SettingsPanel settingsPanel, GraphicsDevice graphicsDevice)
            : base(position, size, texture, backgroundColor)
        {
            this.font = font;
            this.settingsPanel = settingsPanel;

            // Create title label
            titleLabel = new Label(new Vector2(position.X + size.X / 2 - 100, position.Y + 50), font, "LinCity CS", Color.White);
            AddChild(titleLabel);

            // Create button textures
            Texture2D buttonTexture = new Texture2D(graphicsDevice, 1, 1);
            buttonTexture.SetData(new[] { Color.DarkGray });
            Texture2D buttonHoverTexture = new Texture2D(graphicsDevice, 1, 1);
            buttonHoverTexture.SetData(new[] { Color.Gray });

            // Create new game button
            newGameButton = new Button(
                new Vector2(position.X + size.X / 2 - 75, position.Y + 150),
                new Vector2(150, 40),
                buttonTexture,
                buttonHoverTexture,
                font,
                "New Game",
                Color.White,
                () => IsVisible = false
            );
            AddChild(newGameButton);

            // Create load game button
            loadGameButton = new Button(
                new Vector2(position.X + size.X / 2 - 75, position.Y + 200),
                new Vector2(150, 40),
                buttonTexture,
                buttonHoverTexture,
                font,
                "Load Game",
                Color.White,
                () => { /* Load game logic */ }
            );
            AddChild(loadGameButton);

            // Create settings button
            settingsButton = new Button(
                new Vector2(position.X + size.X / 2 - 75, position.Y + 250),
                new Vector2(150, 40),
                buttonTexture,
                buttonHoverTexture,
                font,
                "Settings",
                Color.White,
                () => settingsPanel.Show()
            );
            AddChild(settingsButton);

            // Create exit button
            exitButton = new Button(
                new Vector2(position.X + size.X / 2 - 75, position.Y + 300),
                new Vector2(150, 40),
                buttonTexture,
                buttonHoverTexture,
                font,
                "Exit",
                Color.White,
                () => Environment.Exit(0)
            );
            AddChild(exitButton);
        }
    }
}
