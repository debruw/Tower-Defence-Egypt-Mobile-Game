using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveData : MonoBehaviour
{
    public WaveEnemyData[] enemies;
    public float waveTime;

    public WaveEnemyData[] GetEnemies()
    {
        return enemies;
    }

    public float GetWaveTime()
    {
        return waveTime;
    }

}
