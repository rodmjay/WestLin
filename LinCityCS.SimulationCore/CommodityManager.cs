using System;
using System.Collections.Generic;

namespace LinCityCS.SimulationCore
{
    /// <summary>
    /// Manages commodities in the game.
    /// </summary>
    public class CommodityManager
    {
        private Dictionary<Commodity, int> commodityAmounts;
        private Dictionary<Commodity, CommodityRule> commodityRules;

        /// <summary>
        /// Initializes a new instance of the CommodityManager class.
        /// </summary>
        public CommodityManager()
        {
            commodityAmounts = new Dictionary<Commodity, int>();
            commodityRules = new Dictionary<Commodity, CommodityRule>();

            // Initialize commodity amounts
            for (int i = 0; i < (int)Commodity.Count; i++)
            {
                commodityAmounts[(Commodity)i] = 0;
            }

            // Initialize commodity rules with default values
            // These would be set based on the C++ logic
            commodityRules[Commodity.Food] = new CommodityRule(1000, true, true);
            commodityRules[Commodity.Labor] = new CommodityRule(1000, true, true);
            commodityRules[Commodity.Coal] = new CommodityRule(1000, true, true);
            commodityRules[Commodity.Goods] = new CommodityRule(1000, true, true);
            commodityRules[Commodity.Ore] = new CommodityRule(1000, true, true);
            commodityRules[Commodity.Steel] = new CommodityRule(1000, true, true);
            commodityRules[Commodity.Waste] = new CommodityRule(1000, true, true);
            commodityRules[Commodity.LoVolt] = new CommodityRule(1000, true, true);
            commodityRules[Commodity.HiVolt] = new CommodityRule(1000, true, true);
            commodityRules[Commodity.Water] = new CommodityRule(1000, true, true);
        }

        /// <summary>
        /// Gets the amount of a commodity.
        /// </summary>
        /// <param name="commodity">The commodity.</param>
        /// <returns>The amount of the commodity.</returns>
        public int GetCommodityAmount(Commodity commodity)
        {
            return commodityAmounts[commodity];
        }

        /// <summary>
        /// Sets the amount of a commodity.
        /// </summary>
        /// <param name="commodity">The commodity.</param>
        /// <param name="amount">The amount to set.</param>
        public void SetCommodityAmount(Commodity commodity, int amount)
        {
            commodityAmounts[commodity] = amount;
        }

        /// <summary>
        /// Adds to the amount of a commodity.
        /// </summary>
        /// <param name="commodity">The commodity.</param>
        /// <param name="amount">The amount to add.</param>
        public void AddCommodityAmount(Commodity commodity, int amount)
        {
            commodityAmounts[commodity] += amount;
        }

        /// <summary>
        /// Gets the rule for a commodity.
        /// </summary>
        /// <param name="commodity">The commodity.</param>
        /// <returns>The rule for the commodity.</returns>
        public CommodityRule GetCommodityRule(Commodity commodity)
        {
            return commodityRules[commodity];
        }

        /// <summary>
        /// Sets the rule for a commodity.
        /// </summary>
        /// <param name="commodity">The commodity.</param>
        /// <param name="rule">The rule to set.</param>
        public void SetCommodityRule(Commodity commodity, CommodityRule rule)
        {
            commodityRules[commodity] = rule;
        }

        /// <summary>
        /// Checks if a commodity can be taken.
        /// </summary>
        /// <param name="commodity">The commodity.</param>
        /// <returns>True if the commodity can be taken, false otherwise.</returns>
        public bool CanTakeCommodity(Commodity commodity)
        {
            return commodityRules[commodity].Take;
        }

        /// <summary>
        /// Checks if a commodity can be given.
        /// </summary>
        /// <param name="commodity">The commodity.</param>
        /// <returns>True if the commodity can be given, false otherwise.</returns>
        public bool CanGiveCommodity(Commodity commodity)
        {
            return commodityRules[commodity].Give;
        }

        /// <summary>
        /// Gets the maximum load of a commodity.
        /// </summary>
        /// <param name="commodity">The commodity.</param>
        /// <returns>The maximum load of the commodity.</returns>
        public int GetCommodityMaxLoad(Commodity commodity)
        {
            return commodityRules[commodity].MaxLoad;
        }
    }
}
