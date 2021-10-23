using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Diolog : MonoBehaviour
{
    private AudioManager Audio;
    public string[] reply;
    public int index;
    public float TypeSpeed;
    public Text text;
    private int letters;

    public GameObject Button;
    public GameObject PlayButton;

    void Start()
    {
        Audio = GameObject.FindObjectOfType<AudioManager>();
        StartCoroutine(Type());
    }

    private void Update()
    {
        if (text.text == reply[index])
        {
            Button.SetActive(true);
        }
        if (index >= reply.Length - 1)
        {
            PlayButton.SetActive(true);
        }
    }

    IEnumerator Type()
    {
        foreach (char letter in reply[index].ToCharArray())
        {
            text.text += letter;
            yield return new WaitForSeconds(TypeSpeed);
        }
    }

    public void Click()
    {
        Button.SetActive(false);
        if (index < reply.Length)
        {
            index++;
            text.text = "";
            StartCoroutine(Type());
        }
        else
        {
            text.text = "";
        }
    }
}
