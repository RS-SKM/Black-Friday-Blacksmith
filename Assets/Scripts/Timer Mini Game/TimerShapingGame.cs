using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerShapingGame : MonoBehaviour
{
    float timeLimit = 20;
    float gameSpeed;
    float timeBar;
    GameMaster gM;
    ShapingGame sG;
    // Start is called before the first frame update
    void Start()
    {
        gM = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        sG = GameObject.Find("Hammer").GetComponent<ShapingGame>();
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
        if (timeBar >= timeLimit)
        {
            gM.GameOutcome(false);
            SceneManager.LoadScene(1);
        }
    }
}
