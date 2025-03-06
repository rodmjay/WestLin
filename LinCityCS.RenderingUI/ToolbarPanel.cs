using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LinCityCS.SimulationCore;

namespace LinCityCS.RenderingUI
{
    /// <summary>
    /// Represents a toolbar panel for selecting construction tools.
    /// </summary>
    public class ToolbarPanel : Panel
    {
        private InputManager inputManager;
        private List<ConstructionGroup> constructionGroups;
        private List<Button> constructionButtons;
        private SpriteFont font;

        /// <summary>
        /// Initializes a new instance of the ToolbarPanel class.
        /// </summary>
        /// <param name="position">The position of the toolbar panel.</param>
        /// <param name="size">The size of the toolbar panel.</param>
        /// <param name="texture">The texture of the toolbar panel.</param>
        /// <param name="backgroundColor">The background color of the toolbar panel.</param>
        /// <param name="inputManager">The input manager.</param>
        /// <param name="font">The font for button text.</param>
        public ToolbarPanel(Vector2 position, Vector2 size, Texture2D texture, Color backgroundColor, InputManager inputManager, SpriteFont font)
            : base(position, size, texture, backgroundColor)
        {
            this.inputManager = inputManager;
            this.font = font;
            constructionGroups = new List<ConstructionGroup>();
            constructionButtons = new List<Button>();
        }

        /// <summary>
        /// Adds a construction group to the toolbar.
        /// </summary>
        /// <param name="group">The construction group to add.</param>
        /// <param name="buttonTexture">The texture for the button.</param>
        /// <param name="hoverTexture">The texture for the button when hovered.</param>
        public void AddConstructionGroup(ConstructionGroup group, Texture2D buttonTexture, Texture2D hoverTexture)
        {
            constructionGroups.Add(group);

            // Calculate button position
            int buttonIndex = constructionButtons.Count;
            int buttonsPerRow = (int)(Size.X / 50); // Assuming 50 pixel wide buttons
            int row = buttonIndex / buttonsPerRow;
            int col = buttonIndex % buttonsPerRow;
            Vector2 buttonPosition = new Vector2(Position.X + col * 50, Position.Y + row * 50);

            // Create button
            Button button = new Button(
                buttonPosition,
                new Vector2(48, 48),
                buttonTexture,
                hoverTexture,
                font,
                group.Name,
                Color.White,
                () => inputManager.SetSelectedConstructionGroup(group)
            );

            constructionButtons.Add(button);
            AddChild(button);
        }

        /// <summary>
        /// Adds a bulldoze button to the toolbar.
        /// </summary>
        /// <param name="buttonTexture">The texture for the button.</param>
        /// <param name="hoverTexture">The texture for the button when hovered.</param>
        public void AddBulldozeButton(Texture2D buttonTexture, Texture2D hoverTexture)
        {
            // Calculate button position
            int buttonIndex = constructionButtons.Count;
            int buttonsPerRow = (int)(Size.X / 50); // Assuming 50 pixel wide buttons
            int row = buttonIndex / buttonsPerRow;
            int col = buttonIndex % buttonsPerRow;
            Vector2 buttonPosition = new Vector2(Position.X + col * 50, Position.Y + row * 50);

            // Create button
            Button button = new Button(
                buttonPosition,
                new Vector2(48, 48),
                buttonTexture,
                hoverTexture,
                font,
                "Bulldoze",
                Color.White,
                () => inputManager.SetSelectedConstructionGroup(null)
            );

            constructionButtons.Add(button);
            AddChild(button);
        }
    }
}
