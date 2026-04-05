using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trafficSpawner : MonoBehaviour
{
    public GameObject carPrefab;
    float[] lanePositionX = {-2.0f, 0.0f, 2.0f};
    public float spawnLocation = 8f;
    
    public float spawnInterval = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnTraffic", 3.0f, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnTraffic()
    {
        int lastLanePos = -1;
        int randomX = Random.Range(0, lanePositionX.Length);
        do
        {
            lastLanePos = Random.Range(0, lanePositionX.Length);
        } 
        while (randomX == lastLanePos);

        lastLanePos = randomX;

           
        Vector3 spawnPosition = new Vector3(lanePositionX[randomX], spawnLocation, 0f);

        Instantiate(carPrefab, spawnPosition, Quaternion.identity);
    }
}
