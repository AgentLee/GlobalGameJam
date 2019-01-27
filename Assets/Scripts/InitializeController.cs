using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeController
{
    SceneController sceneController;

    public InitializeController()
    {
        sceneController = new SceneController();
    }

    // Update is called once per frame
    public void Update()
    {
        sceneController.Update();
    }
}

public class SceneController
{
    PlayerController playerOne, playerTwo;
    HeartbeatController heartbeatController;

    AudioSource mainAudio;

    public SceneController()
    {
        playerOne = new PlayerController("Player One", 1);
        playerTwo = new PlayerController("Player Two", 2);

        heartbeatController = new HeartbeatController(playerOne, playerTwo);

        mainAudio = new GameObject("Main Audio").AddComponent<AudioSource>();
        mainAudio.clip = Resources.Load<AudioClip>("Audio/Memo");
        mainAudio.loop = true;
        mainAudio.transform.position = Vector3.zero;
        mainAudio.playOnAwake = false;
        mainAudio.volume = 0.02f;

        hasWon = false;
        victory = GameObject.Find("Victory").transform;
        victory.gameObject.SetActive(false);

        menu = GameObject.Find("Menu").transform;
        menu.gameObject.SetActive(false);
    }

    bool hasWon;
    Transform victory;
    bool showMenu;
    Transform menu;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            showMenu = !showMenu;
        }

        ShowMenu();

        if(!mainAudio.isPlaying)
        {
            mainAudio.Play();
        }

        if (playerOne.transform.GetComponent<PlayerModel>().hitPlayer || playerTwo.transform.GetComponent<PlayerModel>().hitPlayer)
        {
            hasWon = true;
            playerOne.ActivateParticles();
            playerTwo.ActivateParticles();

            victory.gameObject.SetActive(true);
        }

        playerOne.Update();
        playerTwo.Update();

        heartbeatController.Update();
    }

    void ShowMenu()
    {
        menu.gameObject.SetActive(showMenu);
    }
}
