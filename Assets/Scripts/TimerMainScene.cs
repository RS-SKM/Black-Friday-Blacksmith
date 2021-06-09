using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerMainScene : MonoBehaviour
{
    float timeLimit = 8;
    [SerializeField] float timeBar = 0;
    int gameSpeed;
    GameMaster gM;

    // Start is called before the first frame update
    void Start()
    {
        gM = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        gameSpeed = gM.GetGameSpeed();
        timeLimit = timeLimit / gameSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        timeBar += Time.deltaTime;
        if( timeBar >= timeLimit ) {
            gM.ChangeGame();
        }
    }
}
