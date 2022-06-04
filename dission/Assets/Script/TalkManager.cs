using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{

    Dictionary<int, string[]> talkData;
   Dictionary<int, string[]> nameData;

    private Level level;
    int count = 0;

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
       nameData = new Dictionary<int, string[]>();
        GenerateData();

        level = GameObject.Find("Player").GetComponent<Level>();
    }

    void GenerateData()
    {
        talkData.Add(1, new string[] { "안녕 나는 우뚝선 독수리라고 해.", "이 곳에 처음 왔구나?","그럼 지금부터 내가 조작법을 알려줄게.","W A S D 키를 누르면 앞 뒤 좌 우로 이동이 가능하고"+" 또한 스페이스바를 누르면 점프가 가능해.","NPC 가까이 가서 Q키를 누르면 NPC와 대화를 할 수 있어." ,
                                        "이제 돼지와 함께 춤을이라는 NPC를 찾아서 말을 걸어봐."});
        talkData.Add(2, new string[] { "안녕 나는 돼지와 함께 춤을이라고 해" });

        nameData.Add(1, new string[] { "우뚝선 독수리" });
       nameData.Add(2, new string[] {"돼지와 함께 춤을"});
    }


    void Update()
    {
        if(level.levelData==0 && count>0)
        {
            level.levelData = 1;
        }



    }
    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
        {
            talkData.Remove(id);
            if(id==1)
            {
                talkData.Add(1, new string[] { "안녕 나는 우뚝선 독수리라고 해." });
            }
            else if(id==2)
            {
                talkData.Add(2, new string[] { "안녕 나는 돼지와 함께 춤을이라고 해" });
                count++;
            }
            return null;
        }
        else
        return talkData[id][talkIndex];
    }

   public string GetName(int id,int nameIndex)
    {
       return nameData[id][nameIndex];
    }
}
