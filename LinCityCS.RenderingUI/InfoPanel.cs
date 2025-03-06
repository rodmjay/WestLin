using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LinCityCS.SimulationCore;

namespace LinCityCS.RenderingUI
{
    /// <summary>
    /// Represents an information panel for displaying details about a selected tile.
    /// </summary>
    public class InfoPanel : Panel
    {
        private World world;
        private SpriteFont font;
        private Label titleLabel;
        private Label constructionLabel;
        private Label populationLabel;
        private Label jobsLabel;
        private Label pollutionLabel;
        private Button closeButton;
        private MapTile selectedTile;

        /// <summary>
        /// Initializes a new instance of the InfoPanel class.
        /// </summary>
        /// <param name="position">The position of the info panel.</param>
        /// <param name="size">The size of the info panel.</param>
        /// <param name="texture">The texture of the info panel.</param>
        /// <param name="backgroundColor">The background color of the info panel.</param>
        /// <param name="world">The world.</param>
        /// <param name="font">The font for labels.</param>
        /// <param name="graphicsDevice">The graphics device to use for rendering.</param>
        public InfoPanel(Vector2 position, Vector2 size, Texture2D texture, Color backgroundColor, World world, SpriteFont font, GraphicsDevice graphicsDevice)
            : base(position, size, texture, backgroundColor)
        {
            this.world = world;
            this.font = font;
            selectedTile = null;

            // Create title label
            titleLabel = new Label(new Vector2(position.X + 10, position.Y + 10), font, "Tile Information", Color.White);
            AddChild(titleLabel);

            // Create construction label
            constructionLabel = new Label(new Vector2(position.X + 10, position.Y + 40), font, "Construction: None", Color.White);
            AddChild(constructionLabel);

            // Create population label
            populationLabel = new Label(new Vector2(position.X + 10, position.Y + 60), font, "Population: 0", Color.White);
            AddChild(populationLabel);

            // Create jobs label
            jobsLabel = new Label(new Vector2(position.X + 10, position.Y + 80), font, "Jobs: 0", Color.White);
            AddChild(jobsLabel);

            // Create pollution label
            pollutionLabel = new Label(new Vector2(position.X + 10, position.Y + 100), font, "Pollution: 0", Color.White);
            AddChild(pollutionLabel);

            // Create close button
            Texture2D buttonTexture = new Texture2D(graphicsDevice, 1, 1);
            buttonTexture.SetData(new[] { Color.DarkGray });
            Texture2D buttonHoverTexture = new Texture2D(graphicsDevice, 1, 1);
            buttonHoverTexture.SetData(new[] { Color.Gray });

            closeButton = new Button(
                new Vector2(position.X + size.X - 60, position.Y + 10),
                new Vector2(50, 20),
                buttonTexture,
                buttonHoverTexture,
                font,
                "Close",
                Color.White,
                () => IsVisible = false
            );
            AddChild(closeButton);

            // Hide the panel by default
            IsVisible = false;
        }

        /// <summary>
        /// Shows the info panel for the specified tile.
        /// </summary>
        /// <param name="tile">The tile to show information for.</param>
        public void ShowForTile(MapTile tile)
        {
            selectedTile = tile;
            IsVisible = true;
            UpdateLabels();
        }

        /// <summary>
        /// Updates the info panel.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            if (!IsVisible)
            {
                return;
            }

            UpdateLabels();
            base.Update(gameTime);
        }

        /// <summary>
        /// Updates the labels with the current tile information.
        /// </summary>
        private void UpdateLabels()
        {
            if (selectedTile == null)
            {
                constructionLabel.Text = "Construction: None";
                populationLabel.Text = "Population: 0";
                jobsLabel.Text = "Jobs: 0";
                pollutionLabel.Text = "Pollution: 0";
                return;
            }

            // Update construction label
            if (selectedTile.Construction != null)
            {
                constructionLabel.Text = $"Construction: {selectedTile.Construction.Group.Name}";
            }
            else if (selectedTile.Ground != null)
            {
                constructionLabel.Text = $"Ground: {selectedTile.Ground.Type}";
            }
            else
            {
                constructionLabel.Text = "Construction: None";
            }

            // Update population label
            int population = 0;
            if (selectedTile.Construction is ResidenceConstruction residence)
            {
                population = residence.Population;
            }
            populationLabel.Text = $"Population: {population}";

            // Update jobs label
            int jobs = 0;
            if (selectedTile.Construction is ResidenceConstruction residenceJobs)
            {
                jobs = residenceJobs.Jobs;
            }
            jobsLabel.Text = $"Jobs: {jobs}";

            // Update pollution label
            pollutionLabel.Text = $"Pollution: {selectedTile.Pollution}";
        }
    }
}
