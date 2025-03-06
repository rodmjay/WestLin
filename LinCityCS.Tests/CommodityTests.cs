using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinCityCS.SimulationCore;

namespace LinCityCS.Tests
{
    [TestClass]
    public class CommodityTests
    {
        [TestMethod]
        public void TestCommodityEnumValues()
        {
            // Assert
            Assert.AreEqual(0, (int)Commodity.None);
            Assert.AreEqual(1, (int)Commodity.Food);
            Assert.AreEqual(2, (int)Commodity.Labor);
            Assert.AreEqual(3, (int)Commodity.Goods);
            Assert.AreEqual(4, (int)Commodity.Coal);
            Assert.AreEqual(5, (int)Commodity.Ore);
            Assert.AreEqual(6, (int)Commodity.Steel);
            Assert.AreEqual(7, (int)Commodity.Waste);
            Assert.AreEqual(8, (int)Commodity.HiVolt);
            Assert.AreEqual(9, (int)Commodity.LoVolt);
            Assert.AreEqual(10, (int)Commodity.Water);
        }
    }
}
