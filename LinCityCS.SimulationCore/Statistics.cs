using System;

namespace LinCityCS.SimulationCore
{
    /// <summary>
    /// Manages game statistics.
    /// </summary>
    public class Statistics
    {
        private int population;
        private int totalBuildings;
        private int totalRoads;
        private int totalPowerPlants;
        private int totalIndustry;
        private int totalResidences;
        private int totalMarkets;
        private int totalPollution;
        private int totalUnemployment;
        private int totalHomeless;
        private int totalTaxIncome;
        private int totalExpenses;
        private int totalBalance;

        /// <summary>
        /// Gets the population.
        /// </summary>
        public int Population => population;

        /// <summary>
        /// Gets the total number of buildings.
        /// </summary>
        public int TotalBuildings => totalBuildings;

        /// <summary>
        /// Gets the total number of roads.
        /// </summary>
        public int TotalRoads => totalRoads;

        /// <summary>
        /// Gets the total number of power plants.
        /// </summary>
        public int TotalPowerPlants => totalPowerPlants;

        /// <summary>
        /// Gets the total number of industry buildings.
        /// </summary>
        public int TotalIndustry => totalIndustry;

        /// <summary>
        /// Gets the total number of residences.
        /// </summary>
        public int TotalResidences => totalResidences;

        /// <summary>
        /// Gets the total number of markets.
        /// </summary>
        public int TotalMarkets => totalMarkets;

        /// <summary>
        /// Gets the total pollution.
        /// </summary>
        public int TotalPollution => totalPollution;

        /// <summary>
        /// Gets the total unemployment.
        /// </summary>
        public int TotalUnemployment => totalUnemployment;

        /// <summary>
        /// Gets the total homeless.
        /// </summary>
        public int TotalHomeless => totalHomeless;

        /// <summary>
        /// Gets the total tax income.
        /// </summary>
        public int TotalTaxIncome => totalTaxIncome;

        /// <summary>
        /// Gets the total expenses.
        /// </summary>
        public int TotalExpenses => totalExpenses;

        /// <summary>
        /// Gets the total balance.
        /// </summary>
        public int TotalBalance => totalBalance;

        /// <summary>
        /// Initializes a new instance of the Statistics class.
        /// </summary>
        public Statistics()
        {
            Reset();
        }

        /// <summary>
        /// Resets all statistics.
        /// </summary>
        public void Reset()
        {
            population = 0;
            totalBuildings = 0;
            totalRoads = 0;
            totalPowerPlants = 0;
            totalIndustry = 0;
            totalResidences = 0;
            totalMarkets = 0;
            totalPollution = 0;
            totalUnemployment = 0;
            totalHomeless = 0;
            totalTaxIncome = 0;
            totalExpenses = 0;
            totalBalance = 0;
        }

        /// <summary>
        /// Updates the statistics based on the current world state.
        /// </summary>
        /// <param name="world">The world.</param>
        public void Update(World world)
        {
            // Reset counters
            population = 0;
            totalBuildings = 0;
            totalRoads = 0;
            totalPowerPlants = 0;
            totalIndustry = 0;
            totalResidences = 0;
            totalMarkets = 0;
            totalPollution = 0;

            // Count buildings and calculate statistics
            for (int x = 0; x < world.Width; x++)
            {
                for (int y = 0; y < world.Height; y++)
                {
                    var tile = world.GetTile(x, y);
                    
                    // Count pollution
                    totalPollution += tile.Pollution;

                    // Skip tiles without constructions
                    if (tile.Construction == null || tile.Construction.IsBulldozed)
                    {
                        continue;
                    }

                    // Count buildings
                    totalBuildings++;

                    // TODO: Count specific building types
                    // This will be implemented when we have more building types
                }
            }

            // Calculate unemployment and homelessness
            // TODO: Implement this when we have more detailed population tracking

            // Calculate financial statistics
            // TODO: Implement this when we have a more detailed economy system
        }
    }
}
