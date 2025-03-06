using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinCityCS.SimulationCore;

namespace LinCityCS.Tests
{
    [TestClass]
    public class WorldTests
    {
        [TestMethod]
        public void TestWorldCreation()
        {
            // Arrange & Act
            var world = new World(100, 100);
            
            // Assert
            Assert.AreEqual(100, world.Width);
            Assert.AreEqual(100, world.Height);
            Assert.IsNotNull(world.Tiles);
        }

        [TestMethod]
        public void TestIsInside()
        {
            // Arrange
            var world = new World(100, 100);
            
            // Act & Assert
            Assert.IsTrue(world.IsInside(0, 0));
            Assert.IsTrue(world.IsInside(50, 50));
            Assert.IsTrue(world.IsInside(99, 99));
            Assert.IsFalse(world.IsInside(-1, 50));
            Assert.IsFalse(world.IsInside(50, -1));
            Assert.IsFalse(world.IsInside(100, 50));
            Assert.IsFalse(world.IsInside(50, 100));
        }

        [TestMethod]
        public void TestGetTile()
        {
            // Arrange
            var world = new World(100, 100);
            
            // Act
            var tile = world.GetTile(50, 50);
            
            // Assert
            Assert.IsNotNull(tile);
            Assert.AreEqual(50, tile.X);
            Assert.AreEqual(50, tile.Y);
        }

        [TestMethod]
        public void TestGetTileOutOfBounds()
        {
            // Arrange
            var world = new World(100, 100);
            
            // Act & Assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => world.GetTile(-1, 50));
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => world.GetTile(50, -1));
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => world.GetTile(100, 50));
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => world.GetTile(50, 100));
        }
    }
}
