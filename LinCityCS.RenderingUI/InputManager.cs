using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using LinCityCS.SimulationCore;

namespace LinCityCS.RenderingUI
{
    /// <summary>
    /// Manages user input for the game.
    /// </summary>
    public class InputManager
    {
        private KeyboardState currentKeyboardState;
        private KeyboardState previousKeyboardState;
        private MouseState currentMouseState;
        private MouseState previousMouseState;
        private LinCityGame game;
        private SimulationEngine engine;
        private World world;
        private Camera camera;
        private ConstructionGroup selectedConstructionGroup;
        private bool isDragging;
        private Vector2 dragStartPosition;
        private ContextMenu contextMenu;
        private List<UIElement> uiElements;
        private bool isOverUI;

        /// <summary>
        /// Gets the selected construction group.
        /// </summary>
        public ConstructionGroup SelectedConstructionGroup => selectedConstructionGroup;

        /// <summary>
        /// Initializes a new instance of the InputManager class.
        /// </summary>
        /// <param name="game">The game.</param>
        /// <param name="engine">The simulation engine.</param>
        /// <param name="world">The world.</param>
        /// <param name="camera">The camera.</param>
        public InputManager(LinCityGame game, SimulationEngine engine, World world, Camera camera)
        {
            this.game = game;
            this.engine = engine;
            this.world = world;
            this.camera = camera;
            currentKeyboardState = Keyboard.GetState();
            previousKeyboardState = currentKeyboardState;
            currentMouseState = Mouse.GetState();
            previousMouseState = currentMouseState;
            selectedConstructionGroup = null;
            isDragging = false;
            dragStartPosition = Vector2.Zero;
            uiElements = new List<UIElement>();
            isOverUI = false;
        }

        /// <summary>
        /// Sets the context menu.
        /// </summary>
        /// <param name="contextMenu">The context menu.</param>
        public void SetContextMenu(ContextMenu contextMenu)
        {
            this.contextMenu = contextMenu;
        }

        /// <summary>
        /// Adds a UI element to the input manager.
        /// </summary>
        /// <param name="element">The UI element to add.</param>
        public void AddUIElement(UIElement element)
        {
            uiElements.Add(element);
        }

        /// <summary>
        /// Removes a UI element from the input manager.
        /// </summary>
        /// <param name="element">The UI element to remove.</param>
        public void RemoveUIElement(UIElement element)
        {
            uiElements.Remove(element);
        }

        /// <summary>
        /// Updates the input manager.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public void Update(GameTime gameTime)
        {
            previousKeyboardState = currentKeyboardState;
            previousMouseState = currentMouseState;
            currentKeyboardState = Keyboard.GetState();
            currentMouseState = Mouse.GetState();

            // Check if the mouse is over any UI element
            isOverUI = IsMouseOverUI();

            // Handle keyboard input
            HandleKeyboardInput();

            // Handle mouse input
            HandleMouseInput();
        }

        /// <summary>
        /// Checks if the mouse is over any UI element.
        /// </summary>
        /// <returns>True if the mouse is over any UI element, false otherwise.</returns>
        private bool IsMouseOverUI()
        {
            Point mousePosition = currentMouseState.Position;
            
            foreach (var element in uiElements)
            {
                if (element.IsVisible && element.Contains(mousePosition))
                {
                    return true;
                }
            }
            
            return false;
        }

