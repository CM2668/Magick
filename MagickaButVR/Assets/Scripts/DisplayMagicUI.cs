using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DisplayMagicUI : MonoBehaviour
{

    public GameObject SchoolUI;
    public GameObject TargetUI;
    public GameObject ForceUI;
    public GameObject RightHand;
    public bool SchoolUIOpen=false;
    public bool TargetUIOpen = false;
    public bool ForceUIOpen = false;
    public bool Channeling = false;

    public ElementSelect ElementSelect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && SchoolUIOpen == false && Channeling==false)
        {
            OpenSchoolUI();
        }

        else if (Input.GetButtonDown("Fire1") && SchoolUIOpen == true)
        {
            CloseSchoolUI();
            CloseTargetUI();
            CloseForceUI();

            //Clear Magic in Register
            ElementSelect.Combination[0] = null;
            ElementSelect.Combination[1] = null;
            ElementSelect.Combination[2] = null;
        }
    }

    public void OpenSchoolUI()
    {
        SchoolUI.transform.position = RightHand.transform.position;
        SchoolUI.SetActive(true);
        SchoolUIOpen = true;
    }

    public void CloseSchoolUI()
    {
        SchoolUI.SetActive(false);
        SchoolUIOpen = false;
    }

    public void OpenTargetUI()
    {
        TargetUI.transform.position = RightHand.transform.position;
        TargetUI.SetActive(true);
        TargetUIOpen = true;
    }

    public void CloseTargetUI()
    {
        TargetUI.SetActive(false);
        TargetUIOpen = false;
    }

    public void OpenForceUI()
    {
        ForceUI.transform.position = RightHand.transform.position;
        ForceUI.SetActive(true);
        ForceUIOpen = true;
    }

    public void CloseForceUI()
    {
        ForceUI.SetActive(false);
        ForceUIOpen = false;
    }

}
