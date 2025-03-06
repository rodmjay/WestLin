using System;

namespace LinCityCS.SimulationCore.Buildings.Residence
{
    /// <summary>
    /// Represents a residence building.
    /// </summary>
    public class ResidenceBuilding : Construction
    {
        private int maxPopulation;
        private int population;
        private int desireability;

        /// <summary>
        /// Gets or sets the population of the residence.
        /// </summary>
        public int Population
        {
            get { return population; }
            set { population = Math.Min(value, maxPopulation); }
        }

        /// <summary>
        /// Gets the maximum population of the residence.
        /// </summary>
        public int MaxPopulation => maxPopulation;

        /// <summary>
        /// Gets or sets a value indicating whether the residence is operational.
        /// </summary>
        public new bool IsOperational { get; set; }

        /// <summary>
        /// Initializes a new instance of the ResidenceBuilding class.
        /// </summary>
        /// <param name="group">The construction group.</param>
        public ResidenceBuilding(ConstructionGroup group)
        {
            Group = group;
            IsOperational = false;
            population = 0;

            // Set max population based on the group
            if (group == ResidenceConstructionGroups.ResidenceLL)
            {
                maxPopulation = ResidenceConstants.GroupResidenceLlMaxPop;
            }
            else if (group == ResidenceConstructionGroups.ResidenceML)
            {
                maxPopulation = ResidenceConstants.GroupResidenceMlMaxPop;
            }
            else if (group == ResidenceConstructionGroups.ResidenceHL)
            {
                maxPopulation = ResidenceConstants.GroupResidenceHlMaxPop;
            }
            else if (group == ResidenceConstructionGroups.ResidenceLH)
            {
                maxPopulation = ResidenceConstants.GroupResidenceLhMaxPop;
            }
            else if (group == ResidenceConstructionGroups.ResidenceMH)
            {
                maxPopulation = ResidenceConstants.GroupResidenceMhMaxPop;
            }
            else if (group == ResidenceConstructionGroups.ResidenceHH)
            {
                maxPopulation = ResidenceConstants.GroupResidenceHhMaxPop;
            }
            else
            {
                maxPopulation = 50; // Default
            }

            // Initialize commodity max consumption and production
            CommodityMaxConsumption[Commodity.Food] = ResidenceConstants.ResidenceFoodConsumption;
            CommodityMaxConsumption[Commodity.Goods] = ResidenceConstants.ResidenceGoodsConsumption;
            CommodityMaxConsumption[Commodity.LoVolt] = ResidenceConstants.ResidencePowerConsumption;
            CommodityMaxConsumption[Commodity.Water] = ResidenceConstants.ResidenceWaterConsumption;
            CommodityMaxProduction[Commodity.Labor] = ResidenceConstants.ResidenceLaborProduction;
            CommodityMaxProduction[Commodity.Waste] = ResidenceConstants.ResidenceWasteProduction;
        }

        /// <summary>
        /// Performs a simulation step for the residence.
        /// </summary>
        public override void DoSimStep()
        {
            if (IsBulldozed)
            {
                return;
            }

            // Check if we have enough resources
            bool hasFood = CommodityStore[Commodity.Food] > 0;
            bool hasGoods = CommodityStore[Commodity.Goods] > 0;
            bool hasPower = CommodityStore[Commodity.LoVolt] > 0;
            bool hasWater = CommodityStore[Commodity.Water] > 0;

            // Update operational status
            IsOperational = hasFood && hasGoods && hasPower && hasWater;

            // Consume resources based on population
            if (population > 0)
            {
                // Calculate consumption based on population
                int foodConsumption = (int)(ResidenceConstants.ResidenceFoodConsumption * (population / (float)maxPopulation));
                int goodsConsumption = (int)(ResidenceConstants.ResidenceGoodsConsumption * (population / (float)maxPopulation));
                int powerConsumption = (int)(ResidenceConstants.ResidencePowerConsumption * (population / (float)maxPopulation));
                int waterConsumption = (int)(ResidenceConstants.ResidenceWaterConsumption * (population / (float)maxPopulation));

                // Consume resources
                CommodityStore[Commodity.Food] = Math.Max(0, CommodityStore[Commodity.Food] - foodConsumption);
                CommodityStore[Commodity.Goods] = Math.Max(0, CommodityStore[Commodity.Goods] - goodsConsumption);
                CommodityStore[Commodity.LoVolt] = Math.Max(0, CommodityStore[Commodity.LoVolt] - powerConsumption);
                CommodityStore[Commodity.Water] = Math.Max(0, CommodityStore[Commodity.Water] - waterConsumption);

                // Produce labor and waste
                int laborProduction = (int)(ResidenceConstants.ResidenceLaborProduction * (population / (float)maxPopulation));
                int wasteProduction = (int)(ResidenceConstants.ResidenceWasteProduction * (population / (float)maxPopulation));

                CommodityStore[Commodity.Labor] += laborProduction;
                CommodityStore[Commodity.Waste] += wasteProduction;
            }

            // Update population
            if (IsOperational)
            {
                // Population growth
                if (population < maxPopulation)
                {
                    population += 1;
                }
            }
            else
            {
                // Population decline
                if (population > 0)
                {
                    population -= 1;
                }
            }
        }

        /// <summary>
        /// Reports information about the residence.
        /// </summary>
        /// <returns>A string containing information about the residence.</returns>
        public override string Report()
        {
            return $"Residence at ({X}, {Y}), Population: {population}/{maxPopulation}, Operational: {IsOperational}";
        }
    }
}
