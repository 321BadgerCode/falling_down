using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    private GameObject Player;
    private SpriteRenderer player;
    private MainCollide collide;
    private Movement move;
    private Rigidbody2D rb;
    private GameObject finish;
    private SpriteRenderer sr;
    private Color color;

    //Spawn
    private GameObject SceneManager;
    private Spawn spawn;

    //Particles
    public GameObject VictoryParticle1;
    public GameObject VictoryParticle2;
    public GameObject VictoryParticle3;

    [HideInInspector]public bool collided;
    public Text text;
    public Text Currency;
    public float currency;
    public bool currency2;
    public bool currency3;
    private bool Bool;
    private float timer;

    void Start()
    {
        //Player
        Player = GameObject.FindGameObjectWithTag("Player");
        player = Player.GetComponent<SpriteRenderer>();
        collide = Player.GetComponent<MainCollide>();
        move = Player.GetComponent<Movement>();
        rb = Player.GetComponent<Rigidbody2D>();

        //Spawn
        SceneManager = GameObject.FindGameObjectWithTag("SceneManager");
        spawn = SceneManager.GetComponent<Spawn>();

        //Finish
        finish = this.gameObject;
        sr = finish.GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        text.text = timer.ToString();

        if (collided == true)
        {
            move.enabled = false;
            sr.color = new Color(0, 255, 0);
            player.color = new Color(0, 255, 0);
            rb.constraints = RigidbodyConstraints2D.None;
            Bool = true;
        }
        if (Bool == true)
        {
            timer += Time.deltaTime;
        }
        if (timer >= 3)
        {
            timer = 0f;
            Player.transform.rotation = Quaternion.identity;
            spawn.dead = true;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            sr.color = new Color(255, 255, 0);
            player.color = new Color(255, 255, 255);
            Instantiate(VictoryParticle1, new Vector2(0, 5), Quaternion.identity);
            Instantiate(VictoryParticle2, new Vector2(0, 5), Quaternion.identity);
            Instantiate(VictoryParticle3, new Vector2(0, -5), Quaternion.identity);
            move.enabled = true;
            Bool = false;
            collided = false;
            currency3 = false;
        }
        if (collided == true && currency2 == true && currency3 == false)
        {
            currency += 50;
            Currency.text = ("currency", currency).ToString();
            currency2 = false;
            currency3 = true;
        }
    }
}
