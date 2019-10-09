using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainMenuController : MonoBehaviour
{

    public GameObject firstPersonGroup;
    public GameObject MainMenuGroup;
    public GameObject MainMenuScreen;
    public GameObject MainMenuOptions;
    public GameObject OptionsMenu;

    public Button startButton;
    public Button optionsButton;
    public Button quitButton;
    public Button backButton;

    bool InOptionsMenu = false;

    void Start()
    {
        startButton.onClick.AddListener(gameStart);
        optionsButton.onClick.AddListener(optionMenu);
        quitButton.onClick.AddListener(closeGame);
        backButton.onClick.AddListener(backtoMain);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && InOptionsMenu == false)
        {
            InOptionsMenu = true;
            firstPersonGroup.GetComponent<FirstPersonAIO>().playerCanMove = false;
            firstPersonGroup.GetComponent<FirstPersonAIO>().enableCameraMovement = false;
            firstPersonGroup.GetComponent<FirstPersonAIO>().lockAndHideCursor = false;
            OptionsMenu.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && InOptionsMenu == true)
        {
            InOptionsMenu = false;
            firstPersonGroup.GetComponent<FirstPersonAIO>().playerCanMove = true;
            firstPersonGroup.GetComponent<FirstPersonAIO>().enableCameraMovement = true;
            firstPersonGroup.GetComponent<FirstPersonAIO>().lockAndHideCursor=true;
            OptionsMenu.SetActive(false);
        }
    }

    void gameStart()
    {
        MainMenuGroup.SetActive(false);
        firstPersonGroup.SetActive(true);
    }

    void optionMenu()
    {
        MainMenuScreen.SetActive(false);
        MainMenuOptions.SetActive(true);
    }

    void backtoMain()
    {
        MainMenuOptions.SetActive(false);
        MainMenuScreen.SetActive(true);
    }

    void closeGame()
    {
        Application.Quit();
    }

}
