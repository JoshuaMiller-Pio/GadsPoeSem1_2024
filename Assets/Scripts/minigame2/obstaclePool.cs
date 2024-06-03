using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class obstaclePool : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;

    public GameObject spawnpoint;
    // Start is called before the first frame update
    void OnEnable()
    {
        ObstacleMovement.onSpawnDist += spawnobj;
        spawnobj();
            
       

    }

    private void OnDisable()
    {
        ObstacleMovement.onSpawnDist -= spawnobj;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnobj()
    {
        int i = Random.Range(0, obstaclePrefabs.Length - 1);
        GameObject newObjs = Instantiate(obstaclePrefabs[i], spawnpoint.transform.position, Quaternion.identity);
        newObjs.transform.parent = this.transform;
    }
   
}
