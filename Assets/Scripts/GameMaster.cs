using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    int lives;
    static GameMaster masterInstance;
    int lastGame;
    int currentGame;

    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if( masterInstance == null ) {
            masterInstance = this;
        } else {
            Object.Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeGame() {
        currentGame = Random.Range(0, 2);
        if ( currentGame == lastGame ) {
            return;
        }
        Debug.Log("Game chosen is " + currentGame);
    }

    public void GameOutcome(bool success ) {
        if( !success ) {
            lives -= 1;
            if (lives <= 0) {

            }
        }
    }
}
