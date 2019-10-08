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

    public Button startButton;
    public Button optionsButton;
    public Button quitButton;
    public Button backButton;

    void Start()
    {
        startButton.onClick.AddListener(gameStart);
        optionsButton.onClick.AddListener(optionMenu);
        quitButton.onClick.AddListener(closeGame);
        backButton.onClick.AddListener(backtoMain);
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
