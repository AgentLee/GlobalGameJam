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

    public SceneController()
    {
        playerOne = new PlayerController("Player One", 1);
        playerTwo = new PlayerController("Player Two", 2);

        heartbeatController = new HeartbeatController(playerOne, playerTwo);
    }

    public void Update()
    {
        if(playerOne.transform.GetComponent<PlayerModel>().hitPlayer || playerTwo.transform.GetComponent<PlayerModel>().hitPlayer)
        {
            Debug.Log("WIN");
        }

            playerOne.Update();
        playerTwo.Update();

        heartbeatController.Update();
    }
}
