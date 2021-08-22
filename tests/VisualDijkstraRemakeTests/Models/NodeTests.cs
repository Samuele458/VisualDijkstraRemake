using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using VisualDijkstraLib.Models;

namespace DesktopApp.Models.Tests
{
    [TestClass()]
    public class NodeTests
    {
        [TestMethod()]
        public void Contains_LocationInsideBoundaries_ReturnsTrue()
        {

            Node node = new Node("A", new Point(100, 200));

            Point locationToTest = new Point(100 + Node.SizeLength / 4, 200 + Node.SizeLength / 4);

            Assert.IsTrue(node.Contains(locationToTest));
        }

        [TestMethod()]
        public void Contains_LocationExceedsWidth_ReturnsFalse()
        {

            Node node = new Node("A", new Point(100, 200));

            Point locationToTest = new Point(100 + Node.SizeLength, 200 + Node.SizeLength / 4);

            Assert.IsFalse(node.Contains(locationToTest));
        }

        [TestMethod()]
        public void Contains_LocationExceedsHeight_ReturnsFalse()
        {

            Node node = new Node("A", new Point(100, 200));

            Point locationToTest = new Point(100 + Node.SizeLength / 4, 200 + Node.SizeLength);

            Assert.IsFalse(node.Contains(locationToTest));
        }

        [TestMethod()]
        public void Contains_LocationExceedsWidthAndHeight_ReturnsFalse()
        {

            Node node = new Node("A", new Point(100, 200));

            Point locationToTest = new Point(0, 0);

            Assert.IsFalse(node.Contains(locationToTest));
        }


        [TestMethod()]
        public void Equals_ComparingTwoDifferentNodes_ReturnsFalse()
        {
            Node a = new Node("A", new Point(200, 100));
            Node b = new Node("B", new Point(200, 100));

            Assert.IsFalse(a.Equals(b));
            Assert.IsFalse(b.Equals(a));
        }

        [TestMethod()]
        public void Equals_ComparingTwoNodesWithSameName_ReturnsTrue()
        {
            Node a = new Node("A", new Point(200, 100));
            Node b = new Node("A", new Point(300, 100));

            Assert.IsTrue(a.Equals(b));
            Assert.IsTrue(b.Equals(a));
        }

        [TestMethod()]
        public void Equals_ComparingTheSameNodeObject_ReturnsTrue()
        {
            Node a = new Node("A", new Point(200, 100));

            Assert.IsTrue(a.Equals(a));
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Equals_ComparingWithNull_ExceptionThrown()
        {
            Node a = new Node("A", new Point(200, 100));

            a.Equals(null);
        }


    }
}