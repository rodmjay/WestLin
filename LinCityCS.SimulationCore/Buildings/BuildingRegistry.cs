using System;
using System.Collections.Generic;
using LinCityCS.SimulationCore.Buildings.Power;
using LinCityCS.SimulationCore.Buildings.Industry;
using LinCityCS.SimulationCore.Buildings.Market;
using LinCityCS.SimulationCore.Buildings.Transport;

namespace LinCityCS.SimulationCore.Buildings
{
    /// <summary>
    /// Registry for all building construction groups in the game.
    /// </summary>
    public class BuildingRegistry
    {
        private Dictionary<string, ConstructionGroup> constructionGroups;

        /// <summary>
        /// Initializes a new instance of the BuildingRegistry class.
        /// </summary>
        public BuildingRegistry()
        {
            constructionGroups = new Dictionary<string, ConstructionGroup>();
            RegisterAllConstructionGroups();
        }

        /// <summary>
        /// Registers all construction groups.
        /// </summary>
        private void RegisterAllConstructionGroups()
        {
            // Register residence construction groups
            Register("residence-ll", ResidenceConstructionGroups.ResidenceLL);
            Register("residence-ml", ResidenceConstructionGroups.ResidenceML);
            Register("residence-hl", ResidenceConstructionGroups.ResidenceHL);
            Register("residence-lh", ResidenceConstructionGroups.ResidenceLH);
            Register("residence-mh", ResidenceConstructionGroups.ResidenceMH);
            Register("residence-hh", ResidenceConstructionGroups.ResidenceHH);

            // Register power construction groups
            Register("coal-power", PowerConstructionGroups.CoalPower);
            Register("solar-power", PowerConstructionGroups.SolarPower);
            Register("wind-power", PowerConstructionGroups.WindPower);
            Register("substation", PowerConstructionGroups.Substation);
            Register("power-line", PowerConstructionGroups.PowerLine);

            // Register industry construction groups
            Register("light-industry", IndustryConstructionGroups.LightIndustry);
            Register("heavy-industry", IndustryConstructionGroups.HeavyIndustry);

            // Register market construction groups
            Register("market", MarketConstructionGroups.Market);

            // Register transport construction groups
            Register("road", TransportConstructionGroups.Road);
        }

        /// <summary>
        /// Registers a construction group.
        /// </summary>
        /// <param name="id">The ID of the construction group.</param>
        /// <param name="group">The construction group to register.</param>
        private void Register(string id, ConstructionGroup group)
        {
            constructionGroups[id] = group;
        }

        /// <summary>
        /// Gets a construction group by ID.
        /// </summary>
        /// <param name="id">The ID of the construction group.</param>
        /// <returns>The construction group with the specified ID, or null if not found.</returns>
        public ConstructionGroup GetConstructionGroup(string id)
        {
            if (constructionGroups.TryGetValue(id, out var group))
            {
                return group;
            }
            return null;
        }
    }
}
