using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonManager : MonoBehaviour
{
    private GameManager _gameManager;
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameManager.Instance;
    }

    public void PlayRhinoRun()
    {
        _gameManager.PlayRhinoRun();
    }
    
    public void PlayRhinoSafari()
    {
       _gameManager.PlayRhinoSafari();
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
