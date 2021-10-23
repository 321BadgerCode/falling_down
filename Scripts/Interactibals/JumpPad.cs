using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    private GameObject Player;
    private Rigidbody2D rb;

    public bool Collide;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        rb = Player.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Collide == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + 12f);
        }
    }
}
