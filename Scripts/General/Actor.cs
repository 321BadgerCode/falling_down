using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    //Player
    private GameObject Player;
    private SpriteRenderer player;
    private Movement move;
    private Spawn spawn;

    //Camera
    public bool isPerspective;
    private GameObject MainCamera;
    private Camera camera_main;

    void Start()
    {
        //Set Time
        Time.timeScale = 1f;

        //Player
        Player = GameObject.FindGameObjectWithTag("Player");
        player = Player.GetComponent<SpriteRenderer>();
        player.enabled = true;
        player.color = new Color(255, 255, 255);
        move = Player.GetComponent<Movement>();
        move.enabled = true;

        //Camera
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        camera_main = MainCamera.GetComponent<Camera>();

        //Camera Setup
        MainCamera.transform.position = new Vector3(0, 0, -10);

        if (isPerspective == false)
        {
            camera_main.orthographic = true;
            camera_main.orthographicSize = 5f;
        }
        else
        {
            camera_main.orthographic = false;
            camera_main.fieldOfView = 50f;
        }
    }

    void Update()
    {

    }
}
