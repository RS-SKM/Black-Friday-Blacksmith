using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapingGame : MonoBehaviour
{
    public float gameSpeed;
    bool animating;
    Animator anim;
    public GameObject[] indicators;
    public float margin;
    bool fail = false;
    TimerShapingGame timerSG;
    GameMaster gM;
    SpriteRenderer shieldSprite;
    public Sprite[] shieldStates;
    int shieldStateInt=0;

    // Start is called before the first frame update
    void Awake()
    {
        anim = this.GetComponent<Animator>();
        timerSG = GameObject.Find("Timer").GetComponent<TimerShapingGame>();
        gM = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        gameSpeed = gM.GetGameSpeed();
        shieldSprite= GameObject.Find("Shield").GetComponent<SpriteRenderer>();
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
        if( indicators[0] ) {
            if(transform.position.x <= indicators[0].transform.position.x+margin && transform.position.x >= indicators[0].transform.position.x - margin ) {
                Destroy(indicators[0]);
                if( !fail ) {
                    shieldSprite.sprite = shieldStates[shieldStateInt];
                    shieldStateInt++;
                }
            } else {
                fail = true;
            }
        } else if( indicators[1] ) {
            if( transform.position.x <= indicators[1].transform.position.x + margin && transform.position.x >= indicators[1].transform.position.x - margin ) {
                Destroy(indicators[1]);
                if( !fail ) {
                    shieldSprite.sprite = shieldStates[shieldStateInt];
                    shieldStateInt++;
                }
            } else {
                fail = true;
                if( !fail ) {
                    shieldSprite.sprite = shieldStates[4];
                }
            }
        } else {
            fail = true;
            if( !fail ) {
                shieldSprite.sprite = shieldStates[5];
                shieldStateInt++;
            }
        }
    }

    void VictoryCheck() {
        if( !indicators[0] && !indicators[1] && !fail) {
            timerSG.VictoryCheck(true);
        }
    }
}
