using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public struct Link
{
    public enum direction { UNI, BI };
    public GameObject node1, node2;
    public direction dir;
}

public class WPManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _waypoints;
    [SerializeField] private Link[] _links;
    public Graph _graph = new Graph();

    void Start()
    {
        if (_waypoints.Length > 0)
        {
            foreach (GameObject wp in _waypoints)
            {
                _graph.AddNode(wp);
                foreach (Link l in _links)
                {
                    _graph.AddEdge(l.node1, l.node2);
                    if (l.dir == Link.direction.BI)
                    {
                        _graph.AddEdge(l.node2, l.node1);

                    }

                }
            }

        }
    }
}

