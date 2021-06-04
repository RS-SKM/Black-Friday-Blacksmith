using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mold : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Button down");
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Button up");
        }
    }
}
