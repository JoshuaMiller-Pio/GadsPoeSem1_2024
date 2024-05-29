using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonManager : MonoBehaviour
{
    private GameManager _gameManager;

    public UIManager _UIManager;
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameManager.Instance;
        _UIManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
    }

    public void PlayRhinoRun()
    {
        _gameManager.PlayRhinoRun();
    }

    public void SelectRhino0()
    {
       _gameManager.chosenRhino = _gameManager.rhinos[0].GetComponent<Rhino>();
       _gameManager.chosenRhino.SelectedRhino();
    }
    
    public void SelectRhino1()
    {
        _gameManager.chosenRhino = _gameManager.rhinos[1].GetComponent<Rhino>();
        _gameManager.chosenRhino.SelectedRhino();
    }

    public void DestroyRhino()
    {
        if (_gameManager.chosenRhino.currentHappiness >= 90)
        {
            _UIManager.CloseRhinoActions();
            _gameManager.DestroyRhino();
            
        }
        else
        {
            _UIManager.ActivateNotRecoveredPanel();
        }
    }
    public void PlayRhinoSafari()
    {
       _gameManager.PlayRhinoSafari();
    }

    public void PlayGame()
    {
        _gameManager.PlayGame();
    }

    public void Quit()
    {
        _gameManager.Quit();
    }
    public void Eat()
    {
        _gameManager.Eat();
    }

    public void Clean()
    {
        _gameManager.Clean();
    }

    public void Sleep()
    {
       _gameManager.Sleep();
    }

    public void TakeMeds()
    {
       _gameManager.TakeMeds();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
