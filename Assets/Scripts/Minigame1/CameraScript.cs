using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Vector2 _rotation;
    [SerializeField] private float lookSpeed;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
       Cursor.visible = false;
    }

    private void Update()
    {
        StartCoroutine("MouseY");
        StartCoroutine("Mousex");
    }

    IEnumerator MouseY()
    {
        _rotation.y += Input.GetAxis("Mouse X");


        //look sides
        transform.eulerAngles = new Vector2(0, _rotation.y) * lookSpeed;

        //look up

        yield return null;
    }  
    IEnumerator Mousex()
    {
        _rotation.x += -Input.GetAxis("Mouse Y");

        _rotation.x = Mathf.Clamp(_rotation.x, -30f, 30f);

        //look sides
        Camera.main.transform.localRotation = Quaternion.Euler(_rotation.x * lookSpeed, _rotation.y, 0);
        //look up

        yield return null;
    }

}