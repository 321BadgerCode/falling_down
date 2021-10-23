using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCollide : MonoBehaviour
{
    private GameObject Player;
    private BoxCollider2D Box;
    private GameObject SceneManager;
    private PlayerMovement move;
    private Portal portal;
    private Spawn spawn;
    private GameObject Finishz;
    private Finish finishz;
    private GameObject JumpPad;
    private JumpPad jumpPad;
    private GameObject Bubble;
    private Bubble bubble;

    [HideInInspector] public bool Collided;

    void Start()
    {
        //Player Setup
        Player = this.gameObject;
        Box = Player.GetComponent<BoxCollider2D>();
        move = Player.GetComponent<PlayerMovement>();

        //SceneManager
        SceneManager = GameObject.FindGameObjectWithTag("SceneManager");

        //Finish
        Finishz = GameObject.FindGameObjectWithTag("Finish");
        finishz = Finishz.GetComponent<Finish>();

        //Bubble
        Bubble = GameObject.FindGameObjectWithTag("Bubble");
        bubble = Bubble.GetComponent<Bubble>();

        //Jump_Pad
        JumpPad = GameObject.FindGameObjectWithTag("Jump_Pad");
        jumpPad = JumpPad.GetComponent<JumpPad>();

        //Portal Script
        portal = SceneManager.GetComponent<Portal>();

        //Spawn Script
        spawn = SceneManager.GetComponent<Spawn>();
    }

    //Collide
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Collided = true;
        //Move
        if (collision.CompareTag("Platform"))
        {
            move.jump = false;
        }
        //Spawn
        if (collision.CompareTag("Enemy"))
        {
            spawn.dead = true;
        }
        //Finish
        if (collision.CompareTag("Finish"))
        {
            finishz.collided = true;
            finishz.currency2 = true;
        }
        //Jump_Pad
        if (collision.CompareTag("Jump_Pad"))
        {
            jumpPad.Collide = true;
        }
        //Bubble
        if (collision.CompareTag("Bubble"))
        {
            bubble.Collide = true;
        }
        //Portals
        if (collision.CompareTag("Portal_Red"))
        {
            portal.red = true;
        }
        if (collision.CompareTag("Portal_Blue"))
        {
            portal.blue = true;
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        Collided = false;
        bubble.Collide = false;
        jumpPad.Collide = false;
    }
}
