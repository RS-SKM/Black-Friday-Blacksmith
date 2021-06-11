using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapingGame : MonoBehaviour
{
    public float gameSpeed;
    bool animating;
    Animator anim;
    public GameObject[] indicators;
    float indicator0X;
    float indicator1X;
    public float margin;
    bool fail = false;
    TimerMiniGame timer;
    GameMaster gM;
    SpriteRenderer shieldSprite;
    public Sprite[] shieldStates;
    int shieldStateInt=0;

    // Start is called before the first frame update
    void Awake()
    {
        anim = this.GetComponent<Animator>();
        timer = GameObject.Find("Timer").GetComponent<TimerMiniGame>();
        gM = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        gameSpeed = gM.GetGameSpeed();
        shieldSprite= GameObject.Find("Shield").GetComponent<SpriteRenderer>();
        indicator0X = indicators[0].transform.position.x;
        indicator1X = indicators[1].transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if( !animating ) {
            transform.position = new Vector3(-0.001499992f + Mathf.Sin(Time.time * 2 * gameSpeed) * 0.7f, -0.02349999f, 0);
        }

        if( Input.GetKeyDown(KeyCode.Space) ) {
            StartCoroutine(HammerDown());
            IndicatorCheck();
            VictoryCheck();
        }
    }

    IEnumerator HammerDown() {
        animating = true;
        anim.SetBool("IsAnimating", true);
        anim.speed = gameSpeed;
        yield return new WaitForSeconds(0.8f/gameSpeed);
        anim.SetBool("IsAnimating", false);
        animating = false;
    }

    void IndicatorCheck() {
        if( indicators[0] || indicators[1] ) {
            if(transform.position.x <= indicator0X+margin && transform.position.x >= indicator0X-margin && indicators[0]) {
                if( !fail ) {
                    Destroy(indicators[0]);
                    shieldSprite.sprite = shieldStates[shieldStateInt];
                    shieldStateInt++;
                }
            } else if( transform.position.x <= indicator1X + margin && transform.position.x >= indicator1X - margin && indicators[1]) {
                if( !fail ) {
                    Destroy(indicators[1]);
                    shieldSprite.sprite = shieldStates[shieldStateInt];
                    shieldStateInt++;
                }
            } else {
                fail = true;
                shieldSprite.sprite = shieldStates[3];
            }
        } else {
            fail = true;
            shieldSprite.sprite = shieldStates[4];
        }
    }

    void VictoryCheck() {
        if( !indicators[0] && !indicators[1] && !fail) {
            timer.VictoryCheck(true);
        }
    }
}
