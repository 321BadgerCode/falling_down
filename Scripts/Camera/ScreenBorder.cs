using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBorder : MonoBehaviour
{
    private GameObject Target;
    private Transform target;
    private GameObject SceneManager;
    private Spawn spawn;


    void Start()
    {
        //SceneManager
        SceneManager = GameObject.FindGameObjectWithTag("SceneManager");

        //Target
        Target = GameObject.FindGameObjectWithTag("Player");
        target = Target.GetComponent<Transform>();
        spawn = SceneManager.GetComponent<Spawn>();
    }

    void Update()
    {
        if (Target.transform.position.y <= -4.5)
        {
            spawn.dead = true;
        }
    }

    void LateUpdate()
    {
        transform.position = new Vector3(
        Mathf.Clamp(target.position.x, -11.6f, 11.6f),
        Mathf.Clamp(target.position.y, -5f, 5f),
        transform.position.z);
    }
}
