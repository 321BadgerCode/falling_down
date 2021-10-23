using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
}
