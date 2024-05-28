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
            
        }
       
    }

    public void PlayRhinoRun()
    {
        chosenRhino.currentActivity += 30;
        chosenRhino.currentHealth -= 10;
        chosenRhino.currentHunger -= 10;
        SceneManager.LoadScene(3);
    }

    public void CreateRhinos()
    {
        for (int t = 0; t < 10; t++)
        {
            int i = Random.Range(0, 2);
            if (i == 0)
            {
                GameObject newRhino = maleRhinoPrefab;
                rhinos.Add(newRhino);
                int p = Random.Range(3, 10);
                Instantiate(newRhino, _waypointManager.waypoints[p].transform.position, quaternion.identity);
            }
            else
            {
                GameObject newRhino = femaleRhinoPrefab;
                rhinos.Add(newRhino);
                int p = Random.Range(3, 10);
                Instantiate(newRhino, _waypointManager.waypoints[p].transform.position, quaternion.identity);
            }
        }

        for (int i = 3; i < 9; i++)
        {
            
                rhinos[i].gameObject.SetActive(false);
            
            
        }
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
