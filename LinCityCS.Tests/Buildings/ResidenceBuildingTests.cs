using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinCityCS.SimulationCore;
using LinCityCS.SimulationCore.Buildings.Residence;

namespace LinCityCS.Tests.Buildings
{
    [TestClass]
    public class ResidenceBuildingTests
    {
        [TestMethod]
        public void TestResidenceBuildingCreation()
        {
            // Arrange
            var group = ResidenceConstructionGroups.ResidenceLL;
            
            // Act
            var residence = new ResidenceBuilding(group);
            
            // Assert
            Assert.IsNotNull(residence);
            Assert.AreEqual(group, residence.Group);
            Assert.AreEqual(0, residence.Population);
            Assert.AreEqual(ResidenceConstants.GroupResidenceLlMaxPop, residence.MaxPopulation);
        }

        [TestMethod]
        public void TestResidenceBuildingPopulationGrowth()
        {
            // Arrange
            var group = ResidenceConstructionGroups.ResidenceLL;
            var residence = new ResidenceBuilding(group);
            
            // Set up initial conditions for growth
            residence.CommodityStore[Commodity.Food] = 1000;
            residence.CommodityStore[Commodity.Goods] = 1000;
            residence.CommodityStore[Commodity.LoVolt] = 1000;
            residence.CommodityStore[Commodity.Water] = 1000;
            
            // Act
            residence.Population = 10;
            residence.DoSimStep();
            
            // Assert
            Assert.IsTrue(residence.Population >= 10, "Population should grow or stay the same with resources");
        }

        [TestMethod]
        public void TestResidenceBuildingResourceConsumption()
        {
            // Arrange
            var group = ResidenceConstructionGroups.ResidenceLL;
            var residence = new ResidenceBuilding(group);
            
            // Set up initial conditions
            residence.Population = 10;
            int initialFood = 100;
            int initialGoods = 100;
            int initialPower = 100;
            int initialWater = 100;
            
            residence.CommodityStore[Commodity.Food] = initialFood;
            residence.CommodityStore[Commodity.Goods] = initialGoods;
            residence.CommodityStore[Commodity.LoVolt] = initialPower;
            residence.CommodityStore[Commodity.Water] = initialWater;
            
            // Act
            residence.DoSimStep();
            
            // Assert
            Assert.IsTrue(residence.CommodityStore[Commodity.Food] < initialFood, "Food should be consumed");
            Assert.IsTrue(residence.CommodityStore[Commodity.Goods] < initialGoods, "Goods should be consumed");
            Assert.IsTrue(residence.CommodityStore[Commodity.LoVolt] < initialPower, "Power should be consumed");
            Assert.IsTrue(residence.CommodityStore[Commodity.Water] < initialWater, "Water should be consumed");
        }

        [TestMethod]
        public void TestResidenceBuildingLaborProduction()
        {
            // Arrange
            var group = ResidenceConstructionGroups.ResidenceLL;
            var residence = new ResidenceBuilding(group);
            
            // Set up initial conditions
            residence.Population = 10;
            residence.CommodityStore[Commodity.Labor] = 0;
            
            // Act
            residence.DoSimStep();
            
            // Assert
            Assert.IsTrue(residence.CommodityStore[Commodity.Labor] > 0, "Labor should be produced");
        }

        [TestMethod]
        public void TestResidenceBuildingWasteProduction()
        {
            // Arrange
            var group = ResidenceConstructionGroups.ResidenceLL;
            var residence = new ResidenceBuilding(group);
            
            // Set up initial conditions
            residence.Population = 10;
            residence.CommodityStore[Commodity.Waste] = 0;
            
            // Act
            residence.DoSimStep();
            
            // Assert
            Assert.IsTrue(residence.CommodityStore[Commodity.Waste] > 0, "Waste should be produced");
        }
    }
}
