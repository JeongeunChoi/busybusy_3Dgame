using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCarController : MonoBehaviour
{
    float speed = 0.07f;
    float delta = 0f;
    int direction;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(0.03f, 0.1f);
        if (GameVariable.character == 1)
        {
            player = GameObject.Find("busyhuman");
        }
        else
        {
            player = GameObject.Find("ToonChicken");
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed, 0, 0);
        this.delta += Time.deltaTime;
        // ���ڸ��� ��� �ӹ��� 3�ʸ��� �ӵ� ����
        while (this.delta > 3)
        {
            this.speed *= 1.3f;
            this.delta = 0;
        }
        if (this.transform.position.y < 0)
        {
            Destroy(this);
        }
        // player���� �ڿ� ������ ���ӿ�����Ʈ ����
        if (this.transform.position.z < player.transform.position.z - 3)
        {
            Destroy(this.gameObject);
            // print("�ڵ��� ȭ�� ����");
        }
    }

    public void setDirection(int x)
    {
        direction = x;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Quad" || collision.gameObject.name == "Quad (1)")
        {
            // Debug.Log("�ڵ����� �� �浹");
            direction *= -1;
        }
    }
}
