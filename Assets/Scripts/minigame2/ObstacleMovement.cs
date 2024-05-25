using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public static event Action onSpawnDist;
    private void Update()
    {
        transform.position -= new Vector3(Minigame2Manager.speed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("2dSpawn"))
        {
            Debug.Log("ah");
            onSpawnDist?.Invoke();
        }

        if (other.CompareTag("2dDelete"))
        {
            Destroy(this.gameObject);
        }

      
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
          _rigcomp.velocity = new Vector3(-deltaSpeed, 0);

          yield return new WaitForSeconds(0.1f);
          yield return null;
      }


      */
}