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

            if (gameObject.tag == "Food")
            {
                hungry = 100; 
             
            }
            else if (gameObject.tag == "Medicine")
            {
                hp = 100; 
            }

            // 제거
            Destroy(gameObject);

        }

        
    }
}
