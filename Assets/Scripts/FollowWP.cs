using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWP : MonoBehaviour
{
    Transform goal;
    float speed = 5.0f;
    float accuracy = 5.0f;
    float rotSpeed = 2.0f;
    GameObject[] wps;
    GameObject currentNode;
    int currentWP = 0;
    Graph g;
    public GameObject wpManager;
    void Start()
    {
        Time.timeScale = 5.0f;
        wps = wpManager.GetComponent<WPManager>()._waypoints;
        g = wpManager.GetComponent<WPManager>()._graph;
        currentNode = wps[0];

    }

    void Update()
    {

    }
}
