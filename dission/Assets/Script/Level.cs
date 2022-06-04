using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public TalkManager talkManager;
    private PlayerCtrl playerctrl;
    public GameObject levelBasicUi;
    public GameObject levelFullUi;
    public GameObject levelDataUi;
    public Text levelText;
    public int levelData = 0;
    public int a = 0;
    public bool leveling = false;

    private void Awake()
    {
        playerctrl = GameObject.Find("Player").GetComponent<PlayerCtrl>();
        levelFullUi.SetActive(false);
    }

    private void Update()
    {
        if (playerctrl.isAction)
        {
            levelBasicUi.SetActive(false);
            levelDataUi.SetActive(false);
        }
        else if(leveling)
        {
            levelBasicUi.SetActive(false);
        }
        else
        {
            levelDataUi.SetActive(true);
            levelBasicUi.SetActive(true);
        }
           


        if(levelData==(a+1))
        {
            leveling = true;
            a = 1;
            levelFullUi.SetActive(true);
             Invoke("endleveling", 0.2f);
        }

        levelText.text = "" + levelData;
    }


    void endleveling()
    {
        levelFullUi.SetActive(false);
        leveling = false;
        return;
    }
}
