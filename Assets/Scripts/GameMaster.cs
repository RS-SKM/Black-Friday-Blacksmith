using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameMaster : MonoBehaviour
{
    int lives = 3;
    static GameMaster masterInstance;
    int lastGame = 10;
    int currentGame = 10;
    float gameSpeed = 1;
    int rounds = 0;
    SpriteRenderer hearts;
    public Sprite[] heartsCounter;
    CounterMiniGame counterMiniGame;
    bool oneTime = false;

    public float GetGameSpeed() {
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
        hearts = GameObject.Find("Hearts").GetComponent<SpriteRenderer>();
        counterMiniGame = GameObject.Find("Mini Game Counter").GetComponent<CounterMiniGame>();
    }

    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Background Music");
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
        currentGame = Random.Range(2, 5);
        while( currentGame == lastGame ) {
            currentGame = Random.Range(2, 5);
        }
        Debug.Log("Game chosen is " + currentGame);
        SceneManager.LoadScene(currentGame);
        oneTime = true;
        if(oneTime)
        {
            counterMiniGame.AddScore();
        }

    }

    public void GameOutcome(bool success ) {
        Debug.Log(success);
        if ( !success ) {
            lives--;
            Debug.Log(lives);
            hearts.sprite = heartsCounter[lives];
            if (lives <= 0) {
                SceneManager.LoadScene(5);
            }
        }
        rounds = +1;
        if( rounds > 4 ) {
            rounds = 0;
            gameSpeed += 0.5f;
            FindObjectOfType<AudioManager>().SpeedUp(gameSpeed);
        }
    }
}
