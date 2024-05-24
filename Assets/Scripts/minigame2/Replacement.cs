using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Replacement : MonoBehaviour
{
    public Transform groundSpawn, obstacleSpawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

 

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "ground2d")
        {
            other.gameObject.transform.localPosition = groundSpawn.position;
        }
        if (other.tag == "obstacle")
        {
            other.gameObject.transform.localPosition = obstacleSpawn.localPosition;
        }
        
    }
}
