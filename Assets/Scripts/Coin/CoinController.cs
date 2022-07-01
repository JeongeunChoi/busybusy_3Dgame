using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    GameObject player;
    AudioSource audioSource;
    public AudioClip coinSelect;

    // Start is called before the first frame update
    void Start()
    {
        if (GameVariable.character == 1)
        {
            player = GameObject.Find("busyhuman");
        }
        else
        {
            player = GameObject.Find("ToonChicken");
        }
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = coinSelect;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(-0.9f, 0, 0));
        if (this.transform.position.y < 0)
        {
            Destroy(this);
        }
        // player보다 뒤에 있으면 게임오브젝트 삭제
        if (this.transform.position.z < player.transform.position.z - 3)
        {
            Destroy(this.gameObject);
            // print("코인 화면 삭제");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "busyhuman" || other.gameObject.name == "ToonChicken")
        {
            // Debug.Log("코인과 플레이어 충돌");
            audioSource.Play();
            Destroy(this.gameObject, 0.17f);
        }
    }
}
