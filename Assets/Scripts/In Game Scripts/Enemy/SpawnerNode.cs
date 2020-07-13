using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TDLWRP.GAME;
using TDLWRP.ENEMY;

public class SpawnerNode : MonoBehaviour
{
    int currentEnemyNo;
    float timeInterval;
    float timeIntervalMax;

    GameController my_gameControl;
    EnemySpawner my_Spawner;

    WaveData my_Wave;
    int enemycount = 0;


    private void Start()
    {
        currentEnemyNo = 0;
        my_gameControl = FindObjectOfType<GameController>();
    }

    private void FixedUpdate()
    {
        if (timeInterval > 0)
        {
            timeInterval -= Time.deltaTime;
        }
        else
        {
            if (currentEnemyNo < enemycount)
            {
                SpawnEnemy();
                timeInterval = my_Wave.GetEnemies()[currentEnemyNo].GetTimeDelay();
                currentEnemyNo++;
            }
        }
    }

    void SpawnEnemy()
    {
        GameObject enemySpawned;
        enemySpawned = Instantiate(my_Wave.GetEnemies()[currentEnemyNo].GetEnemyId(), transform);     
        enemySpawned.GetComponent<Enemy>().SetWaypoints(my_Spawner.GetPath(my_Wave.GetEnemies()[currentEnemyNo].GetPathId()).GetWaypoint());
        my_gameControl.AddEnemy(enemySpawned);
    }

    public void SetWave(WaveData w, EnemySpawner s)
    {
        my_Spawner = s;
        my_Wave = w;
        enemycount = w.GetEnemies().Length;
    }
}
