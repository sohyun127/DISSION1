using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcQuest : MonoBehaviour
{
   
    public GameObject Quest;

    public bool tab = false;

   void OnTriggerStay(Collider other)
    {
        

        if(other.tag =="NPC")
        {

            if (Input.GetKeyDown(KeyCode.Q))
            {
                if(tab)
                {
                    tab = false;
                }
                else if(!tab)
                {
                    tab = true;
                }

            }
        }

      
    }

    void Update()
    {
        if (tab == true)
        {
            Quest.SetActive(true);
        }
        else if (tab == false)
        {
            Quest.SetActive(false);
        }
    }

}

