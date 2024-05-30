using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    
    public  AudioSource Source;
    public  AudioClip money, eat, button;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public  void playMoney()
    {
        Source.clip = money;
        Source.Play();
    }
    public  void playEat()
    {
        Source.clip = eat;
        Source.Play();
    }
    public  void playButton()
       {
           Source.clip = eat;
           Source.Play();
       }
    
    
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
