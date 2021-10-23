using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    //Audio
    private AudioManager Audio;

    //Player
    private GameObject Player;
    private SpriteRenderer player;
    private GameObject Portal_red;
    private GameObject Portal_blue;
    private BoxCollider2D Portal_red_box;
    private BoxCollider2D Portal_blue_box;

    [HideInInspector] public bool red = false;
    [HideInInspector] public bool blue = false;
    [HideInInspector] public bool able = true;
    [HideInInspector] public float timer = 0f;

    void Start()
    {
        //Audio
        Audio = FindObjectOfType<AudioManager>();

        //Player
        Player = GameObject.FindGameObjectWithTag("Player");
        player = Player.GetComponent<SpriteRenderer>();
        Portal_red = GameObject.FindGameObjectWithTag("Portal_Red");
        Portal_blue = GameObject.FindGameObjectWithTag("Portal_Blue");
        Portal_red_box = Portal_red.GetComponent<BoxCollider2D>();
        Portal_blue_box = Portal_red.GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (able == true)
        {
            timer = 0f;
            if (red == true && blue == false)
            {
                Player.transform.position = (Portal_blue.transform.position);
                player.color = new Color(255, 0, 0);
                Audio.Play("PortalSound");
                red = false;
                able = false;
            }
            if (blue == true && red == false)
            {
                Player.transform.position = (Portal_red.transform.position);
                player.color = new Color(0, 255, 255);
                Audio.Play("PortalSound");
                blue = false;
                able = false;
            }
        }
        if (able == false)
        {
            timer += Time.deltaTime;
        }
        if (timer >= .5)
        {
            able = true;
            red = false;
            blue = false;
        }
    }
}
