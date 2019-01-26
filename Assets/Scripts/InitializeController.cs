using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeController
{
    PlayerController playerOne, playerTwo;

    public InitializeController()
    {
        playerOne = new PlayerController("Player One", 1);
        playerTwo = new PlayerController("Player Two", 2);
    }

    // Update is called once per frame
    public void Update()
    {
        playerOne.Update();
        playerTwo.Update();
    }
}
