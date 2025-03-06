using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LinCityCS.SimulationCore;
using LinCityCS.Utilities;

namespace LinCityCS.RenderingUI
{
    /// <summary>
    /// Represents a settings panel for adjusting game settings.
    /// </summary>
    public class SettingsPanel : Panel
    {
        private SimulationEngine engine;
        private ConfigManager configManager;
        private SpriteFont font;
        private Slider speedSlider;
        private Slider volumeSlider;
        private Button closeButton;
        private Label titleLabel;

        /// <summary>
        /// Initializes a new instance of the SettingsPanel class.
        /// </summary>
        /// <param name="position">The position of the settings panel.</param>
        /// <param name="size">The size of the settings panel.</param>
        /// <param name="texture">The texture of the settings panel.</param>
        /// <param name="backgroundColor">The background color of the settings panel.</param>
        /// <param name="engine">The simulation engine.</param>
        /// <param name="configManager">The configuration manager.</param>
        /// <param name="font">The font for labels.</param>
        /// <param name="graphicsDevice">The graphics device to use for rendering.</param>
        public SettingsPanel(Vector2 position, Vector2 size, Texture2D texture, Color backgroundColor, SimulationEngine engine, ConfigManager configManager, SpriteFont font, GraphicsDevice graphicsDevice)
            : base(position, size, texture, backgroundColor)
        {
            this.engine = engine;
            this.configManager = configManager;
            this.font = font;

            // Create title label
            titleLabel = new Label(new Vector2(position.X + size.X / 2 - 50, position.Y + 10), font, "Settings", Color.White);
            AddChild(titleLabel);

            // Create speed slider
            Texture2D sliderTrack = new Texture2D(graphicsDevice, 1, 1);
            sliderTrack.SetData(new[] { Color.Gray });
            Texture2D sliderThumb = new Texture2D(graphicsDevice, 1, 1);
            sliderThumb.SetData(new[] { Color.White });

            speedSlider = new Slider(
                new Vector2(position.X + 20, position.Y + 50),
                new Vector2(size.X - 40, 20),
                sliderTrack,
                sliderThumb,
                1,
                10,
                engine.SimulationSpeed,
                value => engine.SimulationSpeed = (int)value
            );
            AddChild(speedSlider);

            // Create speed label
            Label speedLabel = new Label(new Vector2(position.X + 20, position.Y + 30), font, "Simulation Speed", Color.White);
            AddChild(speedLabel);

            // Create volume slider
            volumeSlider = new Slider(
                new Vector2(position.X + 20, position.Y + 100),
                new Vector2(size.X - 40, 20),
                sliderTrack,
                sliderThumb,
                0,
                1,
                configManager.GetSetting("SoundVolume", 0.7f),
                value => configManager.SetSetting("SoundVolume", value)
            );
            AddChild(volumeSlider);

            // Create volume label
            Label volumeLabel = new Label(new Vector2(position.X + 20, position.Y + 80), font, "Sound Volume", Color.White);
            AddChild(volumeLabel);

            // Create close button
            Texture2D buttonTexture = new Texture2D(graphicsDevice, 1, 1);
            buttonTexture.SetData(new[] { Color.DarkGray });
            Texture2D buttonHoverTexture = new Texture2D(graphicsDevice, 1, 1);
            buttonHoverTexture.SetData(new[] { Color.Gray });

            closeButton = new Button(
                new Vector2(position.X + size.X - 70, position.Y + size.Y - 40),
                new Vector2(50, 30),
                buttonTexture,
                buttonHoverTexture,
                font,
                "Close",
                Color.White,
                () => IsVisible = false
            );
            AddChild(closeButton);

            // Create save button
            Button saveButton = new Button(
                new Vector2(position.X + 20, position.Y + size.Y - 40),
                new Vector2(50, 30),
                buttonTexture,
                buttonHoverTexture,
                font,
                "Save",
                Color.White,
                () => configManager.SaveConfig()
            );
            AddChild(saveButton);

            // Hide the panel by default
            IsVisible = false;
        }

        /// <summary>
        /// Shows the settings panel.
        /// </summary>
        public void Show()
        {
            IsVisible = true;
        }

        /// <summary>
        /// Hides the settings panel.
        /// </summary>
        public void Hide()
        {
            IsVisible = false;
        }

        /// <summary>
        /// Updates the settings panel.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            if (!IsVisible)
            {
                return;
            }

            // Update slider values
            speedSlider.Value = engine.SimulationSpeed;
            volumeSlider.Value = configManager.GetSetting("SoundVolume", 0.7f);

            base.Update(gameTime);
        }
    }
}
