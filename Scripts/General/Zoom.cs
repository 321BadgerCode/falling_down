using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    //Outside Scripts
    private GameObject SceneManager;
    private Spawn spawn;

    //Zoom Stuff
    private GameObject MainCamera;
    private Camera camera_main;
    private float Zoomz;
    [Header("Camera Type")]
    [Tooltip("0: Orthographic camera, 1: Perspective Camera")]public int Camera_Type;
    private float Original_Zoom;

    [Space(10)]

    [Header("Zoom Values")]
    [Tooltip("Specifies what the zoom for the camera will be by the end of the zooming process")]public float zoom;
    [Tooltip("Specifies what the speed for the zooming process will be")]public float speed;
    [Tooltip("0: Default, 1: Zooms camera when object has been interacted with by player, 2: Zooms camera when player has stopped interacted with object")]public int type;
    [Tooltip("Check if you want to set the camera back to its default zoom value when player stops touching object")]public bool stop;

    [Space(10)]

    //Collision Detection
    private int collide;

    //Booleans
    [Header("Booleans")]
    [Tooltip("Check boolean if you want to have the camera smoothly transition into the specified zoom amount")]public bool smooth;
    private bool zoom_a;

    void Start()
    {
        //Outside Scripts
        SceneManager = GameObject.FindGameObjectWithTag("SceneManager");
        spawn = SceneManager.GetComponent<Spawn>();

        //Camera Stuff
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        camera_main = MainCamera.GetComponent<Camera>();

        //Default Zoom
        //Orthographic Camera
        if (Camera_Type == 0) {
            Original_Zoom = camera_main.orthographicSize;
        }
        //Perspective Camera
        if (Camera_Type == 1)
        {
            Original_Zoom = camera_main.fieldOfView;
        }
    }

    void Update()
    {
        //Dead
        if (spawn.dead == true)
        {
            zoom_a = false;
        }

        //Types
        if (spawn.dead == false && zoom_a == false)
        {
            //Default
            if (type == 0)
            {
                zoom_a = true;
                collide = 5;
            }
            //When interacted with
            else if (type == 1 && collide == 1)
            {
                zoom_a = true;
            }
            //When stopped being interacted with
            else if (type == 2 && collide == 2)
            {
                zoom_a = true;
                collide = 5;
            }
        }

        //When stopped being interacted with
        if (stop == true && collide == 2)
        {
            zoom_a = false;
            //Orthographic Camera
            if (Camera_Type == 0)
            {
                camera_main.orthographicSize = Original_Zoom;
            }
            //Perspective Camera
            if (Camera_Type == 1)
            {
                camera_main.fieldOfView = Original_Zoom;
            }
            collide = 5;
        }

        //Camera zoom for orthographic cameras
        if (Camera_Type == 0)
        {
            //Checks if zoom_a is true and then zooms camera accordingly
            if (zoom_a == true && smooth == true)
            {
                if (camera_main.orthographicSize <= zoom)
                {
                    Zoomz = (-speed * Time.deltaTime);
                    camera_main.orthographicSize -= Zoomz;
                }
                if (camera_main.orthographicSize >= zoom)
                {
                    Zoomz = (-speed * Time.deltaTime);
                    camera_main.orthographicSize += Zoomz;
                }
            }

            //Checks if zoom_a is true and then zooms camera accordingly
            else if (zoom_a == true && smooth == false)
            {
                camera_main.orthographicSize = zoom;
            }
        }

        //Camera zoom for perspective cameras
        if (Camera_Type == 1)
        {
            //Checks if zoom_a is true and then zooms camera accordingly
            if (zoom_a == true && smooth == true)
            {
                if (camera_main.fieldOfView <= zoom)
                {
                    Zoomz = (-speed * Time.deltaTime);
                    camera_main.fieldOfView -= Zoomz;
                }
                if (camera_main.fieldOfView >= zoom)
                {
                    Zoomz = (-speed * Time.deltaTime);
                    camera_main.fieldOfView += Zoomz;
                }
            }

            //Checks if zoom_a is true and then zooms camera accordingly
            else if (zoom_a == true && smooth == false)
            {
                camera_main.fieldOfView = zoom;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Checks for collision with player
        if (collision.CompareTag("Player"))
        {
            collide = 1;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Checks for collision ending with player
        if (collision.CompareTag("Player"))
        {
            collide = 2;
        }
    }
}