        /// <summary>
        /// Handles keyboard input.
        /// </summary>
        private void HandleKeyboardInput()
        {
            // Handle camera movement
            if (currentKeyboardState.IsKeyDown(Keys.W) || currentKeyboardState.IsKeyDown(Keys.Up))
            {
                camera.Move(new Vector2(0, -5));
            }
            if (currentKeyboardState.IsKeyDown(Keys.S) || currentKeyboardState.IsKeyDown(Keys.Down))
            {
                camera.Move(new Vector2(0, 5));
            }
            if (currentKeyboardState.IsKeyDown(Keys.A) || currentKeyboardState.IsKeyDown(Keys.Left))
            {
                camera.Move(new Vector2(-5, 0));
            }
            if (currentKeyboardState.IsKeyDown(Keys.D) || currentKeyboardState.IsKeyDown(Keys.Right))
            {
                camera.Move(new Vector2(5, 0));
            }

            // Handle zoom
            if (currentKeyboardState.IsKeyDown(Keys.OemPlus) || currentKeyboardState.IsKeyDown(Keys.Add))
            {
                camera.Zoom += 0.1f;
            }
            if (currentKeyboardState.IsKeyDown(Keys.OemMinus) || currentKeyboardState.IsKeyDown(Keys.Subtract))
            {
                camera.Zoom -= 0.1f;
            }

            // Handle simulation speed
            if (IsKeyPressed(Keys.D1))
            {
                engine.SimulationSpeed = 1;
            }
            if (IsKeyPressed(Keys.D2))
            {
                engine.SimulationSpeed = 2;
            }
            if (IsKeyPressed(Keys.D3))
            {
                engine.SimulationSpeed = 5;
            }
            if (IsKeyPressed(Keys.D4))
            {
                engine.SimulationSpeed = 10;
            }

            // Handle pause
            if (IsKeyPressed(Keys.Space))
            {
                engine.IsPaused = !engine.IsPaused;
            }

            // Handle bulldoze mode
            if (IsKeyPressed(Keys.B))
            {
                selectedConstructionGroup = null; // Bulldoze mode
            }

            // Handle escape to cancel selection
            if (IsKeyPressed(Keys.Escape))
            {
                selectedConstructionGroup = null;
                if (contextMenu != null)
                {
                    contextMenu.Hide();
                }
            }

            // Handle save/load
            if (IsKeyPressed(Keys.F5))
            {
                // Save game
                // This would be implemented based on the C++ logic
            }
            if (IsKeyPressed(Keys.F9))
            {
                // Load game
                // This would be implemented based on the C++ logic
            }
        }

        /// <summary>
        /// Handles mouse input.
        /// </summary>
        private void HandleMouseInput()
        {
            // Skip mouse handling if over UI
            if (isOverUI)
            {
                isDragging = false;
                return;
            }

            // Handle mouse click
            if (IsMouseButtonPressed(MouseButton.Left))
            {
                HandleLeftMouseClick(currentMouseState.Position);
            }
            else if (IsMouseButtonPressed(MouseButton.Right))
            {
                HandleRightMouseClick(currentMouseState.Position);
            }

            // Handle mouse drag
            if (currentMouseState.LeftButton == ButtonState.Pressed)
            {
                if (!isDragging)
                {
                    isDragging = true;
                    dragStartPosition = currentMouseState.Position.ToVector2();
                }
                else
                {
                    Vector2 dragDelta = currentMouseState.Position.ToVector2() - dragStartPosition;
                    if (dragDelta.Length() > 5) // Only move if dragged more than 5 pixels
                    {
                        camera.Move(-dragDelta * 0.1f); // Move camera in opposite direction of drag
                        dragStartPosition = currentMouseState.Position.ToVector2();
                    }
                }
            }
            else
            {
                isDragging = false;
            }

            // Handle mouse wheel for zoom
            int scrollDelta = currentMouseState.ScrollWheelValue - previousMouseState.ScrollWheelValue;
            if (scrollDelta != 0)
            {
                // Zoom centered on mouse position
                Vector2 mouseWorldPos = camera.ScreenToWorld(currentMouseState.Position.ToVector2());
                float oldZoom = camera.Zoom;
                camera.Zoom += scrollDelta * 0.001f;
                float zoomRatio = camera.Zoom / oldZoom;
                
                // Adjust camera position to keep mouse position fixed
                Vector2 newMouseWorldPos = camera.ScreenToWorld(currentMouseState.Position.ToVector2());
                Vector2 adjustment = (mouseWorldPos - newMouseWorldPos) * camera.Zoom;
                camera.Position += adjustment;
            }
        }

