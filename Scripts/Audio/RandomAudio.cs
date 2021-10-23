using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAudio : MonoBehaviour
{
    //SceneManager
    private GameObject SceneManager;

    //Spawn
    private Spawn spawn;

    //Audio
    private AudioSource audioSource;
    public AudioClip[] audioClips;
    [Tooltip("Check to play audio when game starts")]public bool start;
    [Tooltip("0: Plays audio when player dies, 1: Plays audio when player touches object, 2: Plays audio when player stops touching object")]public int type;

    private bool Continue;

    void Awake()
    {
        audioSource = this.gameObject.AddComponent<AudioSource>();
    }

    private void Start()
    {
        //SceneManager
        SceneManager = GameObject.FindGameObjectWithTag("SceneManager");

        //Spawn
        spawn = SceneManager.GetComponent<Spawn>();

        //Setup
        if (start == true)
        {
            Continue = true;
        }
    }

    void Update()
    {
        //Dead
        if (type == 0 && spawn.dead == true)
        {
            Continue = true;
        }

        //Types
        if (Continue == true)
        {
            audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
            audioSource.PlayOneShot(audioSource.clip);
            Continue = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && type == 1)
        {
            Continue = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && type == 2)
        {
            Continue = true;
        }
    }
}
