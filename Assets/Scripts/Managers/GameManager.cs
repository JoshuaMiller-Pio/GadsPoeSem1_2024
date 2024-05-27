using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameObject chosenRhino;

    public int currentGold, foodCost = 10, medsCost = 20, cleanCost = 20;
    // Start is called before the first frame update
    void Start()
    {
        currentGold = 30;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
