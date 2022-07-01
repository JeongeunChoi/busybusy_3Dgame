using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    public Text distance, coin, timer, gameOver, restart;
    GameObject player;
    float time;

    // Start is called before the first frame update
    void Start()
    {
        if (GameVariable.character == 1)
        {
            player = GameObject.Find("busyhuman");
        }
        else if(GameVariable.character == 2)
        {
            player = GameObject.Find("ToonChicken");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameVariable.character == 1)
        {
            distance.text = "Distance: " + player.GetComponent<BusyhumanController>().getDistance();
            coin.text = "Coin: " + player.GetComponent<BusyhumanController>().getCoin();
        }
        else 
        {
            distance.text = "Distance: " + player.GetComponent<ChickenController>().getDistance();
            coin.text = "Coin: " + player.GetComponent<ChickenController>().getCoin();
        }
        if (GameVariable.gameOver)
        {
            if (Input.GetKey(KeyCode.Return))
            {
                GameVariable.character = 0;
                SceneManager.LoadScene("GameStartScene");
            }
        }
        else
        {
            ShowTime();
        }
    }

    void ShowTime()
    {
        // 타이머 기능 구현
        time += Time.deltaTime;
        timer.text = "Timer: " + time.ToString("F1"); // 소수점 첫째자리 표시
    }

    public void ShowGameOver()
    {
        GameVariable.gameOver = true;
        gameOver.text = "Game Over";
        gameOver.color = Color.red;
        restart.text = "Press Enter to Restart";
    }

    public void ShowGameComplete()
    {
        GameVariable.gameOver = true;
        gameOver.text = "Game Complete";
        gameOver.color = Color.green;
        restart.text = "Press Enter to Restart";
    }
}
