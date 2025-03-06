using System;

namespace LinCityCS.SimulationCore
{
    /// <summary>
    /// Base class for building construction groups.
    /// </summary>
    public class BuildingConstructionGroup : ConstructionGroup
    {
        /// <summary>
        /// Gets or sets the building type.
        /// </summary>
        public int BuildingType { get; set; }

        /// <summary>
        /// Initializes a new instance of the BuildingConstructionGroup class.
        /// </summary>
        /// <param name="name">The name of the construction group.</param>
        /// <param name="noCredit">Whether the construction group requires credit.</param>
        /// <param name="group">The group number.</param>
        /// <param name="size">The size of the construction.</param>
        /// <param name="colour">The color of the construction.</param>
        /// <param name="costMul">The cost multiplier of the construction.</param>
        /// <param name="bulCost">The bulldoze cost of the construction.</param>
        /// <param name="fireChance">The fire chance of the construction.</param>
        /// <param name="cost">The cost of the construction.</param>
        /// <param name="tech">The tech level required for the construction.</param>
        /// <param name="range">The range of the construction.</param>
        /// <param name="buildingType">The building type.</param>
        public BuildingConstructionGroup(
            string name,
            bool noCredit,
            int group,
            int size,
            int colour,
            int costMul,
            int bulCost,
            int fireChance,
            int cost,
            int tech,
            int range,
            int buildingType)
            : base(name, noCredit, group, size, colour, costMul, bulCost, fireChance, cost, tech, range, 0)
        {
            BuildingType = buildingType;
        }

        /// <summary>
        /// Creates a construction of this group.
        /// </summary>
        /// <returns>A new construction of this group.</returns>
        public override Construction CreateConstruction()
        {
            // This is a base class, so we'll return null here
            // Derived classes should override this method to create specific construction types
            return null;
        }
    }
}
