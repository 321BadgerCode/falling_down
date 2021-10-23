using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    //SpawnPoint
    private GameObject SpawnPoint;

    //Player
    private GameObject Player;
    private BoxCollider2D Box;
    private Rigidbody2D rb;

    //Particles
    public GameObject DeathParticle;
    public GameObject SpawnParticle;

    //Detects when player dies(boolean)
    [HideInInspector] public bool dead;

    //Camera
    public bool isPerspective;
    private GameObject MainCamera;
    private Camera camera_main;

    void Start()
    {
        //SpawnPos
        SpawnPoint = GameObject.FindGameObjectWithTag("Respawn");

        //Player
        Player = GameObject.FindGameObjectWithTag("Player");
        Box = Player.GetComponent<BoxCollider2D>();
        rb = Player.GetComponent<Rigidbody2D>();

        //Camera
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        camera_main = MainCamera.GetComponent<Camera>();
    }

    
    void Update()
    {
        //Player Death
        if (dead == true)
        {
            //Player and particle stuff
            rb.velocity = new Vector2(0, 0);
            Instantiate(DeathParticle, Player.transform.position, Quaternion.identity);
            Player.transform.position = (SpawnPoint.transform.position);
            Instantiate(SpawnParticle, Player.transform.position, Quaternion.identity);

            //Camera
            MainCamera.transform.position = new Vector3(0, 0, -10);

            if (isPerspective == false)
            {
                camera_main.orthographicSize = 5f;
            }
            else
            {
                camera_main.fieldOfView = 50f;
            }

            //Sets dead back to deafault 
            dead = false;
        }
    }
}
