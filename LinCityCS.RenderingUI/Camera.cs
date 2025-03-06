using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LinCityCS.RenderingUI
{
    /// <summary>
    /// Represents a camera for viewing the game world.
    /// </summary>
    public class Camera
    {
        private Vector2 position;
        private float zoom;
        private Matrix transform;
        private Viewport viewport;

        /// <summary>
        /// Gets or sets the position of the camera.
        /// </summary>
        public Vector2 Position
        {
            get => position;
            set
            {
                position = value;
                UpdateTransform();
            }
        }

        /// <summary>
        /// Gets or sets the zoom level of the camera.
        /// </summary>
        public float Zoom
        {
            get => zoom;
            set
            {
                zoom = MathHelper.Clamp(value, 0.1f, 10f);
                UpdateTransform();
            }
        }

        /// <summary>
        /// Gets the transformation matrix of the camera.
        /// </summary>
        public Matrix Transform => transform;

        /// <summary>
        /// Initializes a new instance of the Camera class.
        /// </summary>
        /// <param name="viewport">The viewport of the camera.</param>
        public Camera(Viewport viewport)
        {
            this.viewport = viewport;
            position = Vector2.Zero;
            zoom = 1.0f;
            UpdateTransform();
        }

        /// <summary>
        /// Moves the camera by the specified amount.
        /// </summary>
        /// <param name="amount">The amount to move the camera.</param>
        public void Move(Vector2 amount)
        {
            position += amount;
            UpdateTransform();
        }

        /// <summary>
        /// Updates the transformation matrix of the camera.
        /// </summary>
        private void UpdateTransform()
        {
            transform = Matrix.CreateTranslation(new Vector3(-position, 0.0f)) *
                       Matrix.CreateScale(new Vector3(zoom, zoom, 1.0f)) *
                       Matrix.CreateTranslation(new Vector3(viewport.Width * 0.5f, viewport.Height * 0.5f, 0.0f));
        }

        /// <summary>
        /// Converts a screen position to a world position.
        /// </summary>
        /// <param name="screenPosition">The screen position to convert.</param>
        /// <returns>The world position.</returns>
        public Vector2 ScreenToWorld(Vector2 screenPosition)
        {
            Matrix inverseTransform = Matrix.Invert(transform);
            return Vector2.Transform(screenPosition, inverseTransform);
        }

        /// <summary>
        /// Converts a world position to a screen position.
        /// </summary>
        /// <param name="worldPosition">The world position to convert.</param>
        /// <returns>The screen position.</returns>
        public Vector2 WorldToScreen(Vector2 worldPosition)
        {
            return Vector2.Transform(worldPosition, transform);
        }
    }
}
