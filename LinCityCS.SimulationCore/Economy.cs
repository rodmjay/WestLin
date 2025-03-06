using System;
using System.Collections.Generic;

namespace LinCityCS.SimulationCore
{
    /// <summary>
    /// Manages the economy of the game.
    /// </summary>
    public class Economy
    {
        /// <summary>
        /// The current amount of money.
        /// </summary>
        public int Money { get; set; }

        /// <summary>
        /// The current tax rate.
        /// </summary>
        public int TaxRate { get; set; }

        /// <summary>
        /// The current unemployment rate.
        /// </summary>
        public float UnemploymentRate { get; set; }

        /// <summary>
        /// The current population.
        /// </summary>
        public int Population { get; set; }

        /// <summary>
        /// The current tech level.
        /// </summary>
        public int TechLevel { get; set; }

        /// <summary>
        /// The current month.
        /// </summary>
        public int Month { get; set; }

        /// <summary>
        /// The current year.
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// The total income.
        /// </summary>
        public int TotalIncome { get; set; }

        /// <summary>
        /// The total expenses.
        /// </summary>
        public int TotalExpense { get; set; }

        /// <summary>
        /// The commodity manager.
        /// </summary>
        public CommodityManager CommodityManager { get; private set; }

        /// <summary>
        /// Initializes a new instance of the Economy class.
        /// </summary>
        public Economy()
        {
            Money = 10000; // Starting money
            TaxRate = 10;  // Default tax rate
            UnemploymentRate = 0.0f;
            Population = 0;
            TechLevel = 0;
            Month = 0;
            Year = 0;
            TotalIncome = 0;
            TotalExpense = 0;
            CommodityManager = new CommodityManager();
        }

        /// <summary>
        /// Performs a simulation step for the economy.
        /// </summary>
        public void DoSimStep()
        {
            // Calculate income from taxes
            int taxIncome = (int)(Population * TaxRate * 0.01f);
            TotalIncome += taxIncome;
            Money += taxIncome;

            // Update month and year
            Month++;
            if (Month >= 12)
            {
                Month = 0;
                Year++;
            }
        }

        /// <summary>
        /// Spends money.
        /// </summary>
        /// <param name="amount">The amount to spend.</param>
        /// <returns>True if the money was spent successfully, false otherwise.</returns>
        public bool SpendMoney(int amount)
        {
            if (Money < amount)
            {
                return false;
            }

            Money -= amount;
            TotalExpense += amount;
            return true;
        }

        /// <summary>
        /// Adds money.
        /// </summary>
        /// <param name="amount">The amount to add.</param>
        public void AddMoney(int amount)
        {
            Money += amount;
            TotalIncome += amount;
        }

        /// <summary>
        /// Updates the tech level based on the population and other factors.
        /// </summary>
        public void UpdateTechLevel()
        {
            // This would be implemented based on the C++ logic
            // For now, just a placeholder
            TechLevel = Math.Min(100, (int)(Population * 0.01f));
        }

        /// <summary>
        /// Updates the unemployment rate based on the available jobs and population.
        /// </summary>
        /// <param name="availableJobs">The number of available jobs.</param>
        public void UpdateUnemploymentRate(int availableJobs)
        {
            if (Population <= 0)
            {
                UnemploymentRate = 0.0f;
                return;
            }

            int workingPopulation = Math.Min(Population, availableJobs);
            UnemploymentRate = 1.0f - (float)workingPopulation / Population;
        }
    }
}
