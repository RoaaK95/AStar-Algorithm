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

    public bool AStar(GameObject startId, GameObject endId)
    {
        if (startId == endId)
        {
            pathList.Clear();
            return false;
        }

        Node start = FindNode(startId);
        Node end = FindNode(endId);

        if (start == null || end == null)
        {
            return false;
        }

        List<Node> open = new List<Node>();
        List<Node> closed = new List<Node>();
        float tentative_g_score = 0.0f;
        bool tentative_is_better;
        start.g = 0.0f;
        start.h = Distance(start, end);
        start.f = start.h;

        open.Add(start);

        while (open.Count > 0)
        {
            int i = LowestF(open);
            Node thisNode = open[i];
            if (thisNode.GetId() == endId)
            {
                ReconstructPath(start, end);
                return true;
            }

            open.RemoveAt(i);
            closed.Add(thisNode);
            Node neighbour;

            foreach (Edge e in thisNode.edgeList)
            {
                neighbour = e._endNode;

                if (closed.IndexOf(neighbour) > -1)
                    continue;

                tentative_g_score = thisNode.g + Distance(thisNode, neighbour);
                if (open.IndexOf(neighbour) == -1)
                {
                    open.Add(neighbour);
                    tentative_is_better = true;
                }
                else if (tentative_g_score < neighbour.g)
                {
                    tentative_is_better = true;
                }
                else
                {
                    tentative_is_better = false;
                }

                if (tentative_is_better)
                {
                    neighbour.camefrom = thisNode;
                    neighbour.g = tentative_g_score;
                    neighbour.h = Distance(neighbour, end);
                    neighbour.f = neighbour.g + neighbour.h;
                }
            }

        }
        return false;
    }

    public void ReconstructPath(Node startId, Node endId)
    {
        pathList.Clear();
        pathList.Add(endId);

        Node p = endId.camefrom;
        while (p != null && p != startId)
        {
            pathList.Insert(0, p);
            p = p.camefrom;
        }
        pathList.Insert(0, startId);
    }
    float Distance(Node a, Node b)
    {
        return (Vector3.SqrMagnitude(a.GetId().transform.position - b.GetId().transform.position));
    }

    int LowestF(List<Node> l)
    {
        float lowestF = 0.0f;
        int count = 0;
        int iteratorCount = 0;

        lowestF = l[0].f;

        for (int i = 0; i < l.Count; i++)
        {
            if (l[i].f < lowestF)
            {
                lowestF = l[i].f;
                iteratorCount = count;
            }
            count++;
        }
        return iteratorCount;
    }
}
