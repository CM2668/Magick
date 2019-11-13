using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementSelect : MonoBehaviour
{
    public GameObject RightHand;

    public DisplayMagicUI DisplayMagicUI;
    public CastMagic CastMagic;

    static public string[] Combination = new string[3];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == RightHand.gameObject)
        {

            if (DisplayMagicUI.SchoolUIOpen == true && DisplayMagicUI.TargetUIOpen == false && DisplayMagicUI.ForceUIOpen == false)
            {
                DisplayMagicUI.CloseSchoolUI();
                DisplayMagicUI.OpenTargetUI();
                Combination[0] = this.name;
            }

            else if(DisplayMagicUI.SchoolUIOpen == false && DisplayMagicUI.TargetUIOpen == true && DisplayMagicUI.ForceUIOpen == false)
            {
                DisplayMagicUI.CloseTargetUI();
                DisplayMagicUI.OpenForceUI();
                Combination[1] = this.name;
            }

            else
            {
                DisplayMagicUI.CloseForceUI();
                Combination[2] = this.name;
                Debug.LogWarning(Combination[0] + ", " + Combination[1] + ", " + Combination[2]);
                CastMagic.Cast(Combination);
            }
        }
    }
}
