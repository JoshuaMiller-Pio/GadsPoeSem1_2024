using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniCamera : MonoBehaviour
{
     Camera _camera;
     public GameObject canvasWin;
     public AudioSource sauce;

    // Start is called before the first frame update
    void Start()
    {
        TakePhoto.snapwin += takePictue;
        TakePhoto.snapNothing += takePictuenothing;
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

    void takePictue()
    {
        StartCoroutine(takePicture());
        sauce.Play();

    }
    void takePictuenothing()
    {
        StartCoroutine(takePicturenothing());
        sauce.Play();
    }

    IEnumerator takePicture()
    {
        _camera.enabled = false;
        yield return new WaitForSecondsRealtime(1);
        _camera.enabled = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        canvasWin.SetActive(true);
        yield return null;
        TakePhoto.snapwin -= takePictue;
        TakePhoto.snapNothing -= takePictuenothing;
    }
    IEnumerator takePicturenothing()
    {
        _camera.enabled = false;
        yield return new WaitForSecondsRealtime(1);
        _camera.enabled = true;
        yield return null;
    }
}
