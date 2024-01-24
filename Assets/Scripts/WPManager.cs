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
    [SerializeField] private Link[] links;

    void Start()
    {

    }

}

