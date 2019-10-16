using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class UIController : MonoBehaviour
{
    #region Gameobjects
    public GameObject firstPersonGroup;
    public GameObject MainMenuGroup;
    public GameObject MainMenu;
    public GameObject MainMenuOptions;
    public GameObject PauseMenu;
    public GameObject spellDisplay;
    public GameObject HUD;
    public GameObject SpellbookUI;
    public GameObject KnownSpells;
    #endregion

    #region Buttons
    public Button MainToGameButton;
    public Button MainToOptionsButton;
    public Button MainToDesktopButton;
    public Button OptionsToMainButton;
    public Button PauseToDekstopButton;
    public Button PauseToMainButton;
    #endregion

    #region KnowsSpells
    bool knowsFireball = false;
    #endregion

    bool InOptionsMenu = false;
    bool InSpellbookMenu = false;

    void Start()
    {

        MainToGameButton.onClick.AddListener(MainToGame);
        MainToOptionsButton.onClick.AddListener(MainToOptions);
        MainToDesktopButton.onClick.AddListener(ToDesktop);
        OptionsToMainButton.onClick.AddListener(OptionsToMain);
        PauseToMainButton.onClick.AddListener(PauseToMain);
        PauseToDekstopButton.onClick.AddListener(ToDesktop);
    }

    private void Update()
    {
        //open pause menu
        if (Input.GetKeyDown(KeyCode.C) && InOptionsMenu == false)
        {
            InOptionsMenu = true;
            firstPersonGroup.GetComponent<FirstPersonAIO>().playerCanMove = false;
            firstPersonGroup.GetComponent<FirstPersonAIO>().enableCameraMovement = false;
            Cursor.lockState = CursorLockMode.None;
            HUD.SetActive(false);
            Cursor.visible = true;
            PauseMenu.SetActive(true);
            spellDisplay.GetComponent<SpellDisplay>().Clear();
        }
        //close pause menu
        else if (Input.GetKeyDown(KeyCode.C) && InOptionsMenu == true)
        {
            InOptionsMenu = false;
            firstPersonGroup.GetComponent<FirstPersonAIO>().playerCanMove = true;
            firstPersonGroup.GetComponent<FirstPersonAIO>().enableCameraMovement = true;
            Cursor.lockState = CursorLockMode.Locked;
            HUD.SetActive(true);
            Cursor.visible = false;
            PauseMenu.SetActive(false);
        }
        //open Spellbook
        if (Input.GetKeyDown(KeyCode.Tab) && InSpellbookMenu == false)
        {
            InSpellbookMenu = true;
            firstPersonGroup.GetComponent<FirstPersonAIO>().playerCanMove = false;
            firstPersonGroup.GetComponent<FirstPersonAIO>().enableCameraMovement = false;
            Cursor.lockState = CursorLockMode.None;
            HUD.SetActive(false);
            Cursor.visible = true;
            SpellbookUI.SetActive(true);
            spellDisplay.GetComponent<SpellDisplay>().Clear();
        }
        //close Spellbook
        else if(Input.GetKeyDown(KeyCode.Tab) && InSpellbookMenu == true)
        {
            InSpellbookMenu = false;
            firstPersonGroup.GetComponent<FirstPersonAIO>().playerCanMove = true;
            firstPersonGroup.GetComponent<FirstPersonAIO>().enableCameraMovement = true;
            Cursor.lockState = CursorLockMode.Locked;
            HUD.SetActive(true);
            Cursor.visible = false;
            SpellbookUI.SetActive(false);
        }


    }

    void MainToGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        MainMenuGroup.SetActive(false);
        firstPersonGroup.SetActive(true);
        HUD.SetActive(true);
    }

    void MainToOptions()
    {
        MainMenu.SetActive(false);
        MainMenuOptions.SetActive(true);
    }

    void OptionsToMain()
    {
        MainMenuOptions.SetActive(false);
        MainMenu.SetActive(true);
    }

    void PauseToMain()
    {
        PauseMenu.SetActive(false);
        SceneManager.LoadScene("MainScene");
    }

    void ToDesktop()
    {
        Application.Quit();
        Debug.Log("Close Game");
    }

    public void AddToSpellbook(string spellname)
    {
        
        switch (spellname)
        {
            #region Fireball
            case "qee":
                if (knowsFireball == false)
                {
                    knowsFireball = true;
                    KnownSpells.GetComponent<Text>().text += "\nFireball Q-E-E"; 
                }

                break;
            #endregion

            default:
                break;
        }
    }

}
