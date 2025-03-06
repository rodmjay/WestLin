using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinCityCS.SimulationCore;
using System.Collections.Generic;

namespace LinCityCS.Tests
{
    [TestClass]
    public class ConstructionTests
    {
        [TestMethod]
        public void TestConstructionCreation()
        {
            // Arrange
            var constructionGroup = new TestConstructionGroup(
                "Test Construction",
                false,
                1,
                1,
                0,
                1,
                1,
                0,
                100,
                0,
                0);
            
            // Act
            var construction = new TestConstruction(constructionGroup);
            
            // Assert
            Assert.IsNotNull(construction);
            Assert.AreEqual(constructionGroup, construction.Group);
            Assert.IsFalse(construction.IsBulldozed);
            Assert.AreEqual(0, construction.X);
            Assert.AreEqual(0, construction.Y);
            Assert.AreEqual(0, construction.Frame);
            Assert.AreEqual(0, construction.Pollution);
        }

        [TestMethod]
        public void TestConstructionPosition()
        {
            // Arrange
            var constructionGroup = new TestConstructionGroup(
                "Test Construction",
                false,
                1,
                1,
                0,
                1,
                1,
                0,
                100,
                0,
                0);
            var construction = new TestConstruction(constructionGroup);
            
            // Act
            construction.X = 10;
            construction.Y = 20;
            
            // Assert
            Assert.AreEqual(10, construction.X);
            Assert.AreEqual(20, construction.Y);
        }

        [TestMethod]
        public void TestConstructionBulldoze()
        {
            // Arrange
            var constructionGroup = new TestConstructionGroup(
                "Test Construction",
                false,
                1,
                1,
                0,
                1,
                1,
                0,
                100,
                0,
                0);
            var construction = new TestConstruction(constructionGroup);
            
            // Act
            construction.IsBulldozed = true;
            
            // Assert
            Assert.IsTrue(construction.IsBulldozed);
        }

        [TestMethod]
        public void TestConstructionCommodityStore()
        {
            // Arrange
            var constructionGroup = new TestConstructionGroup(
                "Test Construction",
                false,
                1,
                1,
                0,
                1,
                1,
                0,
                100,
                0,
                0);
            var construction = new TestConstruction(constructionGroup);
            
            // Act
            construction.CommodityStore[Commodity.Food] = 100;
            construction.CommodityStore[Commodity.Labor] = 200;
            
            // Assert
            Assert.AreEqual(100, construction.CommodityStore[Commodity.Food]);
            Assert.AreEqual(200, construction.CommodityStore[Commodity.Labor]);
        }

        [TestMethod]
        public void TestConstructionCommodityMaxConsumption()
        {
            // Arrange
            var constructionGroup = new TestConstructionGroup(
                "Test Construction",
                false,
                1,
                1,
                0,
                1,
                1,
                0,
                100,
                0,
                0);
            var construction = new TestConstruction(constructionGroup);
            
            // Act
            construction.CommodityMaxConsumption[Commodity.Food] = 100;
            construction.CommodityMaxConsumption[Commodity.Labor] = 200;
            
            // Assert
            Assert.AreEqual(100, construction.CommodityMaxConsumption[Commodity.Food]);
            Assert.AreEqual(200, construction.CommodityMaxConsumption[Commodity.Labor]);
        }

        [TestMethod]
        public void TestConstructionCommodityMaxProduction()
        {
            // Arrange
            var constructionGroup = new TestConstructionGroup(
                "Test Construction",
                false,
                1,
                1,
                0,
                1,
                1,
                0,
                100,
                0,
                0);
            var construction = new TestConstruction(constructionGroup);
            
            // Act
            construction.CommodityMaxProduction[Commodity.Food] = 100;
            construction.CommodityMaxProduction[Commodity.Labor] = 200;
            
            // Assert
            Assert.AreEqual(100, construction.CommodityMaxProduction[Commodity.Food]);
            Assert.AreEqual(200, construction.CommodityMaxProduction[Commodity.Labor]);
        }
    }
}
