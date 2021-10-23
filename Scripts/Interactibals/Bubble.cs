using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    //Player
    private GameObject Player;
    private SpriteRenderer player;
    private MainCollide collide;
    private Rigidbody2D rb;
    private Movement move;

    //Bubble
    private GameObject bubble;
    private Vector3 bubbleP;
    private Rigidbody2D rbB;
    private CircleCollider2D cC;

    public bool Collide;

    public bool time;
    public float timer;

    void Start()
    {
        //Setting Up The Player
        Player = GameObject.FindGameObjectWithTag("Player");
        player = Player.GetComponent<SpriteRenderer>();
        collide = Player.GetComponent<MainCollide>();
        rb = Player.GetComponent<Rigidbody2D>();
        move = Player.GetComponent<Movement>();

        //Bubble
        bubble = this.gameObject;
        bubbleP = bubble.transform.position;
        cC = bubble.AddComponent<CircleCollider2D>();
        cC.isTrigger = true;
        rbB = bubble.AddComponent<Rigidbody2D>();
        rbB.isKinematic = false;
        rbB.gravityScale = 0f;
    }

    void Update()
    {
        if (Collide == true)
        {
            bubble.transform.position = (Player.transform.position);
            rbB.gravityScale = -.5f;
            rb.gravityScale = -.5f;
            time = true;
        }
        if (time == true)
        {
            timer += Time.deltaTime;
        }
        if (timer >= 2)
        {
            rbB.gravityScale = 0f;
            rbB.velocity = new Vector2(0, 0);
            rb.gravityScale = 1f;
            bubble.transform.position = bubbleP;
            time = false;
            timer = 0f;
        }
    }
}
