using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaveManager : MonoBehaviour
{
    public matchScore MatchScore;
    public GameObject enemyPrefab1;
    public GameObject enemyPrefab2;
    public GameObject enemyPrefab3;
    private float waveTime = 90;
    private float peaceTime = 30;
    private bool state = true;
    private int baseNumEnemies = 3;
    private float enemyHealthMultiplier = 1.2f;
    private float enemyIncreasePercentage = 0.3f;
    private int numEnemies;

    public Transform[] spawnAreas;


    public void Start()
    {
        numEnemies = baseNumEnemies;
    }

    void Update()
    {
        switch (state)
        {
            case true:
                if (peaceTime > 0)
                {
                    Constrants.isPeacemode = true;
                    MatchScore.SetMatchState("Peace");
                    MatchScore.SetTimeRemaing(peaceTime);
                    peaceTime -= Time.deltaTime;
                }
                else
                {
                    state = !state;
                    waveTime = 30;
                    SpawnEnemies(); // Spawn enemies at the start of each wave
                }

                break;
            case false:
                if (waveTime > 0)
                {
                    Constrants.isPeacemode = false;
                    MatchScore.SetMatchState("Wave " + Constrants.currentWave);
                    MatchScore.SetTimeRemaing(waveTime);
                    waveTime -= Time.deltaTime;
                }
                else
                {
                    state = !state;
                    Constrants.currentWave++;
                    peaceTime = 30;
                    numEnemies = Mathf.RoundToInt(baseNumEnemies *
                                                  Mathf.Pow(1 + enemyIncreasePercentage, Constrants.currentWave - 1));
                }

                break;
        }
    }

    private void SpawnEnemies()
    {
        numEnemies = Mathf.RoundToInt(numEnemies * Mathf.Pow(1 + enemyIncreasePercentage, Constrants.currentWave - 1));
        for (int i = 0; i < numEnemies; i++)
        {
            //Spawn en random enemy
            float rand = Random.value;
            GameObject enemyPrefabToSpawn;
            if (rand < 0.8f)
            {
                enemyPrefabToSpawn = enemyPrefab1;
            }
            else if (rand < 0.95f)
            {
                enemyPrefabToSpawn = enemyPrefab2;
            }
            else
            {
                enemyPrefabToSpawn = enemyPrefab3;
            }

            //Decide hvilken platfrom at spawne på
            int spawnAreaIndex = Random.Range(0, 4);
            Transform selectedSpawnArea = spawnAreas[spawnAreaIndex];
            Vector3 platformPosition = selectedSpawnArea.position;
            Vector3 spawnPosition = platformPosition +
                                    new Vector3(
                                        Random.Range(-selectedSpawnArea.localScale.x / 2,
                                            selectedSpawnArea.localScale.x / 2), 0,
                                        Random.Range(-selectedSpawnArea.localScale.z / 2,
                                            selectedSpawnArea.localScale.z / 2));
            spawnPosition.y =
                platformPosition.y + 2; 

            GameObject enemy1 = Instantiate(enemyPrefabToSpawn, spawnPosition, Quaternion.identity);
            enemy1.GetComponent<Enemy>().health = (int)((float)enemy1.GetComponent<Enemy>().health *
                                                        Mathf.Pow(enemyHealthMultiplier, Constrants.currentWave - 1));
        }
    }
}