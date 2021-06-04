using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldButtonDown : MonoBehaviour
{
    [SerializeField] private Mold mold;
    bool buttonHeldDown;
    public float holdDownDuration;
    float gameSpeed = 1;

    public void ButtonHeldDown() { }
    public void ButtonRelease() { }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Button down");
            buttonHeldDown = true;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Button up");
            mold.GetComponent<Mold>().SetHoldDownDuration(holdDownDuration);
            buttonHeldDown = false;
        }

        if (buttonHeldDown)
        {
            holdDownDuration += Time.deltaTime * gameSpeed;
        }
    }
}