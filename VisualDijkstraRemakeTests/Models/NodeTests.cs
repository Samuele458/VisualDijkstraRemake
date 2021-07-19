using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace VisualDijkstraRemake.Models.Tests
{
    [TestClass()]
    public class NodeTests
    {
        [TestMethod()]
        public void Contains_LocationInsideBoundaries_ReturnsTrue()
        {

            Node node = new Node("A", new Point(100, 200));

            Point locationToTest = new Point(100 + Node.Size / 4, 200 + Node.Size / 4);

            Assert.IsTrue(node.Contains(locationToTest));
        }

        [TestMethod()]
        public void Contains_LocationExceedsWidth_ReturnsFalse()
        {

            Node node = new Node("A", new Point(100, 200));

            Point locationToTest = new Point(100 + Node.Size, 200 + Node.Size / 4);

            Assert.IsFalse(node.Contains(locationToTest));
        }

        [TestMethod()]
        public void Contains_LocationExceedsHeight_ReturnsFalse()
        {

            Node node = new Node("A", new Point(100, 200));

            Point locationToTest = new Point(100 + Node.Size / 4, 200 + Node.Size);

            Assert.IsFalse(node.Contains(locationToTest));
        }
    }
}