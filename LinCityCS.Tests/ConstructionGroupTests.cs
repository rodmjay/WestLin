using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinCityCS.SimulationCore;

namespace LinCityCS.Tests
{
    [TestClass]
    public class ConstructionGroupTests
    {
        [TestMethod]
        public void TestConstructionGroupCreation()
        {
            // Arrange & Act
            var constructionGroup = new TestConstructionGroup(
                "Test Construction",
                false,
                1,
                2,
                100,
                25,
                50,
                10,
                1000,
                50,
                5);
            
            // Assert
            Assert.AreEqual("Test Construction", constructionGroup.Name);
            Assert.IsFalse(constructionGroup.NoCredit);
            Assert.AreEqual(1, constructionGroup.Group);
            Assert.AreEqual(2, constructionGroup.Size);
            Assert.AreEqual(100, constructionGroup.Colour);
            Assert.AreEqual(25, constructionGroup.CostMul);
            Assert.AreEqual(50, constructionGroup.BulCost);
            Assert.AreEqual(10, constructionGroup.FireChance);
            Assert.AreEqual(1000, constructionGroup.Cost);
            Assert.AreEqual(50, constructionGroup.Tech);
            Assert.AreEqual(5, constructionGroup.Range);
        }

        [TestMethod]
        public void TestConstructionGroupCommodityRules()
        {
            // Arrange
            var constructionGroup = new TestConstructionGroup(
                "Test Construction",
                false,
                1,
                2,
                100,
                25,
                50,
                10,
                1000,
                50,
                5);
            
            // Act
            constructionGroup.CommodityRuleCount[Commodity.Food].Take = true;
            constructionGroup.CommodityRuleCount[Commodity.Food].Give = false;
            constructionGroup.CommodityRuleCount[Commodity.Food].MaxLoad = 100;
            
            constructionGroup.CommodityRuleCount[Commodity.Labor].Take = false;
            constructionGroup.CommodityRuleCount[Commodity.Labor].Give = true;
            constructionGroup.CommodityRuleCount[Commodity.Labor].MaxLoad = 200;
            
            // Assert
            Assert.IsTrue(constructionGroup.CommodityRuleCount[Commodity.Food].Take);
            Assert.IsFalse(constructionGroup.CommodityRuleCount[Commodity.Food].Give);
            Assert.AreEqual(100, constructionGroup.CommodityRuleCount[Commodity.Food].MaxLoad);
            
            Assert.IsFalse(constructionGroup.CommodityRuleCount[Commodity.Labor].Take);
            Assert.IsTrue(constructionGroup.CommodityRuleCount[Commodity.Labor].Give);
            Assert.AreEqual(200, constructionGroup.CommodityRuleCount[Commodity.Labor].MaxLoad);
        }

        [TestMethod]
        public void TestCreateConstruction()
        {
            // Arrange
            var constructionGroup = new TestConstructionGroup(
                "Test Construction",
                false,
                1,
                2,
                100,
                25,
                50,
                10,
                1000,
                50,
                5);
            
            // Act
            var construction = constructionGroup.CreateConstruction();
            
            // Assert
            Assert.IsNotNull(construction);
            Assert.IsInstanceOfType(construction, typeof(TestConstruction));
            Assert.AreEqual(constructionGroup, construction.Group);
        }
    }
}
