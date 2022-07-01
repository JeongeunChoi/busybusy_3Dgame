using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartDirector : MonoBehaviour
{
    bool select = false;
    public Text choose, busyhuman, chicken;

    // Start is called before the first frame update
    void Start()
    {
        GameVariable.gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Keypad1) || Input.GetKey(KeyCode.Alpha1))
        {
            GameVariable.character = 1;
            select = true;
            // print("1");
            choose.text = "Press Enter\nto Start!";
            busyhuman.text = "<color=red>Busyhuman\nSelected</color>";
            chicken.text = "Chicken\n(select with 2)";
        }
        if (Input.GetKey(KeyCode.Keypad2) || Input.GetKey(KeyCode.Alpha2))
        {
            GameVariable.character = 2;
            select = true;
            // print("2");
            choose.text = "Press Enter\nto Start!";
            busyhuman.text = "Busyhuman\n(select with 1)";
            chicken.text = "<color=red>Chicken\nSelected</color>";
        }
        if (Input.GetKey(KeyCode.Return) && select)
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
