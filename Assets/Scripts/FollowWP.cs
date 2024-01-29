using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
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

    public void GoToTower()
    {
        g.AStar(currentNode, wps[0]);
        currentWP = 0;
    }

    public void GoToRocket()
    {
        g.AStar(currentNode, wps[1]);
        currentWP = 0;
    }

    public void GoToSolarPanels()
    {
        g.AStar(currentNode, wps[2]);
        currentWP = 0;
    }

    public void GoToDomes()
    {
        g.AStar(currentNode, wps[3]);
        currentWP = 0;
    }
    public void GoToBuilding()
    {
        g.AStar(currentNode, wps[4]);
        currentWP = 0;
    }
    void LateUpdate()
    {
        if (g.pathList.Count == 0 || currentWP == g.pathList.Count)
            return;


        if (Vector3.Distance(g.pathList[currentWP].GetId().transform.position, transform.position) < accuracy)
        {
            currentNode = g.pathList[currentWP].GetId();
            currentWP++;
        }

        if (currentWP < g.pathList.Count)
        {
            goal = g.pathList[currentWP].GetId().transform;
            Vector3 lookAtGoal = new Vector3(goal.position.x, transform.position.y, goal.position.z);
            Vector3 direction = lookAtGoal - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotSpeed);
            transform.Translate(0.0f, 0.0f, Time.deltaTime * speed);

        }
    }
}
