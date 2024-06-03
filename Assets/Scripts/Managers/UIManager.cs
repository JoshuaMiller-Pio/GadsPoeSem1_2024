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
    
    public TMP_Text rhinoName, rhinoCurrentAction, rhinosSaved, currentGold, currentHealth, currentHappiness, currentSleep, currentCleanliness, currentExecercise, currentHunger;
    public GameObject noGoldPanel, notRecoveredEnoughPanel;
    public Image rhinoPhoto;
    public Canvas rhnoActions, pauseMenu;
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

    public void ActivateNoGoldPanel()
    {
        noGoldPanel.SetActive(true);
    }

    public void ActivatePauseMenu()
    {
        pauseMenu.gameObject.SetActive(true);
    }
    public void ActivateNotRecoveredPanel()
    {
        notRecoveredEnoughPanel.SetActive(true);
    }
    
    public void CloseeNotRecoveredPanel()
    {
        notRecoveredEnoughPanel.SetActive(false);
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

    public void CloseRhinoActions()
    {
        rhnoActions.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        rhinosSaved.text = "Rhinos Saved: " + _GameManager.rhinosSaved;
        currentGold.text = "= " + _GameManager.currentGold.ToString();
        switch (_GameManager.chosenRhino.currentAction)
        {
            case Rhino.RhinoAction.Idle:
                rhinoCurrentAction.text = "Rhino is currently: walking around enjoying it's enclosure";
                break;
            case Rhino.RhinoAction.Clean:
                rhinoCurrentAction.text = "Rhino is currently enjoying a relaxing wash";
                break;
            case Rhino.RhinoAction.Eat:
                rhinoCurrentAction.text = "Rhino is enjoying a delicious meal";
                break;
            case Rhino.RhinoAction.Sleep:
                rhinoCurrentAction.text = "Rhino is sleeping";
                break;
            default:
                break;
        }
        
    }
}
