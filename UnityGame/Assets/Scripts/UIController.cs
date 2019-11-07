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
    public Button PauseToGameButton;
    public Button PauseToOptionsButton;
    public Button PauseToCreditsButton;
    public Button PauseToMainButton;
    #endregion

    #region KnowsSpells
    bool knowsFireball = false;
    bool knowsGreaseBall = false;
    bool knowsJump = false;
    bool knowsHaste = false;
    bool knowsLevitation = false;
    bool knowsTelekinesis = false;
    #endregion

    bool InOptionsMenu = false;
    bool InSpellbookMenu = false;

    void Start()
    {
        MainToGameButton.onClick.AddListener(MainToGame);
        MainToOptionsButton.onClick.AddListener(MainToOptions);
        MainToDesktopButton.onClick.AddListener(ToDesktop);
        OptionsToMainButton.onClick.AddListener(OptionsToMain);
        PauseToGameButton.onClick.AddListener(PauseToGame);
        PauseToOptionsButton.onClick.AddListener(PauseToOptions);
        PauseToCreditsButton.onClick.AddListener(PauseToCredits);
        PauseToMainButton.onClick.AddListener(PauseToMain);
    }

    private void Update()
    {
        //open pause menu
        if (Input.GetKeyDown(KeyCode.Escape) && InOptionsMenu == false)
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
        else if (Input.GetKeyDown(KeyCode.Escape) && InOptionsMenu == true)
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
		PersistentManager.instance.SetPlayer(firstPersonGroup);
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

    void PauseToGame()
    {
        InOptionsMenu = false;
        firstPersonGroup.GetComponent<FirstPersonAIO>().playerCanMove = true;
        firstPersonGroup.GetComponent<FirstPersonAIO>().enableCameraMovement = true;
        Cursor.lockState = CursorLockMode.Locked;
        HUD.SetActive(true);
        Cursor.visible = false;
        PauseMenu.SetActive(false);
    }

    void PauseToOptions()
    {
        Debug.Log("open Options");
    }

    void PauseToCredits()
    {
        Debug.Log("open Credits");
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
            #region Grease Ball
            case "qre":
                if (knowsGreaseBall == false)
                {
                    knowsGreaseBall = true;
                    KnownSpells.GetComponent<Text>().text += "\nGrease Ball Q-R-E";
                }

                break;
            #endregion
            #region Jump
            case "eqq":
                if (knowsJump == false)
                {
                    knowsJump = true;
                    KnownSpells.GetComponent<Text>().text += "\nJump E-Q-Q";
                }

                break;
            #endregion
            #region Haste
            case "eqf":
                if (knowsHaste == false)
                {
                    knowsHaste = true;
                    KnownSpells.GetComponent<Text>().text += "\nHaste E-Q-F";
                }

                break;
            #endregion
            #region Levitation
            case "eeq":
                if (knowsLevitation == false)
                {
                    knowsLevitation = true;
                    KnownSpells.GetComponent<Text>().text += "\nLevitation E-E-Q";
                }
                break;
            #endregion
            #region Telekinesis
            case "req":
                if (knowsTelekinesis == false)
                {
                    knowsTelekinesis = true;
                    KnownSpells.GetComponent<Text>().text += "\nTelekinesis R-E-Q";
                }
                break;
            #endregion

            default:
                break;
        }
    }

}
