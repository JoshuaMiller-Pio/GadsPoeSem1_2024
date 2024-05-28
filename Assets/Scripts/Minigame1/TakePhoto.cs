using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakePhoto : MonoBehaviour
{
    public static event Action snapwin;
    public static event Action snapNothing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

   

    // Update is called once per frame
    void Update()
    {
            Debug.DrawRay(gameObject.transform.position, gameObject.transform.forward);
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit[] hit = Physics.SphereCastAll(gameObject.transform.position, 4, gameObject.transform.forward,13);
            
            if (hit.Length != 0)
            {
                for (int i = 0; i < hit.Length; i++)
                {
                    if (hit[i].collider.gameObject.tag == "Rhino")
                    {
                        snapwin?.Invoke();

                    }
                    else
                    {
                        snapNothing?.Invoke();
                    }
                
                    
                    
                }
            }
        }
    }

 
}

