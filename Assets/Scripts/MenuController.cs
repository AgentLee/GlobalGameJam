using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Button startButton, controlsButton, backButton, gameBackButton, exitButton;
    public Transform controls;

    // Start is called before the first frame update
    void Start()
    {
        if(startButton != null)
            startButton.onClick.AddListener(delegate { StartGame(); });

        if(controlsButton != null)
            controlsButton.onClick.AddListener(delegate { ShowControls(); });

        if(backButton != null)
            backButton.onClick.AddListener(delegate { ShowControls(); });

        if (gameBackButton != null)
            gameBackButton.onClick.AddListener(delegate { BackButton(); });

        if (exitButton != null)
            exitButton.onClick.AddListener(delegate { Exit(); });
    }

    void StartGame()
    {
        SceneManager.LoadScene("Main");
    }

    void ShowControls()
    {
        controls.gameObject.SetActive(!controls.gameObject.activeSelf);
    }

    void BackButton()
    {
        GameObject.Find("Menu").SetActive(false);
    }

    void Exit()
    {
        SceneManager.LoadScene("Title");
    }
}
