using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonDown()
    {
        SceneManager.LoadScene("rpgpp_lt_scene_1.0");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]

    static void FirstLoad()
    {
        if (SceneManager.GetActiveScene().name.CompareTo("GameStart") != 0)
        {
            SceneManager.LoadScene("GameStart");
        }
    }
}
