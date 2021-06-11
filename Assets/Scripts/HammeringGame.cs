using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammeringGame : MonoBehaviour
{
    public Sprite[] swordSpriteArray;
    public Sprite[] hammerSpriteArray;
    SpriteRenderer swordSpriteRenderer;
    SpriteRenderer hammerSpriteRenderer;
    int swordSpriteOrder = 0;
    TimerMiniGame timerMG;

    void Start()
    {
        timerMG = GameObject.Find("Timer").GetComponent<TimerMiniGame>();
        swordSpriteRenderer = GameObject.Find("Sword").GetComponent<SpriteRenderer>();
        swordSpriteRenderer.sprite = swordSpriteArray[0];
        hammerSpriteRenderer = GameObject.Find("Hammer").GetComponent<SpriteRenderer>();
        hammerSpriteRenderer.sprite = hammerSpriteArray[0];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Button down");
            swordSpriteOrder++;
            hammerSpriteRenderer.sprite = hammerSpriteArray[1];
            StartCoroutine(hammerSpriteWait());
            swordSpriteRenderer.sprite = swordSpriteArray[swordSpriteOrder];
            VictoryCheck();
            
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Button up");
            hammerSpriteRenderer.sprite = hammerSpriteArray[0];
        }
    }

    void VictoryCheck()
    {
        if(swordSpriteOrder == 3)
        {
            timerHG.VictoryCheck(true);
        }

        if(swordSpriteOrder == 4)
        {
            timerHG.VictoryCheck(false);
        }
    }
    //really janky substitute for an animator
    IEnumerator hammerSpriteWait()
    {
        yield return new WaitForSeconds(0.01f);
        hammerSpriteRenderer.sprite = hammerSpriteArray[2];
    }
}