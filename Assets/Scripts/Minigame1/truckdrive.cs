using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class truckdrive : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rigComp; 
    public float speed = 0.5f;
    public Transform begining, end;
    void Start()
    {
        rigComp = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rigComp.velocity.magnitude > 7)
        {
            rigComp.velocity = Vector3.ClampMagnitude(rigComp.velocity, 7);
        }
        if (Input.GetAxis("Vertical") != 0)
        {
            rigComp.AddForce(rigComp.velocity.x, 0, -Input.GetAxis("Vertical")/3, ForceMode.Impulse);
        }

        

    }
}
