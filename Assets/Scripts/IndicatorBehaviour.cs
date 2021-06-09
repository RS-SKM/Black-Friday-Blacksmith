using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorBehaviour : MonoBehaviour
{
    GameObject hammer;
    // Start is called before the first frame update
    void Start()
    {
        hammer = GameObject.Find("Hammer");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if( Input.GetKeyDown(KeyCode.Space) ) {

        }
    }
}
