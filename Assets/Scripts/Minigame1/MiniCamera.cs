using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniCamera : MonoBehaviour
{
     Camera _camera;
    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.mouseScrollDelta.y != 0)
        {
            float newFieldOfView = _camera.fieldOfView + -Input.mouseScrollDelta.y ;
            _camera.fieldOfView = Mathf.Clamp(newFieldOfView, 4, 16);
           
        }
    }
}
