using System;

namespace LinCityCS.SimulationCore
{
    /// <summary>
    /// Represents a request to build or bulldoze a construction.
    /// </summary>
    public class ConstructionRequest
    {
        /// <summary>
        /// Specifies the type of construction request.
        /// </summary>
        public enum RequestType
        {
            /// <summary>
            /// Build a new construction.
            /// </summary>
            Build,

            /// <summary>
            /// Bulldoze an existing construction.
            /// </summary>
            Bulldoze
        }

        /// <summary>
        /// Gets or sets the type of the request.
        /// </summary>
        public RequestType Type { get; set; }

        /// <summary>
        /// Gets or sets the construction group.
        /// </summary>
        public ConstructionGroup? Group { get; set; }

        /// <summary>
        /// Gets or sets the target construction.
        /// </summary>
        public Construction? Target { get; set; }

        /// <summary>
        /// Gets or sets the X coordinate.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Gets or sets the Y coordinate.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Initializes a new instance of the ConstructionRequest class.
        /// </summary>
        public ConstructionRequest()
        {
            Type = RequestType.Build;
            Group = null;
            Target = null;
            X = 0;
            Y = 0;
        }

        /// <summary>
        /// Creates a build request.
        /// </summary>
        /// <param name="group">The construction group.</param>
        /// <param name="x">The X coordinate.</param>
        /// <param name="y">The Y coordinate.</param>
        /// <returns>A new build request.</returns>
        public static ConstructionRequest CreateBuildRequest(ConstructionGroup group, int x, int y)
        {
            return new ConstructionRequest
            {
                Type = RequestType.Build,
                Group = group,
                X = x,
                Y = y
            };
        }

        /// <summary>
        /// Creates a bulldoze request.
        /// </summary>
        /// <param name="target">The target construction.</param>
        /// <returns>A new bulldoze request.</returns>
        public static ConstructionRequest? CreateBulldozeRequest(Construction? target)
        {
            if (target == null)
            {
                return null;
            }

            return new ConstructionRequest
            {
                Type = RequestType.Bulldoze,
                Target = target,
                X = target.X,
                Y = target.Y
            };
        }

        /// <summary>
        /// Creates a bulldoze request.
        /// </summary>
        /// <param name="x">The X coordinate.</param>
        /// <param name="y">The Y coordinate.</param>
        /// <returns>A new bulldoze request.</returns>
        public static ConstructionRequest CreateBulldozeRequest(int x, int y)
        {
            return new ConstructionRequest
            {
                Type = RequestType.Bulldoze,
                X = x,
                Y = y
            };
        }
    }
}
