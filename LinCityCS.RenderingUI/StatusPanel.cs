using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LinCityCS.SimulationCore;

namespace LinCityCS.RenderingUI
{
    /// <summary>
    /// Represents a status panel for displaying game information.
    /// </summary>
    public class StatusPanel : Panel
    {
        private SimulationEngine engine;
        private SpriteFont font;
        private Label timeLabel;
        private Label moneyLabel;
        private Label populationLabel;
        private Label techLevelLabel;
        private Label speedLabel;
        private Label pauseLabel;

        /// <summary>
        /// Initializes a new instance of the StatusPanel class.
        /// </summary>
        /// <param name="position">The position of the status panel.</param>
        /// <param name="size">The size of the status panel.</param>
        /// <param name="texture">The texture of the status panel.</param>
        /// <param name="backgroundColor">The background color of the status panel.</param>
        /// <param name="engine">The simulation engine.</param>
        /// <param name="font">The font for labels.</param>
        public StatusPanel(Vector2 position, Vector2 size, Texture2D texture, Color backgroundColor, SimulationEngine engine, SpriteFont font)
            : base(position, size, texture, backgroundColor)
        {
            this.engine = engine;
            this.font = font;

            // Create labels
            timeLabel = new Label(new Vector2(position.X + 10, position.Y + 10), font, "Year: 0 Month: 0", Color.White);
            moneyLabel = new Label(new Vector2(position.X + 10, position.Y + 30), font, "Money: 0", Color.White);
            populationLabel = new Label(new Vector2(position.X + 10, position.Y + 50), font, "Population: 0", Color.White);
            techLevelLabel = new Label(new Vector2(position.X + 10, position.Y + 70), font, "Tech Level: 0", Color.White);
            speedLabel = new Label(new Vector2(position.X + 10, position.Y + 90), font, "Speed: 1x", Color.White);
            pauseLabel = new Label(new Vector2(position.X + 10, position.Y + 110), font, "RUNNING", Color.Green);

            // Add labels to panel
            AddChild(timeLabel);
            AddChild(moneyLabel);
            AddChild(populationLabel);
            AddChild(techLevelLabel);
            AddChild(speedLabel);
            AddChild(pauseLabel);
        }

        /// <summary>
        /// Updates the status panel.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            if (!IsVisible)
            {
                return;
            }

            // Update label texts
            timeLabel.Text = $"Year: {engine.Economy.Year} Month: {engine.Economy.Month}";
            moneyLabel.Text = $"Money: {engine.Economy.Money}";
            populationLabel.Text = $"Population: {engine.Economy.Population}";
            techLevelLabel.Text = $"Tech Level: {engine.Economy.TechLevel}";
            speedLabel.Text = $"Speed: {engine.SimulationSpeed}x";
            
            if (engine.IsPaused)
            {
                pauseLabel.Text = "PAUSED";
                pauseLabel.TextColor = Color.Red;
            }
            else
            {
                pauseLabel.Text = "RUNNING";
                pauseLabel.TextColor = Color.Green;
            }

            base.Update(gameTime);
        }
    }
}
