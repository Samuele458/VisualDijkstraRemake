using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace VisualDijkstraRemake.Models.Tests
{
    [TestClass()]
    public class EdgeTests
    {
        [TestMethod()]
        public void Equals_ComparingTheSameEdgeObject_ReturnsTrue()
        {
            Node a = new Node("A", new Point(200, 100));
            Node b = new Node("B", new Point(300, 150));
            Edge edgeA = new Edge(a, b, 5);

            Assert.IsTrue(edgeA.Equals(edgeA));
        }


        [TestMethod()]
        public void Equals_ComparingDifferentEdgeWithSameNodeNames_ReturnsTrue()
        {
            Node a = new Node("A", new Point(200, 100));
            Node b = new Node("B", new Point(300, 150));
            Edge edgeA = new Edge(a, b, 5);

            Node c = new Node("A", new Point(200, 100));
            Node d = new Node("B", new Point(300, 150));
            Edge edgeB = new Edge(c, d, 5);

            Assert.IsTrue(edgeA.Equals(edgeB));

        }

        [TestMethod()]
        public void Equals_ComparingDifferentEdge_ReturnsFalse()
        {
            Node a = new Node("A", new Point(200, 100));
            Node b = new Node("B", new Point(300, 150));
            Edge edgeA = new Edge(a, b, 5);

            Node c = new Node("C", new Point(200, 100));
            Node d = new Node("D", new Point(300, 150));
            Edge edgeB = new Edge(c, d, 5);

            Assert.IsFalse(edgeA.Equals(edgeB));

        }



    }
}