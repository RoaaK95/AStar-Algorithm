using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Edge
{
    public Node _startNode;
    public Node _endNode;

    public Edge(Node from, Node to)
    {
        _startNode = from;
        _endNode = to;
    }
}
