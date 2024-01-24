using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Node
{
    public List<Edge> edgeList = new List<Edge>();
    private GameObject _id;
    public float _xPos;
    public float _yPos;
    public float _zPos;
    public Node path = null;
    public Node camefrom;
    public float f, g, h;

    public Node(GameObject i)
    {
        _id = i;
        _xPos = i.transform.position.x;
        _yPos = i.transform.position.y;
        _zPos = i.transform.position.z;
        path = null;
    }

    public GameObject GetId()
    {
        return _id;
    }

}
