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
        if (col.gameObject.tag == "Weapon") // ����� �浹 ��
        {
            // ����
            Destroy(aniObj, 1);

            // ���� ��ġ�� ����
            StartCoroutine("addAnimal");

            // ������ ���
            Vector3 v = new Vector3(0f, -1f, 1f);
            Item.transform.position = col.transform.position + v;
            StartCoroutine("dropItems");
        }
    }

    IEnumerator dropItems()
    {
        yield return new WaitForSeconds(0.5f); // ������

        Instantiate(Item, aniObj.transform.position, Quaternion.identity);
    }

    IEnumerator addAnimal()
    {
        yield return new WaitForSeconds(0.9f); // ������ : 1�� �ѱ�� �ڷ�ƾ ����ȵǴϱ�,,

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

        // �̷����ϸ� y�� ��� ������... ��...?
        //Vector3 spawnPos = new Vector3(Random.Range(-60f, -83f), Random.Range(0f, 2f), Random.Range(-90f, -120f)); 

        return spawnPos;
    }
}
