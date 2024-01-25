using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph
{
    private List<Node> nodes = new List<Node>();
    public List<Node> pathList = new List<Node>();
    private List<Edge> edges = new List<Edge>();

    public Graph()
    {

    }
    public void AddNode(GameObject id)
    {
        Node node = new Node(id);
        nodes.Add(node);
    }

    public void AddEdge(GameObject fromNode, GameObject toNode)
    {
        Node from = FindNode(fromNode);
        Node to = FindNode(toNode);

        if (from != null && to != null)
        {
            Edge e = new Edge(from, to);
            edges.Add(e);
            from.edgeList.Add(e);
        }
    }

    public GameObject GetPathPoint(int index)
    {
        return pathList[index].GetId();
    }
    private Node FindNode(GameObject id)
    {
        foreach (Node n in nodes)
        {
            if (n.GetId() == id)
                return n;
        }
        return null;
    }
}
