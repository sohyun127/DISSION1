using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcQuest : MonoBehaviour
{

    public GameObject Panel;
    public GameObject[] Quest;
    public int count = 0;
    public bool tab = false;
 
 


    void OnTriggerStay(Collider other)
    {
        if (other.tag == "NPC")
        {
            StartCoroutine("quest");
        }
    }

    void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < Quest.Length; i++)
        {

            Quest[i].SetActive(false);

        }
        StopCoroutine("quest");
        Panel.SetActive(false);
        count = 0;
        tab = false;
    }
  

    IEnumerator quest()
    {
        if (Input.GetKeyDown(KeyCode.Q)&&!tab)
        {
            tab = true;
        }
        else if(Input.GetKeyDown(KeyCode.Q) && tab)
        {
            tab = false;
        }

        if(tab)
        {
           
            if (Input.GetMouseButtonDown(0))
            {
              
                if (count < Quest.Length)
                    count++;
            }

            Panel.SetActive(true);
            for (int i = 0; i< Quest.Length; i++)
            {
                if (i == count)
                {
                    Quest[i].SetActive(true);
                }
                else
                {
                    Quest[i].SetActive(false);
                }
            }
        }
        else if(!tab)
        {

            for (int i = 0; i < Quest.Length; i++)
            {

                Quest[i].SetActive(false);

            }

            Panel.SetActive(false);
        }

        yield return null;
    }
}

