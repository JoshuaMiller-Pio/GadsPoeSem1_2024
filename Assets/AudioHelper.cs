using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHelper : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

  public  void playMoney()
    {
        AudioManager.Instance.playMoney();
        
    }

  public void playButton()
    {
        AudioManager.Instance.playbutton();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
