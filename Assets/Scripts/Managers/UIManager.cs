using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TMP_Text rhinoName, currentHealth, currentHappiness, currentSleep, currentCleanliness, currentExecercise;

    public Image rhinoPhoto;
    public Canvas rhnoActions;

    public void UpdateRhinoInfo(Rhino selectedRhino)
    {
        rhnoActions.gameObject.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
