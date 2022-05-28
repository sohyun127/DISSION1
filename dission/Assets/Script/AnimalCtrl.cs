using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalCtrl : MonoBehaviour
{
    private Transform randomT;

    public GameObject Item;
    public GameObject aniObj;

    private Rigidbody ani;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveObject());
    }
    IEnumerator MoveObject()
    {
        ani = GetComponent<Rigidbody>();

        while (true)
        {
            float dir1 = Random.Range(-1.5f, 1.5f);
            float dir2 = Random.Range(-1.5f, 1.5f);

            yield return new WaitForSeconds(2);
            ani.velocity = new Vector3(dir1, 3, dir2);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Weapon") // 무기와 충돌 시
        {
            // 제거
            Destroy(aniObj, 1);

            // 랜덤 위치에 생성
            StartCoroutine("addAnimal");

            // 아이템 드랍
            Vector3 v = new Vector3(0f, -1f, 1f);
            Item.transform.position = col.transform.position + v;
            StartCoroutine("dropItems");
        }
    }

    IEnumerator dropItems()
    {
        yield return new WaitForSeconds(0.5f); // 딜레이

        Instantiate(Item, aniObj.transform.position, Quaternion.identity);
    }

    IEnumerator addAnimal()
    {
        yield return new WaitForSeconds(0.9f); // 딜레이 : 1초 넘기면 코루틴 실행안되니까,,

        Vector3 spawnPos = GetRandomPosition();

        Instantiate(aniObj, spawnPos, Quaternion.identity);
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 basePosition = transform.position;

        float posX = basePosition.x + Random.Range(-25f, 25f);
        float posY = basePosition.y + Random.Range(0f, 2f);
        float posZ = basePosition.z + Random.Range(-25f, 25f);

        Vector3 spawnPos = new Vector3(posX, posY, posZ);

        // 이렇게하면 y축 계속 떨어짐... 왜...?
        //Vector3 spawnPos = new Vector3(Random.Range(-60f, -83f), Random.Range(0f, 2f), Random.Range(-90f, -120f)); 

        return spawnPos;
    }
}
