using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    int lives;
    static GameMaster masterInstance;
    int lastGame = 10;
    int currentGame = 10;
    int gameSpeed = 1;
    int rounds = 0;

    public int GetGameSpeed() {
        return gameSpeed;
    }
    
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

    private void Update() {
        if( Input.GetKeyDown("1") ) {
            SceneManager.LoadScene(2);
        }
        if( Input.GetKeyDown("2") ) {
            SceneManager.LoadScene(3);
        }
        if( Input.GetKeyDown("3") ) {
            SceneManager.LoadScene(4);
        }
    }

    public void ChangeGame() {
        currentGame = Random.Range(2, 4);
        while( currentGame == lastGame ) {
            currentGame = Random.Range(2, 4);
        }
        Debug.Log("Game chosen is " + currentGame);
        SceneManager.LoadScene(currentGame);
    }

    public void GameOutcome(bool success ) {
        if( !success ) {
            lives -= 1;
            if (lives <= 0) {
                SceneManager.LoadScene(5);
            }
        }
        rounds = +1;
        if( rounds > 4 ) {
            rounds = 0;
            gameSpeed += 1;
        }
    }
}
