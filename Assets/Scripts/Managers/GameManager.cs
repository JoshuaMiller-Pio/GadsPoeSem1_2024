using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : Singleton<GameManager>
{
    public GameObject maleRhinoPrefab, femaleRhinoPrefab;
    public Rhino chosenRhino { get; set; }
    public List<GameObject> rhinos = new List<GameObject>(11);
    public int currentGold, foodCost = 10, medsCost = 20, cleanCost = 20;
    private PrefabManager _prefabManager;
    private WaypointManager _waypointManager;

    public int  maxSpawnedRhinos = 2;
    // Start is called before the first frame update
    void Start()
    {
        currentGold = 30;
       // maleRhinoPrefab = GameObject.FindGameObjectWithTag("MaleRhino");
        //femaleRhinoPrefab = GameObject.FindGameObjectWithTag("FemaleRhino");


        spawnCheck();
    }


    public void spawnCheck()
    {
        Debug.Log(SceneManager.GetSceneByBuildIndex(1).name +"" + SceneManager.GetActiveScene().name);
        if (SceneManager.GetSceneByBuildIndex(1) == SceneManager.GetActiveScene())
        {

            if (rhinos.Count == 0)
            {
                _prefabManager = GameObject.FindGameObjectWithTag("PrefabManager").GetComponent<PrefabManager>();
                maleRhinoPrefab = _prefabManager.malePrefab;
                femaleRhinoPrefab = _prefabManager.femalePrefab;
                _waypointManager = GameObject.FindGameObjectWithTag("WaypointManager").GetComponent<WaypointManager>();
                CreateRhinos(); 
            }
            else
            {
                spawnRhinos();
            }
            
        }
    }
    public void spawnRhinos()
    {
        for (int i = 0; i < 2; i++)
        {
            rhinos[i].SetActive(true);
        }
    }
    public void PlayRhinoRun()
    {
        chosenRhino.currentActivity += 30;
        chosenRhino.currentHealth -= 10;
        chosenRhino.currentHunger -= 10;
        for (int i = 0; i < rhinos.Count; i++)
        {
            rhinos[i].SetActive(false);
        }
        SceneManager.LoadScene(3);
    }

    public void CreateRhinos()
    {
        for (int t = 0; t < 10; t++)
        {
            int i = Random.Range(0, 2);
            if (i == 0)
            {
                int p = Random.Range(3, 10);

                GameObject newRhino =Instantiate(maleRhinoPrefab, _waypointManager.waypoints[p].transform.position, quaternion.identity); ;
                rhinos.Add(newRhino);
                
            }
            else
            {
                int p = Random.Range(3, 10);

                GameObject newRhino =Instantiate(femaleRhinoPrefab, _waypointManager.waypoints[p].transform.position, quaternion.identity);
                rhinos.Add(newRhino);
                
            }
        }

        for (int i = 1; i < 9; i++)
        {
            
                rhinos[i].gameObject.SetActive(false);
            
            
        }
    }

    public void returnToPen()
    {
        SceneManager.LoadScene(1);
        spawnCheck();
        StartCoroutine(waitForScene());

    }

    IEnumerator waitForScene()
    {
        while (SceneManager.GetSceneByBuildIndex(1) != SceneManager.GetActiveScene())
        {
            yield return new WaitForSeconds(0.1f);
        }
        spawnCheck();
        yield return null;
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        
    }

    public void Quit()
    {
        Application.Quit();
    }
    public void PlayRhinoSafari()
    {
        chosenRhino.currentActivity += 30;
        chosenRhino.currentHunger -= 10;
        chosenRhino.currentCleanliness -= 10;
        for (int i = 0; i < rhinos.Count; i++)
        {
            rhinos[i].SetActive(false);
        }
        SceneManager.LoadScene(2);
    }

    public void Eat()
    {
        if (currentGold < 10)
        {
            //UI not enough gold
            return;
        }
        else
        {
            currentGold -= 10;
        
            chosenRhino.ChangeAction(Rhino.RhinoAction.Eat);
        }
        
    }

    public void Clean()
    {
        if (currentGold < 15)
        {
            //UI not enough gold
            return;
        }
        else
        {
            currentGold -= 15;
            chosenRhino.ChangeAction(Rhino.RhinoAction.Clean);
        }
       
    }

    public void Sleep()
    {
        chosenRhino.ChangeAction(Rhino.RhinoAction.Sleep);
    }

    public void TakeMeds()
    {
        if (currentGold < 15)
        {
            //UI not enough gold
            return;
        }
        else
        {
            currentGold -= 15;
            chosenRhino.currentHealth += 20;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
