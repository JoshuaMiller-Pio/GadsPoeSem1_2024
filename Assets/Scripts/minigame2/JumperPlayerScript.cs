using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperPlayerScript : MonoBehaviour
{
    public float Jumpforce;
    public bool isGrounded = false;
    private Rigidbody2D _rigcomp;
    public AudioSource jump;
    public static event Action dead;
    void Start()
    {
        _rigcomp = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Jump") && (isGrounded) )
        {
            _rigcomp.AddForce(Vector2.up*(Jumpforce*100));
            isGrounded = false;
            jump.Play();
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            if (!isGrounded)
            {
                isGrounded = true;
            }
        }
        if (other.gameObject.tag == "obstacle")
        {
            death();
        }
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
         
    }



    private void death()
    {
        dead?.Invoke();
    }


 
}
