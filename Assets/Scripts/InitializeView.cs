using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeView : MonoBehaviour
{
    InitializeController initializeController;

    // Start is called before the first frame update
    void Start()
    {
        initializeController = new InitializeController();
    }

    // Update is called once per frame
    void Update()
    {
        initializeController.Update();
    }
}
