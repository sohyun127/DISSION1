using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl: MonoBehaviour
{
    // 플레이어 구동과 합치면서 중력 체크 해야함

    int hp = 100; // 플레이어의 hp 게이지

    // 약초 얻었을 때 => hp 100으로 


    int hungry = 100; // 허기 게이지

    float hungryTime = 10; // 10초 마다 허기게이지 1씩 감소 => 약 15분 후 허기0

    //------------- 임시로 캐릭터 움직임 구현 (추후 삭제) -------------
    //public float speed = 5f;

    void Update()
    {
        hungryTime -= Time.deltaTime;

        if (hungryTime < 0 )
        {
            hungry -= 1;
            print("허기게이지 1 감소");
            hungryTime = 10; // 다시 시작
        }
        /*
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
        }*/
    }
    //------------- ------------------------------ -------------
   
    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Monster1") //몬스터1과 충돌 시
        {
            print("몬스터1과 충돌");

            hp -= 2;  // 플레이어의 hp감소 : -2 정도

        }
        else if (col.gameObject.tag == "Monster2") //몬스터2
        {
            print("몬스터2와 충돌");

            hp -= 5; // 플레이어의 hp감소 : -5 정도

        }
        else if (col.gameObject.tag == "Monster3") //몬스터3
        {
            //print("몬스터와 충돌");

            hp -= 8;  // 플레이어의 hp감소 : -8 정도

        }
    }
    
}
