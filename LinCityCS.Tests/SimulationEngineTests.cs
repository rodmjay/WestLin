using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinCityCS.SimulationCore;

namespace LinCityCS.Tests
{
    [TestClass]
    public class SimulationEngineTests
    {
        [TestMethod]
        public void TestSimulationEngineCreation()
        {
            // Arrange & Act
            var world = new World(100, 100);
            var engine = new SimulationEngine(world);
            
            // Assert
            Assert.IsNotNull(engine);
            Assert.AreEqual(world, engine.World);
            Assert.AreEqual(0, engine.TotalTime);
        }

        [TestMethod]
        public void TestSimulationEngineUpdate()
        {
            // Arrange
            var world = new World(100, 100);
            var engine = new SimulationEngine(world);
            
            // Act
            engine.Update();
            
            // Assert
            Assert.AreEqual(1, engine.TotalTime);
        }

        [TestMethod]
        public void TestSimulationEngineMultipleUpdates()
        {
            // Arrange
            var world = new World(100, 100);
            var engine = new SimulationEngine(world);
            
            // Act
            for (int i = 0; i < 10; i++)
            {
                engine.Update();
            }
            
            // Assert
            Assert.AreEqual(10, engine.TotalTime);
        }
    }
}
