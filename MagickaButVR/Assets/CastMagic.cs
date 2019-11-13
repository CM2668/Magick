using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastMagic : MonoBehaviour
{
    public DisplayMagicUI DisplayMagicUI;
    GameObject Spell;

    public GameObject Fireball;

    bool CastingFireball=false;
    bool CastingTelekinesis = false;



    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire2"))
        {
            DisplayMagicUI.Channeling = false;

            if (CastingFireball == true)
            {
                ThrowFireball();

            }
            if (CastingTelekinesis == true)
            {

            }

        }
    }

    public void Cast(string[] Combination)
    {


        if (Combination[0] == "Evocation" && Combination[1] == "Stranger" && Combination[2] == "Primal")
        {
            if (DisplayMagicUI.RightHand.transform.childCount == 0)
            {
                DisplayMagicUI.Channeling = true;
                Spell = Instantiate(Fireball, DisplayMagicUI.RightHand.transform);
                CastingFireball = true;
                Debug.LogWarning("Cast Fireball");
            }
            
        }

        if (Combination[0] == "Transmutation" && Combination[1] == "Stranger" && Combination[2] == "Gravitation")
        {
            DisplayMagicUI.Channeling = true;
            //Code to Cast Telekinesis
            CastingTelekinesis = true;
            //Debug.LogWarning("Cast Telekinesis");
        }

    }

    public void ThrowFireball()
    {
        Spell.transform.parent = null;
        Spell.GetComponent<Rigidbody>().useGravity = true;
        Spell.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
    }



}
