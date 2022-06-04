using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NewScenePlayer : MonoBehaviour 
{
    // [ 플레이어 hp ]
    protected static int hp = 100;
    // 약초 얻었을 때 => hp 100으로 

    // [ 허기 게이지 ]
    protected static int hungry = 100;
    float hungryTime = 10; // 10초 마다 허기게이지 1씩 감소 => 약 15분 후 허기0
    
    public GameObject hpGauge;
    public GameObject hungryGauge;

    //------------- 임시로 캐릭터 움직임 구현 (추후 삭제) -------------
    public float speed = 5f;
   

    void Update()
    {
        hungryTime -= Time.deltaTime;

        if (hungryTime < 0)
        {
            hungry -= 1;
            print("허기게이지 1 감소  hungry=" + hungry);
            this.hungryGauge.GetComponent<Image>().fillAmount -= 0.01f;
            hungryTime = 10; // 다시 시작
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, 0, -speed * Time.deltaTime);
        }


    }
    //------------- ------------------------------ -------------

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Animals") // 동물과 충돌
        {
            hp -= 5;  // 플레이어의 hp감소 
            this.hpGauge.GetComponent<Image>().fillAmount -= 0.05f;

            print("동물에게 데미지를 얻었습니다." + hp);
        }
    }

}
