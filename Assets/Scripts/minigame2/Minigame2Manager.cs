using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;
using UnityEngine.SceneManagement;

public class Minigame2Manager : MonoBehaviour
{
    public TextMeshProUGUI text,endtext;
    public GameObject canvasDead;
    private  int output;
    private float multiplier =0.05f;
    public static float speed =6;
    private float score =0;
    // Start is called before the first frame update
    private void OnEnable()
    {
        JumperPlayerScript.dead += DEAD;
    }

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
            
        }
        yield return null;

    }

    void DEAD()
    {
        canvasDead.SetActive(true);
        StopCoroutine(scoreadd());
        endtext.text = text.text;
        
    }

    public void returnTOPen()
    {
       
        GameManager.Instance.currentGold += (int)Math.Floor((double)output/75);
        GameManager.Instance.returnToPen();

    }
}
