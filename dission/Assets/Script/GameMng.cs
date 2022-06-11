using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMng : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]

    static void FirstLoad()
    {

        if (SceneManager.GetActiveScene().name.CompareTo("GameStart") != 0)

        {

            SceneManager.LoadScene("GameStart");

        }

    }
    
}
