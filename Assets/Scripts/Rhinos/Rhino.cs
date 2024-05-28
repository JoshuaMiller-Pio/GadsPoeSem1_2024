using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;


public class Rhino : MonoBehaviour
{
    public GameManager _GameManager;
    public UIManager _UIManager;
    public NavMeshAgent agent;
    public float currentHappiness, currentCleanliness, currentHealth, currentSleep, currentHunger, currentActivity;
    public GameObject[] waypoints = new GameObject[12];
    public GameObject currentTarget;
    public Vector3 currentTargetLocation;
    public RhinoScriptable rhinoScript;
    public RhinoAction currentAction, previousAction;
    public WaypointManager _WaypointManager;
    public static event Action<Rhino> UpdateRhinoInfoUI;
    public static event Action<Rhino> DisplayRhinoOptions;
    public enum RhinoAction
    {
        Idle,
        Eat,
        Clean,
        Play,
        Sleep
    }

 
    public void ChangeAction(RhinoAction desiredAction)
    {
        if (currentAction == desiredAction)
        {
            return; 
        }

        if (currentAction != desiredAction)
        {
            previousAction = currentAction;
            currentAction = desiredAction;
        }
    }
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this);

        _GameManager = GameManager.Instance;
        _UIManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        agent = gameObject.GetComponent<NavMeshAgent>();
        agent.speed = 1f;
        _WaypointManager = GameObject.FindGameObjectWithTag("WaypointManager").GetComponent<WaypointManager>();
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = _WaypointManager.waypoints[i];
        }
        ChangeAction(RhinoAction.Idle);
        currentHappiness = rhinoScript.maxHappiness;
        currentCleanliness = Random.Range(35, 95);
        currentHealth = Random.Range(35, 95);
        currentHunger = Random.Range(35, 95);
        currentSleep = Random.Range(35, 95);
        currentActivity = Random.Range(35, 95);
        int j = Random.Range(0, 12);
        currentTarget = waypoints[j];
        StartCoroutine("StatDegrade");
    }

    /*
    private void OnMouseOver()
    {
        Debug.Log(this.gameObject.name);
        
        
    }

    
    private void OnMouseDown()
    {
        _GameManager.chosenRhino = this; 
         
    }
*/
    public void SelectedRhino()
    {
        //_GameManager.chosenRhino = this;
        UpdateRhinoInfoUI?.Invoke(this);
        DisplayRhinoOptions?.Invoke(this);
    }
    private void OnTriggerEnter(Collider other)
    {           
        

        
        if (other.gameObject == currentTarget && currentAction == RhinoAction.Idle)
        {
            Debug.Log("should work");

            int i = Random.Range(0, waypoints.Length);
            GameObject newTarget = waypoints[i];
            while (newTarget == currentTarget)
            {
                i = Random.Range(0, waypoints.Length);
                newTarget = waypoints[i];
            }
            currentTarget = newTarget;
            agent.destination = currentTarget.transform.position;
        }
        
        if (other.gameObject == currentTarget && currentAction == RhinoAction.Eat)
        {
            StartCoroutine(waitAtLocation(10));
            //currentHunger = currentHunger + 10;
        }
        
        if (other.gameObject == currentTarget && currentAction == RhinoAction.Clean)
        {
            StartCoroutine(waitAtLocation(20));
            //currentCleanliness = currentCleanliness + 30;
        }
        
        if (other.gameObject == currentTarget && currentAction == RhinoAction.Sleep)
        {
            StartCoroutine(waitAtLocation(60));
            //currentSleep= currentSleep + 50;
        }
    }

    IEnumerator StatDegrade()
    {
        while (true)
        {
            int i = Random.Range(0, 10);
            int p = Random.Range(0, 10);
            int o = Random.Range(0, 10);
            int l = Random.Range(0, 10);
            int m = Random.Range(0, 10);
            int t = Random.Range(45, 120);
            currentHealth -= i;
            currentCleanliness -= p;
            currentActivity -= o;
            currentSleep -= l;
            currentHunger -= m;
            yield return new WaitForSeconds(t);
        }
        
    }
    public void Idle()
    {
      
        try
        {
            agent.destination = currentTarget.transform.position;
        }
        catch
        { 
            int j = Random.Range(0, 12);
            currentTarget = waypoints[j];
            agent.destination = currentTarget.transform.position;

        }
        
    }

    public void Eat()
    {
        agent.destination = waypoints[2].transform.position;
        
        if (currentHunger > rhinoScript.maxHunger)
        {
            currentHunger = rhinoScript.maxHunger;
        }
    }

    public void Clean()
    {
        agent.destination = waypoints[3].transform.position;
        
        if (currentCleanliness > rhinoScript.maxHunger)
        {
            currentCleanliness = rhinoScript.maxHunger;
        }
    }

    public void Play()
    {
        
    }

    public void Sleep()
    {
        agent.destination = waypoints[0].transform.position;
        
        if (currentSleep > rhinoScript.maxHunger)
        {
            currentSleep = rhinoScript.maxHunger;
        }
    }

    
    IEnumerator waitAtLocation(int waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        ChangeAction(RhinoAction.Idle);
        StopCoroutine("waitAtLocation");
    }
    // Update is called once per frame
    void Update()
    {
        switch (currentAction)
        {
            case RhinoAction.Idle:
                Idle();
                break;
            case RhinoAction.Eat:
                Eat();
                break;
            case RhinoAction.Clean:
                Clean();
                break;
            case RhinoAction.Play:
                Play();
                break;
            case RhinoAction.Sleep:
                Sleep();
                break;
            default:
                break;
        }

        currentHappiness = (currentCleanliness + currentHappiness + currentHealth + currentActivity + currentSleep +
                            currentHunger) / 6;
    }
}
