using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Script to manage what happens in the main menu
public class TitleMenuController : MonoBehaviour
{
    TitleMenuController instance;

    public GameObject platformConfirmationPanel;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        platformConfirmationPanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            platformConfirmationPanel.SetActive(true);
        }
    }

    //functions for when you select what platform you're playing on
    public void mobileControls()
    {
        ControllerPlatformHandler.instance.computerControls = false;
        ControllerPlatformHandler.instance.touchControls = true;
        SceneManager.LoadScene("GameScene");
    }

    public void computerControls()
    {
        ControllerPlatformHandler.instance.computerControls = true;
        ControllerPlatformHandler.instance.touchControls = false;
        SceneManager.LoadScene("GameScene");
    }

}
