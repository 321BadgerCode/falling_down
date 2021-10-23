using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private GameObject Player;
    private Rigidbody2D rb;

    private float X;
    public float dampX;
    public float speed;

    public bool jump;


    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        rb = Player.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        X = rb.velocity.x;
        X += Input.GetAxisRaw("Horizontal");
        X *= Mathf.Pow(1f - dampX, Time.deltaTime * 10f);
        rb.velocity = new Vector2(X, rb.velocity.y);
        if (jump == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + 12f);
                rb.gravityScale = 2f;
                jump = true;
            }
        }
    }
}
