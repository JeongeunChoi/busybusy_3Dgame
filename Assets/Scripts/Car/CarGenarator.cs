using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarGenarator : MonoBehaviour
{
    public GameObject blueCarPrefab, greenCarPrefab, redCarPrefab;
    GameObject newCar, player;
    float delta = 0, pz=1.01f, px;
    int cnt = 0;

    // Start is called before the first frame update
    void Start()
    {
        if(GameVariable.character == 1)
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
        this.delta += Time.deltaTime;

        if (pz < player.transform.position.z +1.8 * 9)
        {
            this.delta = 0;

            int color = Random.Range(1, 4); // 1부터 3까지의 정수 중 하나 반환
            if(color == 1) // 1이면 파란색 자동차 생성
            {
                newCar = Instantiate(blueCarPrefab);
            } else if(color == 2) // 2이면 초록색 자동차 생성
            {
                newCar = Instantiate(greenCarPrefab);
            }
            else // 3이면 빨간색 자동차 생성
            {
                newCar = Instantiate(redCarPrefab);
            }

            if (cnt == 7) // 인도에는 자동차가 안다니도록
            {
                pz += 1.8f;
                cnt = 0;
            }
            pz += 1.8f;
            // 방향 서로 다르게
            if (cnt % 2 == 0)
            {
                px = Random.Range(11f, 17f);
                if(color == 2 || color == 3)
                {
                    pz += 0.6f;
                }
                newCar.transform.position = new Vector3(13f, 0.71f, pz);
                setNewCarDirection(color);
            }
            else
            {
                px = Random.Range(-17f, -11f);
                if (color == 2 || color == 3)
                {
                    pz += 0.6f;
                }
                newCar.transform.position = new Vector3(-13f, 0.4674134f, pz);
                setNewCarDirection(color);
            }
            cnt++;
            if (color == 2 || color == 3)
            {
                pz -= 0.6f;
            }
        }
    }

    private void setNewCarDirection(int color)
    {
        if (color == 1)
        {
            newCar.GetComponent<BlueCarController>().setDirection(-1);
        }
        else if (color == 2)
        {
            newCar.GetComponent<GreenCarController>().setDirection(-1);
        }
        else
        {
            newCar.GetComponent<RedCarController>().setDirection(-1);
        }
    }
}
