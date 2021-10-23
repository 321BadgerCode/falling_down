using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject PauseMenu;

    void Start()
    {
        PauseMenu.SetActive(false);
    }

    void Update()
    {
        
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        PauseMenu.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        PauseMenu.SetActive(false);
    }
}
