using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicineCtrl : MonoBehaviour
{
    public GameObject Item;
    public GameObject mediObj;

    // Start is called before the first frame update
    void Start()
    {
        
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
            Destroy(mediObj, 1);

            // 랜덤 위치에 생성
            StartCoroutine("addMedicine");

            // 아이템 드랍
            Vector3 v = new Vector3(0f, -1f, 1f);
            Item.transform.position = col.transform.position + v;
            StartCoroutine("dropItems");
        }
    }

    IEnumerator dropItems()
    {
        Vector3 basePosition = transform.position;

        float posX = basePosition.x ;
        float posY = basePosition.y + 0.7f;
        float posZ = basePosition.z ;

        Vector3 spawnPos = new Vector3(posX, posY, posZ);


        yield return new WaitForSeconds(0.5f); // 딜레이

        Instantiate(Item, spawnPos, Quaternion.identity);
    }

    IEnumerator addMedicine()
    {
        yield return new WaitForSeconds(0.9f); // 딜레이 

        Vector3 spawnPos = GetRandomPosition();

        Instantiate(mediObj, spawnPos, Quaternion.identity);
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 basePosition = transform.position;

        float posX = basePosition.x + Random.Range(-1f, 1f);
        float posY = basePosition.y ;
        float posZ = basePosition.z + Random.Range(-1f, 1f);

        Vector3 spawnPos = new Vector3(posX, posY, posZ);

        return spawnPos;
    }
}
