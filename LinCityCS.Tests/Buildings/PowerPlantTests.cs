using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinCityCS.SimulationCore;
using LinCityCS.SimulationCore.Buildings.Power;

namespace LinCityCS.Tests.Buildings
{
    [TestClass]
    public class PowerPlantTests
    {
        [TestMethod]
        public void TestCoalPowerPlantCreation()
        {
            // Arrange
            var group = PowerConstructionGroups.CoalPower;
            
            // Act
            var powerPlant = new CoalPowerPlant(group);
            
            // Assert
            Assert.IsNotNull(powerPlant);
            Assert.AreEqual(group, powerPlant.Group);
            Assert.IsFalse(powerPlant.IsOperational);
            Assert.AreEqual(0, powerPlant.PowerOutput);
        }

        [TestMethod]
        public void TestCoalPowerPlantOperation()
        {
            // Arrange
            var group = PowerConstructionGroups.CoalPower;
            var powerPlant = new CoalPowerPlant(group);
            
            // Set up initial conditions
            powerPlant.CommodityStore[Commodity.Coal] = 1000;
            
            // Act
            powerPlant.DoSimStep();
            
            // Assert
            Assert.IsTrue(powerPlant.IsOperational);
            Assert.AreEqual(PowerConstants.CoalPowerOutput, powerPlant.PowerOutput);
            Assert.IsTrue(powerPlant.CommodityStore[Commodity.HiVolt] > 0, "Power should be produced");
            Assert.IsTrue(powerPlant.CommodityStore[Commodity.Coal] < 1000, "Coal should be consumed");
            Assert.IsTrue(powerPlant.CommodityStore[Commodity.Waste] > 0, "Waste should be produced");
        }

        [TestMethod]
        public void TestSolarPowerPlantCreation()
        {
            // Arrange
            var group = PowerConstructionGroups.SolarPower;
            
            // Act
            var powerPlant = new SolarPowerPlant(group);
            
            // Assert
            Assert.IsNotNull(powerPlant);
            Assert.AreEqual(group, powerPlant.Group);
            Assert.IsFalse(powerPlant.IsOperational);
            Assert.AreEqual(0, powerPlant.PowerOutput);
        }

        [TestMethod]
        public void TestSolarPowerPlantOperation()
        {
            // Arrange
            var group = PowerConstructionGroups.SolarPower;
            var powerPlant = new SolarPowerPlant(group);
            
            // Act
            powerPlant.DoSimStep();
            
            // Assert
            Assert.IsTrue(powerPlant.IsOperational);
            Assert.AreEqual(PowerConstants.SolarPowerOutput, powerPlant.PowerOutput);
            Assert.IsTrue(powerPlant.CommodityStore[Commodity.HiVolt] > 0, "Power should be produced");
        }

        [TestMethod]
        public void TestWindPowerPlantCreation()
        {
            // Arrange
            var group = PowerConstructionGroups.WindPower;
            
            // Act
            var powerPlant = new WindPowerPlant(group);
            
            // Assert
            Assert.IsNotNull(powerPlant);
            Assert.AreEqual(group, powerPlant.Group);
            Assert.IsFalse(powerPlant.IsOperational);
            Assert.AreEqual(0, powerPlant.PowerOutput);
        }

        [TestMethod]
        public void TestSubstationCreation()
        {
            // Arrange
            var group = PowerConstructionGroups.Substation;
            
            // Act
            var substation = new Substation(group);
            
            // Assert
            Assert.IsNotNull(substation);
            Assert.AreEqual(group, substation.Group);
            Assert.IsFalse(substation.IsOperational);
            Assert.AreEqual(0, substation.PowerOutput);
        }

        [TestMethod]
        public void TestSubstationOperation()
        {
            // Arrange
            var group = PowerConstructionGroups.Substation;
            var substation = new Substation(group);
            
            // Set up initial conditions
            substation.CommodityStore[Commodity.HiVolt] = 1000;
            
            // Act
            substation.DoSimStep();
            
            // Assert
            Assert.IsTrue(substation.IsOperational);
            Assert.IsTrue(substation.PowerOutput > 0, "Power should be converted");
            Assert.IsTrue(substation.CommodityStore[Commodity.HiVolt] < 1000, "HiVolt should be consumed");
            Assert.IsTrue(substation.CommodityStore[Commodity.LoVolt] > 0, "LoVolt should be produced");
        }
    }
}
