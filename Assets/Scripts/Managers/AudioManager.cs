using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource Source;
    private AudioClip money, eat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void playMoney()
    {
        Source.clip = money;
        Source.Play();
    }
    void playEat()
    {
        Source.clip = eat;
        Source.Play();
    }
    
    
    
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
