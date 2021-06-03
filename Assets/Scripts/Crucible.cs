using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crucible : MonoBehaviour
{
    Animator anim;

    private void Awake() {
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKey("a") ) {
            anim.SetBool("PlayerInput", true);
        } else {
            anim.SetBool("PlayerInput", false);
        }
    }
}
