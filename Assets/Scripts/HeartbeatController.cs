using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartbeatController 
{
    AudioSource audioSource;
    AudioClip audioClip;

    AudioClip hb, hb25, hb50, hb75, hb85;

    PlayerController playerOne, playerTwo;
    public float distance;

    public HeartbeatController(PlayerController p1, PlayerController p2)
    {
        playerOne = p1;
        playerTwo = p2;

        audioSource = GameObject.Find("Heartbeat").GetComponent<AudioSource>();
        audioSource.loop = true;

        hb   = Resources.Load<AudioClip>("Audio/Heartbeat");
        hb25 = Resources.Load<AudioClip>("Audio/Heartbeat25");
        hb50 = Resources.Load<AudioClip>("Audio/Heartbeat50");
        hb75 = Resources.Load<AudioClip>("Audio/Heartbeat75");
        hb85 = Resources.Load<AudioClip>("Audio/Heartbeat85");

        audioSource.clip = hb;
    }

    bool changed;
    public void Update()
    {
        distance = Vector2.Distance(playerOne.transform.position, playerTwo.transform.position);

        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
        else
        {
            if (distance < 1)
            {
                audioSource.clip = hb85;
            }
            else if (distance < 1.5)
            {
                audioSource.clip = hb75;
            }
            else if (distance < 2.5)
            {
                audioSource.clip = hb50;
            }
            else if (distance < 3.5)
            {
                audioSource.clip = hb25;
            }
            else
            {
                audioSource.clip = hb;
            }
        }
    }
}
