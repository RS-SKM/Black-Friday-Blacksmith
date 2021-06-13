using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartsController : MonoBehaviour
{
    static GameObject heartsInstance;
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if( heartsInstance == null ) {
            heartsInstance = this.gameObject;
        } else {
            Object.Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
