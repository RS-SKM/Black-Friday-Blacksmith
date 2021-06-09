using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    void ChangeGame() {
        currentGame = Random.Range(1, 3);
        while( currentGame == lastGame ) {
            currentGame = Random.Range(0, 3);
        }
        Debug.Log("Game chosen is " + currentGame);
        SceneManager.LoadScene(currentGame);
    }

    public void GameOutcome(bool success ) {
        if( !success ) {
            lives -= 1;
            if (lives <= 0) {
                
            }
        }
    }
}