        /// <summary>
        /// Handles a left mouse click.
        /// </summary>
        /// <param name="position">The position of the mouse click.</param>
        private void HandleLeftMouseClick(Point position)
        {
            // Hide context menu if it's visible
            if (contextMenu != null && contextMenu.IsVisible)
            {
                contextMenu.Hide();
                return;
            }

            // Convert screen position to world position
            Vector2 worldPosition = camera.ScreenToWorld(position.ToVector2());

            // Convert world position to tile coordinates
            int tileX = (int)(worldPosition.X / 32); // Assuming 32 pixel tiles
            int tileY = (int)(worldPosition.Y / 32);

            // Check if the tile is within the world bounds
            if (world.IsInside(tileX, tileY))
            {
                // Handle tile click based on selected construction group
                if (selectedConstructionGroup == null)
                {
                    // Bulldoze mode or just selecting
                    MapTile tile = world[tileX, tileY];
                    if (tile.Construction != null)
                    {
                        // Create bulldoze request
                        ConstructionRequest request = new ConstructionRequest(tile.Construction);
                        ConstructionManager.SubmitRequest(request);
                    }
                }
                else
                {
                    // Build mode
                    ConstructionRequest request = new ConstructionRequest(tileX, tileY, selectedConstructionGroup);
                    ConstructionManager.SubmitRequest(request);
                }
            }
        }

        /// <summary>
        /// Handles a right mouse click.
        /// </summary>
        /// <param name="position">The position of the mouse click.</param>
        private void HandleRightMouseClick(Point position)
        {
            // Convert screen position to world position
            Vector2 worldPosition = camera.ScreenToWorld(position.ToVector2());

            // Convert world position to tile coordinates
            int tileX = (int)(worldPosition.X / 32); // Assuming 32 pixel tiles
            int tileY = (int)(worldPosition.Y / 32);

            // Check if the tile is within the world bounds
            if (world.IsInside(tileX, tileY))
            {
                // Show context menu for the tile
                if (contextMenu != null)
                {
                    contextMenu.Show(position.ToVector2());
                }
            }
        }

        /// <summary>
        /// Sets the selected construction group.
        /// </summary>
        /// <param name="group">The construction group to select.</param>
        public void SetSelectedConstructionGroup(ConstructionGroup group)
        {
            selectedConstructionGroup = group;
        }

        /// <summary>
        /// Checks if a key was just pressed.
        /// </summary>
        /// <param name="key">The key to check.</param>
        /// <returns>True if the key was just pressed, false otherwise.</returns>
        private bool IsKeyPressed(Keys key)
        {
            return currentKeyboardState.IsKeyDown(key) && previousKeyboardState.IsKeyUp(key);
        }

        /// <summary>
        /// Checks if a mouse button was just pressed.
        /// </summary>
        /// <param name="button">The mouse button to check.</param>
        /// <returns>True if the mouse button was just pressed, false otherwise.</returns>
        private bool IsMouseButtonPressed(MouseButton button)
        {
            switch (button)
            {
                case MouseButton.Left:
                    return currentMouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released;
                case MouseButton.Right:
                    return currentMouseState.RightButton == ButtonState.Pressed && previousMouseState.RightButton == ButtonState.Released;
                case MouseButton.Middle:
                    return currentMouseState.MiddleButton == ButtonState.Pressed && previousMouseState.MiddleButton == ButtonState.Released;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Represents a mouse button.
        /// </summary>
        public enum MouseButton
        {
            /// <summary>
            /// The left mouse button.
            /// </summary>
            Left,
            
            /// <summary>
            /// The right mouse button.
            /// </summary>
            Right,
            
            /// <summary>
            /// The middle mouse button.
            /// </summary>
            Middle
        }
    }
}
