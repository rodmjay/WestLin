using System;
using System.Collections.Generic;

namespace LinCityCS.SimulationCore
{
    /// <summary>
    /// Base class for construction groups.
    /// </summary>
    public abstract class ConstructionGroup
    {
        private Dictionary<Commodity, CommodityRule> commodityRuleCount = new Dictionary<Commodity, CommodityRule>();

        /// <summary>
        /// Gets or sets the name of the construction group.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the construction group requires credit.
        /// </summary>
        public bool NoCredit { get; set; }

        /// <summary>
        /// Gets or sets the group number.
        /// </summary>
        public int Group { get; set; }

        /// <summary>
        /// Gets or sets the size of the construction.
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// Gets or sets the color of the construction.
        /// </summary>
        public int Colour { get; set; }

        /// <summary>
        /// Gets or sets the cost multiplier of the construction.
        /// </summary>
        public int CostMul { get; set; }

        /// <summary>
        /// Gets or sets the bulldoze cost of the construction.
        /// </summary>
        public int BulCost { get; set; }

        /// <summary>
        /// Gets or sets the fire chance of the construction.
        /// </summary>
        public int FireChance { get; set; }

        /// <summary>
        /// Gets or sets the cost of the construction.
        /// </summary>
        public int Cost { get; set; }

        /// <summary>
        /// Gets or sets the tech level required for the construction.
        /// </summary>
        public int Tech { get; set; }

        /// <summary>
        /// Gets or sets the range of the construction.
        /// </summary>
        public int Range { get; set; }

        /// <summary>
        /// Gets or sets the flags of the construction.
        /// </summary>
        public int Flags { get; set; }

        /// <summary>
        /// Gets the commodity rule count.
        /// </summary>
        public Dictionary<Commodity, CommodityRule> CommodityRuleCount => commodityRuleCount;

        /// <summary>
        /// Initializes a new instance of the ConstructionGroup class.
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
        /// <param name="flags">The flags of the construction.</param>
        protected ConstructionGroup(
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
            int flags)
        {
            Name = name;
            NoCredit = noCredit;
            Group = group;
            Size = size;
            Colour = colour;
            CostMul = costMul;
            BulCost = bulCost;
            FireChance = fireChance;
            Cost = cost;
            Tech = tech;
            Range = range;
            Flags = flags;

            // Initialize commodity rules
            foreach (Commodity commodity in Enum.GetValues(typeof(Commodity)))
            {
                commodityRuleCount[commodity] = new CommodityRule();
            }
        }

        /// <summary>
        /// Creates a construction of this group.
        /// </summary>
        /// <returns>A new construction of this group.</returns>
        public abstract Construction CreateConstruction();
    }
}
