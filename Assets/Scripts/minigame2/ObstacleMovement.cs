using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
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
        _rigcomp.velocity = new Vector3(-deltaSpeed, 0);

        yield return new WaitForSeconds(0.1f);
        yield return null;
    }

}
