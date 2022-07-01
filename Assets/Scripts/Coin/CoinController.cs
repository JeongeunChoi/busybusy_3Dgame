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
        // player���� �ڿ� ������ ���ӿ�����Ʈ ����
        if (this.transform.position.z < player.transform.position.z - 3)
        {
            Destroy(this.gameObject);
            // print("���� ȭ�� ����");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "busyhuman" || other.gameObject.name == "ToonChicken")
        {
            // Debug.Log("���ΰ� �÷��̾� �浹");
            audioSource.Play();
            Destroy(this.gameObject, 0.17f);
        }
    }
}
