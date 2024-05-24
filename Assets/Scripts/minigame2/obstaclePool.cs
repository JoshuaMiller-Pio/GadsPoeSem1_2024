using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstaclePool : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    private List<GameObject> obstacles = new List<GameObject>();
    public GameObject spawnpoint;
    // Start is called before the first frame update
    void Start()
    {
        
        for (int i = 0; i < obstaclePrefabs.Length; i++)
        {
           
                GameObject newObjs = Instantiate(obstaclePrefabs[i], spawnpoint.transform.position, Quaternion.identity);
                newObjs.transform.parent = this.transform;
                newObjs.SetActive(false);
                obstacles.Add(newObjs);
            
        }

        StartCoroutine(Awaken());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Awaken()
    {
        for (int i = 0; i < obstacles.Count; i++)
        {
            obstacles[i].SetActive(true);
            yield return new WaitForSecondsRealtime(3f);

        }
        yield return null;
    }
}
