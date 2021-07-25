using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VisualDijkstraRemake.Models.Tests
{
    [TestClass()]
    public class GraphTests
    {
        [TestMethod()]
        public void AddNewNode_AddingValidNodeByObject_NodeAdded()
        {
            Graph graph = new Graph();
            Node nodeToTest = new Node("A", new System.Drawing.Point(50, 50));

            graph.AddNewNode(nodeToTest);

            Assert.IsTrue(graph.Nodes.Contains(nodeToTest));
        }

        [TestMethod()]
        public void AddNewNode_AddingNull_NodeNotAdded()
        {
            Graph graph = new Graph();
            Node nodeToTest = null;

            graph.AddNewNode(nodeToTest);

            Assert.IsFalse(graph.Nodes.Contains(nodeToTest));
        }

        [TestMethod()]
        [ExpectedException(typeof(NodeAlreadyExistsException))]
        public void AddNewNode_AddingAlreadyExistsingNodeByObject_ExceptionThrown()
        {
            Graph graph = new Graph();
            Node nodeToTest = new Node("A", new System.Drawing.Point(50, 50));

            graph.AddNewNode(nodeToTest);
            graph.AddNewNode(nodeToTest);

            Assert.AreEqual(graph.Nodes.Count, 1);

        }

        [TestMethod()]
        [ExpectedException(typeof(NodeAlreadyExistsException))]
        public void AddNewNode_AddingAlreadyExistsingNodeByName_ExceptionThrown()
        {
            Graph graph = new Graph();

            graph.AddNewNode("A", new System.Drawing.Point(50, 50));
            graph.AddNewNode("A", new System.Drawing.Point(50, 50));

        }


        [TestMethod()]
        public void GetNode_SearchingExistingNode_ReturnsNodeFound()
        {
            Graph graph = new Graph();

            Node nodeToTest = new Node("A", new System.Drawing.Point(50, 50));
            graph.AddNewNode(nodeToTest);

            Assert.IsTrue(graph.GetNode("A") == nodeToTest);
        }


        [TestMethod()]
        public void GetNode_SearchingNull_ReturnsNull()
        {
            Graph graph = new Graph();

            Assert.IsNull(graph.GetNode(null));
        }

        [TestMethod()]
        public void GetNode_SearchingUnknownNode_ReturnsNull()
        {
            Graph graph = new Graph();

            graph.AddNewNode(new Node("A", new System.Drawing.Point(50, 50)));

            Assert.IsNull(graph.GetNode("B"));
        }

        [TestMethod()]
        public void MoveNode_TryingToMoveCorrectNodeByObject_NodeMoved()
        {
            Graph graph = new Graph();
            Node nodeToMove = new Node("A", new System.Drawing.Point(50, 50));
            graph.AddNewNode(nodeToMove);

            graph.MoveNode(nodeToMove, new System.Drawing.Point(600, 600));

            Assert.AreEqual(nodeToMove.Location, new System.Drawing.Point(600, 600) - new System.Drawing.Size(Node.SizeLength, Node.SizeLength) / 2);
        }

        [TestMethod()]
        public void MoveNode_TryingToMoveCorrectNodeByName_NodeMoved()
        {
            Graph graph = new Graph();
            Node nodeToMove = new Node("A", new System.Drawing.Point(50, 50));
            graph.AddNewNode(nodeToMove);

            graph.MoveNode("A", new System.Drawing.Point(600, 600));

            Assert.AreEqual(nodeToMove.Location, new System.Drawing.Point(600, 600) - new System.Drawing.Size(Node.SizeLength, Node.SizeLength) / 2);
        }
    }
}