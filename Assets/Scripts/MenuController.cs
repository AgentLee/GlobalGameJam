using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Button startButton, controlsButton, backButton;
    public Transform controls;

    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(delegate { StartGame(); });
        controlsButton.onClick.AddListener(delegate { ShowControls(); });
        backButton.onClick.AddListener(delegate { ShowControls(); });
    }

    void StartGame()
    {
        SceneManager.LoadScene("Main");
    }

    void ShowControls()
    {
        controls.gameObject.SetActive(!controls.gameObject.activeSelf);
    }
}
