using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerGame : MonoBehaviour
{
    public float gameSpeed;
    bool animating;
    Animator anim;
    public GameObject[] indicators;
    public float margin;
    public bool victory = false;

    // Start is called before the first frame update
    void Awake()
    {
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if( !animating ) {
            transform.position = new Vector3(0.6f + Mathf.Sin(Time.time * 2 * gameSpeed) * 5, 1.44f, 0);
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
            }
        }
        if( indicators[1] ) {
            if( transform.position.x <= indicators[1].transform.position.x + margin && transform.position.x >= indicators[1].transform.position.x - margin ) {
                Destroy(indicators[1]);
            }
        }
    }

    void VictoryCheck() {
        if( !indicators[0] && !indicators[1] ) {
            victory = true;
        }
    }
}
