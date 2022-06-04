using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : PlayerCtrl // 인벤토리 하면 상속 해제하기
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 360f, 0), Time.deltaTime * 45, Space.World);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player") // 플레이어와 충돌 시
        {

            // (인벤토리 증가)  인벤토리 구현 시 수정

            if (gameObject.tag == "Food")
            {                
                hungry = 100; // 허기 게이지 만땅으로 채우기
                print("음식 획득 hungry=" + hungry);
            }
            else if (gameObject.tag == "Medicine")
            {
                hp = 100; // hp 게이지 만땅으로 채우기
                print("약초 획득 hp="+hp);
            }

            // 제거
            Destroy(gameObject);

        }

        
    }
}
