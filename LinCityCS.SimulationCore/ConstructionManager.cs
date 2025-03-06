using System;
using System.Collections.Generic;

namespace LinCityCS.SimulationCore
{
    /// <summary>
    /// Manages the construction of buildings in the game.
    /// </summary>
    public class ConstructionManager
    {
        private World world;
        private List<ConstructionRequest> requests;

        /// <summary>
        /// Initializes a new instance of the ConstructionManager class.
        /// </summary>
        /// <param name="world">The game world.</param>
        public ConstructionManager(World world)
        {
            this.world = world;
            requests = new List<ConstructionRequest>();
        }

        /// <summary>
        /// Adds a construction request to the queue.
        /// </summary>
        /// <param name="request">The construction request to add.</param>
        public void AddRequest(ConstructionRequest request)
        {
            requests.Add(request);
        }

        /// <summary>
        /// Processes all pending construction requests.
        /// </summary>
        public void ProcessRequests()
        {
            foreach (var request in requests)
            {
                ProcessRequest(request);
            }
            requests.Clear();
        }

        /// <summary>
        /// Processes a single construction request.
        /// </summary>
        /// <param name="request">The construction request to process.</param>
        private void ProcessRequest(ConstructionRequest request)
        {
            if (request.Type == ConstructionRequest.RequestType.Build)
            {
                BuildConstruction(request);
            }
            else if (request.Type == ConstructionRequest.RequestType.Bulldoze)
            {
                BulldozeConstruction(request);
            }
        }

        /// <summary>
        /// Builds a construction at the specified location.
        /// </summary>
        /// <param name="request">The construction request.</param>
        private void BuildConstruction(ConstructionRequest request)
        {
            if (request.Group == null)
            {
                return;
            }

            // Check if the location is valid
            if (!world.IsInside(request.X, request.Y))
            {
                return;
            }

            // Check if there is already a construction at the location
            var tile = world.GetTile(request.X, request.Y);
            if (tile.Construction != null && !tile.Construction.IsBulldozed)
            {
                return;
            }

            // Create the construction
            var construction = request.Group.CreateConstruction();
            construction.X = request.X;
            construction.Y = request.Y;

            // Add the construction to the tile
            tile.Construction = construction;
        }

        /// <summary>
        /// Bulldozes a construction at the specified location.
        /// </summary>
        /// <param name="request">The construction request.</param>
        private void BulldozeConstruction(ConstructionRequest request)
        {
            if (!world.IsInside(request.X, request.Y))
            {
                return;
            }

            var tile = world.GetTile(request.X, request.Y);
            if (tile.Construction != null)
            {
                tile.Construction.Destroy();
            }
        }

        /// <summary>
        /// Gets the construction at the specified location.
        /// </summary>
        /// <param name="x">The x-coordinate.</param>
        /// <param name="y">The y-coordinate.</param>
        /// <returns>The construction at the specified location, or null if there is none.</returns>
        public Construction GetConstruction(int x, int y)
        {
            if (!world.IsInside(x, y))
            {
                return null;
            }

            return world.GetTile(x, y).Construction;
        }
    }
}
