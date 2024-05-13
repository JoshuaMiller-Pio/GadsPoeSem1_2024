using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperPlayerScript : MonoBehaviour
{
    private Rigidbody _rigcomp;
    public float dist = 1, jumppwer = 13;
    private RaycastHit info;
    public LayerMask layer;
    private bool isGrounded,canDoubleJump;
    private Vector3 gravity = new Vector3(0, -20, 0);
    
    void Start()
    {
        _rigcomp = GetComponent<Rigidbody>();
        Physics.gravity = gravity;
    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.Raycast(gameObject.transform.position, Vector3.down, dist, layerMask: layer);

        if (Input.GetButtonDown("Jump")  && (isGrounded || canDoubleJump))
         {
             _rigcomp.AddForce(Vector3.up*jumppwer,ForceMode.Impulse );
             if (!isGrounded && canDoubleJump)
             {
                 _rigcomp.AddForce(Vector3.up*jumppwer/6,ForceMode.Impulse );
                 canDoubleJump = false;
             }
         }
        else if(isGrounded && !canDoubleJump)
        {
            canDoubleJump = true;
        }
                
         
    
        if (Input.GetKeyDown(KeyCode.S) && !isGrounded )
        {
            _rigcomp.AddForce(Vector2.down*20,ForceMode.Impulse );
        }
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "obstacle2d")
        {
            death();
        }    
    }



    private void death()
    {
        
    }
}
