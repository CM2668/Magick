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


    void Start()
    {
        startButton.onClick.AddListener(gameStart);
        optionsButton.onClick.AddListener(optionMenu);
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

}
