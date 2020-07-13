using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathClass : MonoBehaviour
{
    public Transform[] waypoints;

    public Transform[] GetWaypoint()
    {
        return waypoints;
    }

}
