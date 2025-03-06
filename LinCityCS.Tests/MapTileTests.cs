using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinCityCS.SimulationCore;

namespace LinCityCS.Tests
{
    [TestClass]
    public class MapTileTests
    {
        [TestMethod]
        public void TestMapTileCreation()
        {
            // Arrange & Act
            var tile = new MapTile(10, 20);
            
            // Assert
            Assert.AreEqual(10, tile.X);
            Assert.AreEqual(20, tile.Y);
            Assert.IsNull(tile.Construction);
            Assert.AreEqual(0, tile.Pollution);
        }

        [TestMethod]
        public void TestSetConstruction()
        {
            // Arrange
            var tile = new MapTile(10, 20);
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
            tile.Construction = construction;
            
            // Assert
            Assert.IsNotNull(tile.Construction);
            Assert.AreEqual(construction, tile.Construction);
        }

        [TestMethod]
        public void TestSetPollution()
        {
            // Arrange
            var tile = new MapTile(10, 20);
            
            // Act
            tile.Pollution = 100;
            
            // Assert
            Assert.AreEqual(100, tile.Pollution);
        }

        [TestMethod]
        public void TestAddPollution()
        {
            // Arrange
            var tile = new MapTile(10, 20);
            tile.Pollution = 100;
            
            // Act
            tile.AddPollution(50);
            
            // Assert
            Assert.AreEqual(150, tile.Pollution);
        }
    }
}
