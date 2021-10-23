using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public int LevelNumber;
    public int NumForScene;
    public bool ui;
    public bool level;
    public bool add;

    void Start()
    {
        if (ui == false)
        {
            if (level == true)
            {
                if (add == true)
                {
                    SceneManager.LoadScene("Level_" + LevelNumber, LoadSceneMode.Additive);
                }
                else
                {
                    SceneManager.LoadScene("Level_" + LevelNumber, LoadSceneMode.Single);
                }
            }
            else
            {
                if (add == true)
                {
                    SceneManager.LoadScene(NumForScene, LoadSceneMode.Additive);
                }
                else
                {
                    SceneManager.LoadScene(NumForScene, LoadSceneMode.Single);
                }
            }
        }
    }

    public void LoadNewScene(int Num)
    {
        if (level == true)
        {
            if (add == true)
            {
                SceneManager.LoadScene("Level_" + Num, LoadSceneMode.Additive);
            }
            else
            {
                SceneManager.LoadScene("Level_" + Num, LoadSceneMode.Single);
            }
        }
        else
        {
            if (add == true)
            {
                SceneManager.LoadScene(Num, LoadSceneMode.Additive);
            }
            else
            {
                SceneManager.LoadScene(Num, LoadSceneMode.Single);
            }
        }
    }
}
