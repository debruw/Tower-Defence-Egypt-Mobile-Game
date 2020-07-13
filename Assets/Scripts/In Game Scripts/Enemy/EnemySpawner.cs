using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TDLWRP.GAME;

namespace TDLWRP.ENEMY
{
    public class EnemySpawner : MonoBehaviour
    {
        GameController my_gameController;

        public PathClass[] waypoints;

        public WaveData[] waves;

        public GameObject spawnerNode;

        float timer = 0f;


        int currentWave = 0;
        public int waveCount = 5;

        bool isFinished = false;

        private void Start()
        {
            my_gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
            timer = 2f;
            waveCount = waves.Length;
        }

        private void Update()
        {
            if (!isFinished)
            {
                if (timer > 0)
                {
                    timer -= Time.deltaTime;
                }
                else
                {
                    if (currentWave < waveCount)
                    {
                        GameObject node = Instantiate(spawnerNode, transform);
                        node.GetComponent<SpawnerNode>().SetWave(waves[currentWave], this);
                        my_gameController.SetWave(currentWave);
                        timer = waves[currentWave].GetWaveTime();
                        Debug.Log(timer);
                    }
                    else
                    {
                        my_gameController.SetWave(currentWave);
                        my_gameController.StartCheckingWin();
                        isFinished = true;
                    }
                    currentWave++;
                }
            }
        }

        public PathClass GetPath(int i)
        {
            return waypoints[i];
        }

    }
}