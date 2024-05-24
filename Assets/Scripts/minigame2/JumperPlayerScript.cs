using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperPlayerScript : MonoBehaviour
{
    private Rigidbody2D _rigcomp;
    public float dist = 1, jumppwer = 13;
    private int count = 0;
    private RaycastHit info;
    public LayerMask layer;
    public bool isGrounded;
    private Vector2 gravity = new Vector3(0, -20);
    
    void Start()
    {
        _rigcomp = GetComponent<Rigidbody2D>();
        Physics.gravity = gravity;
    }
    void FixedUpdate(){
        Vector2 pos = _rigcomp.position;
        _rigcomp.position = pos;
    }
    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.Raycast(gameObject.transform.position, Vector2.down, dist, layerMask: layer);

       


            if (Input.GetButtonDown("Jump") && (isGrounded))
            {
                Debug.Log("ah");
                _rigcomp.velocity += Vector2.up * Physics2D.gravity.y  *jumppwer ;
              
               
                
            }
          
      
        
                
            
    
        if (Input.GetKeyDown(KeyCode.S) && !isGrounded )
        {
            _rigcomp.velocity -= Vector2.up * -Physics2D.gravity.y *(2.5f -1) * 5;
        }
       
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "obstacle")
        {
            Debug.Log(other.name);
            death();
        }  
    }

    private void death()
    {
        Debug.Log("you DEAD");
    }


 
}
