using LinCityCS.SimulationCore;

namespace LinCityCS.Tests
{
    /// <summary>
    /// A concrete implementation of Construction for testing purposes.
    /// </summary>
    public class TestConstruction : Construction
    {
        /// <summary>
        /// Initializes a new instance of the TestConstruction class.
        /// </summary>
        /// <param name="group">The construction group.</param>
        public TestConstruction(ConstructionGroup group)
        {
            Group = group;
        }

        /// <summary>
        /// Performs a simulation step for the construction.
        /// </summary>
        public override void DoSimStep()
        {
            // Do nothing for test
        }
    }
}
