using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trafficSpawner : MonoBehaviour
{
    public GameObject[] carPrefab;
    public float[] lanePositionX = new float[2];

    public float spawnLocation = 8f;
    public float spawnInterval = 2.0f;

    int lastLanePos = -1;

    void Start()
    {
        InvokeRepeating(nameof(SpawnTraffic), 3.0f, spawnInterval);
    }

    void SpawnTraffic()
    {
        //random lane
        int randomLane;
        do
        {
            randomLane = Random.Range(0, lanePositionX.Length);
        }
        while (randomLane == lastLanePos);

        lastLanePos = randomLane;

        //variabel random car spawn
        int randomCar = Random.Range(0, carPrefab.Length);

        Vector3 spawnPosition = new Vector3(
            lanePositionX[randomLane],
            spawnLocation,
            0f
        );

        Instantiate(carPrefab[randomCar], spawnPosition, Quaternion.identity);
    }
}