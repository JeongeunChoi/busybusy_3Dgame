using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    public GameObject coinPrefab;
    GameObject coin, player;
    float delta = 0, pz = 1.01f;

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
        pz += 1.8f; // ���� ������ �����ϴ� ��ġ ���� ĭ ���� 
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if(pz < player.transform.position.z + 1.8 * 9)
        {
            float px = Random.Range(-9.0f, 9.0f);
            coin = Instantiate(coinPrefab);
            coin.transform.position = new Vector3(px, 0.3f, pz);
            int rule = Random.Range(1, 4);
            pz += 1.8f * rule;
        }
    }
}
