using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerMiniGame : MonoBehaviour
{
    float timeLimit = 6;
    float gameSpeed;
    float timeBar;
    GameMaster gM;
    // Start is called before the first frame update
    void Start()
    {
        gM = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        gameSpeed = gM.GetGameSpeed();
        timeLimit = timeLimit / gameSpeed;
    }

    public void VictoryCheck(bool success = false)
    {
        if (success == true)
        {
            gM.GameOutcome(success);
        }
        if (!success)
        {
            gM.GameOutcome(success);
        }

    }
    // Update is called once per frameS
    void Update()
    {
        timeBar += Time.deltaTime;
        if(timeBar >= timeLimit)
        {
            gM.GameOutcome(false);
            SceneManager.LoadScene(1);
        }
    }
}
