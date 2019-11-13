using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastMagic : MonoBehaviour
{
    public DisplayMagicUI DisplayMagicUI;
    GameObject Spell;
    Transform unchild;

    public GameObject FireballGameObject;
    public GameObject Righthand;
    public GameObject spellTarget;
    public GameObject player;
    public GameObject spellGuide;
    Material mat = null;

    bool CastingFireball = false;
    bool CastingTelekinesis = false;
    RaycastHit hit;
    bool OngoingTelekinesis = false;

    float targetDistance; //Distance between target and object (Telekinesis)
    bool playerTouching; //Determines if player is touching object that is being targeted

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire2"))
        {
            if (CastingFireball == true)
            {
                Fireball();
                DisplayMagicUI.Channeling = false;
            }
            else if (OngoingTelekinesis == true)
            {
                spellTarget.GetComponent<Rigidbody>().useGravity = true;
                DisplayMagicUI.Channeling = false;
                CastingTelekinesis = false;
                OngoingTelekinesis = false;
                spellTarget = null;
            }
            else if (CastingTelekinesis == true)
            {
                Telekinesis();
                OngoingTelekinesis = true;
            }
            
        }

        if (OngoingTelekinesis == true)
        {
            if (spellTarget == null)
            {
                OngoingTelekinesis = false;
                CastingTelekinesis = false;
                DisplayMagicUI.Channeling = false;

            }
            else
            {
                //Debug.LogWarning("Target: " + spellTarget.name);
                targetDistance = Vector3.Distance(spellGuide.transform.position, spellTarget.transform.position);
                float ForceMod = 300;
                ForceMod = ForceMod * targetDistance;
                if (targetDistance >= .2 && playerTouching == false)
                {
                    spellTarget.GetComponent<Rigidbody>().velocity = spellTarget.GetComponent<Rigidbody>().velocity / 4f;
                    spellTarget.GetComponent<Rigidbody>().AddForce((spellGuide.transform.position - spellTarget.transform.position).normalized * (ForceMod) * Time.smoothDeltaTime, mode: ForceMode.Impulse);
                }
                else if (playerTouching == true)
                {
                    spellTarget.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                }
                else if (targetDistance <= .15 && spellTarget.GetComponent<Rigidbody>().velocity.x <= .2f && spellTarget.GetComponent<Rigidbody>().velocity.y <= .2f && spellTarget.GetComponent<Rigidbody>().velocity.z <= .2f)
                {
                    spellTarget.GetComponent<Rigidbody>().velocity += new Vector3(Random.Range(-.05f, .05f), Random.Range(-.05f, .05f), Random.Range(-.05f, .05f));
                }
            }
        }
    }

    public void Cast(string[] Combination)
    {

        if (Combination[0] == "Evocation" && Combination[1] == "Stranger" && Combination[2] == "Primal")
        {
            if (DisplayMagicUI.RightHand.transform.childCount == 1)
            {
                DisplayMagicUI.Channeling = true;
                Spell = Instantiate(FireballGameObject, DisplayMagicUI.RightHand.transform);
                CastingFireball = true;
                Debug.LogWarning("Cast Fireball");
            }
            
        }

        if (Combination[0] == "Transmutation" && Combination[1] == "Stranger" && Combination[2] == "Gravitation")
        {
            DisplayMagicUI.Channeling = true;
            CastingTelekinesis = true;
            Debug.LogWarning("Cast Telekinesis");
        }

    }

    public void Fireball()
    {
        Spell.transform.parent = null;
        Spell.GetComponent<Rigidbody>().useGravity = true;
        Spell.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
        CastingFireball = false;
    }

    public void Telekinesis()
    {

        GetTarget();
        //Determines if object is allowed to be targeted
        if (spellTarget.GetComponent<Rigidbody>() != null && spellTarget != player)
        {
            //activates effects of telekinesis
            spellTarget.GetComponent<Rigidbody>().useGravity = false;

        }
    }

    public void GetTarget()
    {
        Ray ray = new Ray(Righthand.transform.position, Righthand.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction, Color.red, 30f);

        if (Physics.Raycast(ray, out hit, 50))
        {
            if (hit.collider != null && hit.collider.gameObject.tag != "Enemy" && hit.collider.gameObject.layer != 2)
            {
                spellTarget = hit.transform.gameObject;
                unchild = spellTarget.transform.parent;
            }
        }
        else
            Debug.LogWarning("Already have a target");
        /*
        if (spellTarget != null && spellTarget.GetComponent<Rigidbody>() != null)
            Debug.LogWarning("Target: " + spellTarget.name);
        else if (spellTarget != null)
            Debug.LogWarning(spellTarget.name + " cannot be targeted");
        else
            Debug.LogWarning("No Target | " + ray.GetPoint(10f) + " | " + Righthand.transform.position);
            */
    }
}
