using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    AudioSource source;
    public AudioClip coin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name.Contains("Player"))
        {
            Destroy(gameObject);
        }
    }
}
