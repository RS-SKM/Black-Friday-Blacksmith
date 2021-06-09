using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerGauge : MonoBehaviour
{
    Image myImage;
    Color32 red;
    float fraction;

    // Start is called before the first frame update
    void Start()
    {
        myImage = this.GetComponent<Image>();
        red = new Color32(255, 0, 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        myImage.fillAmount = 1-fraction;
        myImage.color = Color.Lerp(myImage.color, red, fraction);
    }

}
