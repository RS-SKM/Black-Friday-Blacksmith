using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastingGame : MonoBehaviour
{
    [SerializeField] private Mold mold;
    bool buttonHeldDown;
    public float holdDownDuration;
    float gameSpeed = 1;
    float maxHoldDownDuration = 3.5f;

    public Sprite[] spriteArray;
    SpriteRenderer myRenderer;

    public void ButtonHeldDown() {}
    public void ButtonRelease() {}

    void Start()
    {
        myRenderer = GameObject.Find("Sword Mold").GetComponent<SpriteRenderer>();
        myRenderer.sprite = spriteArray[0];
    }
 


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
            buttonHeldDown = false;
            SetHoldDownDuration(); 
        }

        if (buttonHeldDown)
        {
            holdDownDuration += Time.deltaTime * gameSpeed;
        }
    }  
    public void SetHoldDownDuration()
    {
        if (holdDownDuration >= 1f)
        {
            Debug.Log("1/3 filled");
            myRenderer.sprite = spriteArray[1];
        }
        if (holdDownDuration >= 2f)
        {
            Debug.Log("2/3 filled");
            myRenderer.sprite = spriteArray[2];
        }
        if (holdDownDuration >= 3f)
        {
            Debug.Log("Filled");
            myRenderer.sprite = spriteArray[3];
        }
        if (holdDownDuration > maxHoldDownDuration)
        {
            Debug.Log("Overfilled");
            myRenderer.sprite = spriteArray[4];
        }
    }
}