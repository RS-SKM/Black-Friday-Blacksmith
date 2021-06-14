using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterMiniGame : MonoBehaviour
{
    static GameObject miniGameCounter;
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
