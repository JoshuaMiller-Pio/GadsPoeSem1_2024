using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Minigame1Manager : MonoBehaviour
{
    public List<Transform> spawnPoints;

    public List<GameObject> animals;
    
    // Start is called before the first frame update
    void Start()
    {
        int randomPoint;
        int randomAnimal;
        while(animals.Count > 0)
        {
            randomPoint = Random.Range(0, spawnPoints.Count);
            randomAnimal = Random.Range(0, animals.Count );
            Instantiate(animals[randomAnimal],spawnPoints[randomPoint].transform.position, Quaternion.identity );
            animals.RemoveAt(randomAnimal);
            spawnPoints.RemoveAt(randomPoint);
            
        }
    }

    public void SceneReturn()
    {
        Debug.Log("ah");
        GameManager.Instance.currentGold += 30;
       
        GameManager.Instance.returnToPen();

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
