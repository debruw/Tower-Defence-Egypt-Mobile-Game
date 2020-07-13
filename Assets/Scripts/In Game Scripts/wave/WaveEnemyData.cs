using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveEnemyData : MonoBehaviour
{
    public GameObject enemyId;
    public float timeDelay;
    public int pathId;

    public GameObject GetEnemyId()
    {
        return enemyId;
    }

    public float GetTimeDelay()
    {
        return timeDelay;
    }

    public int GetPathId()
    {
        return pathId;
    }

}
