using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{

    Dictionary<int, string[]> talkData;
   Dictionary<int, string[]> nameData;

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
       nameData = new Dictionary<int, string[]>();
        GenerateData();
    }

    void GenerateData()
    {
        talkData.Add(1, new string[] { "안녕 나는 우뚝선 독수리라고 해", "이 곳에 처음 왔구나?" });
        talkData.Add(2, new string[] { "안녕 나는 돼지와 함께 춤을이라고 해" });
        nameData.Add(1, new string[] { "우뚝선 독수리" });
       nameData.Add(2, new string[] {"돼지와 함께 춤을"});
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
            return null;
        else
        return talkData[id][talkIndex];
    }

   public string GetName(int id,int nameIndex)
    {
       return nameData[id][nameIndex];
    }
}
