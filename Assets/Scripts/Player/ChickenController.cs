using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenController : MonoBehaviour
{
    Vector3 directionZ, directionXL, directionXR;
    int distance, coin;
    GameObject gameDirector;
    AudioSource audioSource;
    public AudioClip car;

    // Start is called before the first frame update
    void Start()
    {
        directionZ = new Vector3(0, 0, 1);
        directionXL = new Vector3(-1, 0, 0);
        directionXR = new Vector3(1, 0, 0);
        distance = 0;
        coin = 0;
        if(GameVariable.character == 1)
        {
            gameObject.SetActive(false);
        }
        gameDirector = GameObject.Find("GameDirector");
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = car;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameVariable.gameOver)
        {
            if (Input.GetKey(KeyCode.LeftArrow) && this.transform.position.x > -13)
            {
                transform.position += directionXL * 0.1f;
            }
            if (Input.GetKey(KeyCode.RightArrow) && this.transform.position.x < 13)
            {
                transform.position += directionXR * 0.1f;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                transform.position += directionZ * 1.8f;
                distance++;
            }
        }
        if (distance == 239)
        {
            gameDirector.GetComponent<GameDirector>().ShowGameComplete();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "greenCarPrefab(Clone)")
        {
            // Debug.Log("面倒");
            this.audioSource.Play();
            gameDirector.GetComponent<GameDirector>().ShowGameOver();
        }
        else if (collision.gameObject.name == "blueCarPrefab(Clone)")
        {
            // Debug.Log("面倒");
            this.audioSource.Play();
            gameDirector.GetComponent<GameDirector>().ShowGameOver();
        }
        else if (collision.gameObject.name == "redCarPrefab(Clone)")
        {
            // Debug.Log("面倒");
            this.audioSource.Play();
            gameDirector.GetComponent<GameDirector>().ShowGameOver();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "coinPrefab(Clone)")
        {
            // Debug.Log("内牢面倒");
            coin++;
        }
    }

    public int getDistance()
    {
        return distance;
    }

    public int getCoin()
    {
        return coin;
    }
}
