using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rhino : MonoBehaviour
{
    public float currentHappiness, currentCleanliness, currentHealth, currentSleep, currentHunger, currentActivity;

    public RhinoScriptable rhinoScript;
    // Start is called before the first frame update
    void Start()
    {
        rhinoScript = gameObject.GetComponent<RhinoScriptable>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
