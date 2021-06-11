using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastingGame : MonoBehaviour
{
    bool buttonHeldDown;
    public float holdDownDuration;
    float gameSpeed = 1;
    float maxHoldDownDuration = 3.5f;
    TimerMiniGame timerCG;

    public Sprite[] spriteArray;
    SpriteRenderer myRenderer;
    Animator anim;

    private void Awake()
    {
        anim = GameObject.Find("Crucible").GetComponent<Animator>();
        timerCG = GameObject.Find("Timer").GetComponent<TimerMiniGame>();
    }

    void Start()
    {
        myRenderer = GameObject.Find("Sword Mold").GetComponent<SpriteRenderer>();
        myRenderer.sprite = spriteArray[0];
    }

    void Update()
    {
        SetHoldDownDuration();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Button down");
            anim.SetBool("PlayerInput", true);
            buttonHeldDown = true;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Button up");
            anim.SetBool("PlayerInput", false);
            buttonHeldDown = false;
        }

        if (buttonHeldDown)
        {
            holdDownDuration += Time.deltaTime * gameSpeed;
        }
    }

    //save processing power by only checking once
    bool oneTime1 = false;
    bool oneTime2 = false;
    bool oneTime3 = false;
    bool oneTime4 = false;
    public void SetHoldDownDuration()
    {
        if (!oneTime1)
        {
            if (holdDownDuration >= 1f)
            {
                Debug.Log("1/3 filled");
                myRenderer.sprite = spriteArray[1];
                oneTime1 = true;
            }
        }
        if (!oneTime2)
        {
            if (holdDownDuration >= 2f)
            {
                Debug.Log("2/3 filled");
                myRenderer.sprite = spriteArray[2];
                oneTime2 = true;
            }
        }
        if (!oneTime3)
        {
            if (holdDownDuration >= 3f)
            {
                Debug.Log("Filled");
                myRenderer.sprite = spriteArray[3];
                FindObjectOfType<AudioManager>().Play("Win");
                oneTime3 = true;
                timerCG.VictoryCheck(true);
            }
        }
        if (!oneTime4)
        {
            if (holdDownDuration > maxHoldDownDuration)
            {
                Debug.Log("Overfilled");
                myRenderer.sprite = spriteArray[4];
                FindObjectOfType<AudioManager>().Play("Lose");
                oneTime4 = true;
                timerCG.VictoryCheck(false);
            }
        }
    }
}