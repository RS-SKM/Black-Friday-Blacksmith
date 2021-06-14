using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterMiniGame : MonoBehaviour
{
    int addScore = 0;
    static GameObject miniGameCounter;
    Text myText;
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (miniGameCounter == null)
        {
            miniGameCounter = this.gameObject;
        }
        else
        {
            Object.Destroy(this.gameObject);
        }
        myText = this.GetComponentInChildren<Text>();
    }

    public void AddScore()
    {
        addScore++;
        myText.text = addScore.ToString();
    }
}
