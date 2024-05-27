using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.TextCore.Text;

public class UIManager : MonoBehaviour
{
    
    public TMP_Text rhinoName, currentGold, currentHealth, currentHappiness, currentSleep, currentCleanliness, currentExecercise, currentHunger;

    public Image rhinoPhoto;
    public Canvas rhnoActions;
    public GameManager _GameManager;
   
    // Start is called before the first frame update
    void Start()
    {
        _GameManager = GameManager.Instance;
    }

    private void OnEnable()
    {
        Rhino.UpdateRhinoInfoUI += UpdateRhinoInfo;
        Rhino.DisplayRhinoOptions += ShowRhinoOptions;
    }

    private void OnDisable()
    {
        Rhino.UpdateRhinoInfoUI -= UpdateRhinoInfo; 
        Rhino.DisplayRhinoOptions -= ShowRhinoOptions;
    }

    public void UpdateRhinoInfo(Rhino chosenRhino)
    {
        currentHealth.text = chosenRhino.currentHealth.ToString() + "/100";
        currentHappiness.text = chosenRhino.currentHappiness.ToString() + "/100";
        currentHunger.text = chosenRhino.currentHunger.ToString() + "/100";
        currentCleanliness.text = chosenRhino.currentCleanliness.ToString() + "/100";
        currentSleep.text = chosenRhino.currentSleep.ToString() + "/100";
        currentExecercise.text = chosenRhino.currentActivity.ToString() + "/100";
    }

    public void ShowRhinoOptions(Rhino chosenRhino)
    {
        rhnoActions.gameObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        currentGold.text = "= " + _GameManager.currentGold.ToString();
    }
}
