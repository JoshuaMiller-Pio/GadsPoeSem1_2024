using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;


public class Rhino : MonoBehaviour
{
    public NavMeshAgent agent;
    public float currentHappiness, currentCleanliness, currentHealth, currentSleep, currentHunger, currentActivity;
    public Vector3[] waypoints = new Vector3[12];
    public Vector3 currentTarget;
    public RhinoScriptable rhinoScript;
    public RhinoAction currentAction, previousAction;
    public WaypointManager _WaypointManager;
    
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
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        agent.speed = 1;
        _WaypointManager = GameObject.FindGameObjectWithTag("WaypointManager").GetComponent<WaypointManager>();
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = _WaypointManager.waypoints[i].transform.position;
        }
        ChangeAction(RhinoAction.Idle);
        currentHappiness = rhinoScript.maxHappiness;
        currentCleanliness = rhinoScript.maxCleanliness;
        currentHealth = rhinoScript.maxHealth;
        currentHunger = rhinoScript.maxHunger;
        currentSleep = rhinoScript.maxSleep;
    }

    public void Idle()
    {
        int i = Random.Range(0, 12);
        currentTarget = waypoints[i];
        agent.destination = currentTarget;
    }

    public void Eat()
    {
        
    }

    public void Clean()
    {
        
    }

    public void Play()
    {
        
    }

    public void Sleep()
    {
        
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
    }
}
