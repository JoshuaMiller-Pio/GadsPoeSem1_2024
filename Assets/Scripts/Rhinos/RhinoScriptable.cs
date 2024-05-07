using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Rhino", menuName = "CreateRhino")]
public class RhinoScriptable : ScriptableObject
{
    public enum Personality
    {
        Enthusiastic,
        Aggressive,
        Dower
    }

    public string name;

    public Personality _personality;

    public float maxHappiness, maxHunger, maxCleanliness, maxSleep, maxActivity, maxHealth;
}
