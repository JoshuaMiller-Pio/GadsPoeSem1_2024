using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public Rhino chosenRhino { get; set; }
   
    public int currentGold, foodCost = 10, medsCost = 20, cleanCost = 20;
    // Start is called before the first frame update
    void Start()
    {
        currentGold = 30;
      
    }

    public void PlayRhinoRun()
    {
        chosenRhino.currentActivity += 30;
        chosenRhino.currentHealth -= 10;
        chosenRhino.currentHunger -= 10;
        SceneManager.LoadScene(3);
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
