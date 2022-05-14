using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl: MonoBehaviour
{
    // [ 플레이어 hp ]
    int hp = 100; 
    // 약초 얻었을 때 => hp 100으로 

    // [ 허기 게이지 ]
    int hungry = 100; 
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
    }

    //------------- ------------------------------ -------------
    
    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Animals") // 동물과 충돌
        {
            print("동물에게 데미지를 얻었습니다.");

            hp -= 5;  // 플레이어의 hp감소 
            print(hp);
        }
    }
    
    private void OnTriggerEnter(Collider col)
    {
        // 인벤토리 구현 후 다시 수정!!!!!!!!!!
        if (col.tag == "Item") //아이템 습득
        {
            print("음식 획득");
            Destroy(col.gameObject);
            // hp = 100;  // 플레이어의 hp충전
        }
    }
    
}
