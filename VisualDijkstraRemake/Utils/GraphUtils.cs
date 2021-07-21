﻿using System;
using System.Drawing;
using System.Xml;
using VisualDijkstraRemake.Models;

namespace VisualDijkstraRemake.Utils
{
    class GraphUtils
    {

        public static void saveGraphToXMLFile(Graph graph, string filename)
        {
            //XmlWriter writer = XmlWriter.Create(filename);
            XmlTextWriter writer = new XmlTextWriter(filename, null);

            //XML indentation
            writer.Formatting = Formatting.Indented;


            writer.WriteStartDocument(); // start document

            writer.WriteStartElement("graph"); // <graph>

            writer.WriteStartElement("nodes"); // <nodes>
            foreach (Node node in graph.Nodes)
            {
                writer.WriteStartElement("node");
                writer.WriteAttributeString("x", node.Location.X.ToString());
                writer.WriteAttributeString("y", node.Location.Y.ToString());
                writer.WriteString(node.Name);
                writer.WriteEndElement();
            }
            writer.WriteEndElement(); // </nodes>

            writer.WriteStartElement("edges"); // <edges>
            foreach (Edge edge in graph.Edges)
            {
                writer.WriteStartElement("edge");
                writer.WriteElementString("a", edge.NodeA.Name);
                writer.WriteElementString("a", edge.NodeB.Name);
                writer.WriteEndElement();
            }
            writer.WriteEndElement(); // </edges>


            writer.WriteEndElement(); // </graph>

            writer.WriteEndDocument(); // end document

            writer.Flush();
            writer.Close();

        }

        private static void parseXMLEdge(XmlReader reader, Graph graph)
        {

            Node a = null;
            Node b = null;
            int weight = 3;

            //System.Diagnostics.Debug.WriteLine("  parsing edge <" + reader.Name + ">  " + reader.ReadString());
            if (reader.IsStartElement() && reader.Name.Equals("edge"))
            {
                //System.Diagnostics.Debug.WriteLine(" <" + reader.Name + ">");
                weight = Int32.Parse(reader.GetAttribute("weight"));
                while (reader.Read())
                {
                    if (reader.IsStartElement() && reader.Name.Equals("a"))
                    {
                        //System.Diagnostics.Debug.WriteLine("  <" + reader.Name + "> ");

                        a = graph.GetNode(reader.ReadElementContentAsString());

                        //graph.addNewNode(new Node(reader.Name, new Point(Int32.Parse(reader.GetAttribute("x")), Int32.Parse(reader.GetAttribute("y")))));
                        break;
                    }
                }

                while (reader.Read())
                {
                    if (reader.IsStartElement() && reader.Name.Equals("a"))
                    {
                        //System.Diagnostics.Debug.WriteLine("  <" + reader.Name + "> ");
                        b = graph.GetNode(reader.ReadElementContentAsString());
                        //graph.addNewNode(new Node(reader.Name, new Point(Int32.Parse(reader.GetAttribute("x")), Int32.Parse(reader.GetAttribute("y")))));
                        break;
                    }
                }
            }

            if (a != null && b != null)
            {
                graph.CreateNewEdge(a, b, weight);
            }
            else
            {
                throw new InvalidSaveFileFormat();
            }
        }

        private static void parseXMLNode(XmlReader reader, Graph graph)
        {
            if (reader.IsStartElement() && reader.Name.Equals("node"))
            {
                int x = Int32.Parse(reader.GetAttribute("x"));
                int y = Int32.Parse(reader.GetAttribute("y"));
                //System.Diagnostics.Debug.WriteLine(" <" + reader.Name + "> ");
                graph.AddNewNode(new Node(reader.ReadElementContentAsString(), new Point(x, y)));
            }
        }

        public static Graph loadGraphFromXMLFile(string filename)
        {
            XmlReader reader = XmlReader.Create(filename);
            Graph graph = new Graph();

            reader.MoveToContent();
            while (reader.Read())
            {
                if (reader.IsStartElement() && reader.Name.Equals("nodes"))
                {
                    //System.Diagnostics.Debug.WriteLine("<" + reader.Name + ">");
                    while (reader.Read())
                    {
                        if (reader.IsStartElement() && reader.Name.Equals("node"))
                        {
                            parseXMLNode(reader.ReadSubtree(), graph);
                        }

                        if (reader.IsStartElement() && (!reader.Name.Equals("node")))
                        {
                            break;
                        }
                    }
                }


                if (reader.IsStartElement() && reader.Name.Equals("edges"))
                {
                    //System.Diagnostics.Debug.WriteLine("<" + reader.Name + ">");
                    while (reader.Read())
                    {
                        if (reader.IsStartElement() && reader.Name.Equals("edge"))
                        {
                            parseXMLEdge(reader.ReadSubtree(), graph);
                        }
                    }
                }
            }

            return graph;
        }
    }

    class InvalidSaveFileFormat : Exception
    {
        public InvalidSaveFileFormat(string message = "Invalid file format") : base(message) { }
    }
}