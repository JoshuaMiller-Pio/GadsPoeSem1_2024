using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Minigame2Manager : MonoBehaviour
{
    public TextMeshProUGUI text;
    private int output;
    private float multiplier =0.01f;
    public static float speed =6;
    private float score =0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(scoreadd());

    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }

    IEnumerator scoreadd()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(0.1f);
            score += Time.deltaTime+(speed/3);
            output += 1 ;//(int)score;
            text.text = output.ToString();
            speed = Mathf.Clamp(speed + multiplier, 6, 20);
            Debug.Log(speed);
            
        }
        yield return null;

    }
}
