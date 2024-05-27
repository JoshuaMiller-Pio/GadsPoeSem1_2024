using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class GroundMovement : MonoBehaviour
{
    private bool move = true;
    private void Update()
    {
        if (move)
        {
            transform.position -= new Vector3(Minigame2Manager.speed * Time.deltaTime , 0, 0);
            if (transform.localPosition.x <= -45.43)
            {
                transform.localPosition = new Vector3(-5.55f, transform.position.y, 0);;
            }
        }
        
       
    }
    private void Start()
    {
        JumperPlayerScript.dead += setfalse;
    }

    void setfalse()
    {
        move = false;
    }

    /*
     public float deltaSpeed;
    private Rigidbody2D _rigcomp;

    // Start is called before the first frame update
    void Start()
    {
        _rigcomp = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        StartCoroutine(movement());
    }

    IEnumerator movement()
    {       
        _rigcomp.velocity = new Vector2(-deltaSpeed, 0);

        yield return new WaitForSeconds(0.1f);
        yield return null;
    }
   */
}
