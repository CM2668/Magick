using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastMagic : MonoBehaviour
{
    public DisplayMagicUI DisplayMagicUI;
    public OVRPlayerController pc;
    private Transform unchild;
    private Material mat = null;
    private RaycastHit hit;

    private Vector3 move; 

    private GameObject Spell;
    public GameObject FireballGameObject;
    public GameObject GreasePoolGameObject;
    public GameObject Righthand;
    public GameObject spellTarget;
    public GameObject player;
    public GameObject spellGuide;
    
    public float spellTimer;
    private float targetDistance;

    private bool playerTouching;
    private bool CastingFireball = false;
    private bool CastingTelekinesis = false;
    private bool OngoingTelekinesis = false;
    private bool CastingJump = false;
    private bool OngoingJump = false;
    private bool CastingHaste = false;
    private bool OngoingHaste = false;
    private bool CastingGreasePool = false;
    

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonDown("Fire2"))
        {
            //Activates Spells
            if (CastingFireball == true)
            {
                Fireball();
                DisplayMagicUI.Channeling = false;
            }//Throws Fireball
            if(CastingGreasePool == true)
            {
                GreasePool();
                DisplayMagicUI.Channeling = false;
            }//Throws Grease Pool
            else if (OngoingTelekinesis == true)
            {
                spellTarget.GetComponent<Rigidbody>().useGravity = true;
                CastingTelekinesis = false;
                OngoingTelekinesis = false;
                spellTarget = null;
                DisplayMagicUI.Channeling = false;
            }//Stops Telekinesis
            else if (CastingTelekinesis == true)
            {
                Telekinesis();
                OngoingTelekinesis = true;
                
            }//Starts Telekinesis
            else if (CastingJump == true)
            {       
                spellTimer = 30;
                OngoingJump = true;
                CastingJump = false;
            }//Starts Jump
            else if (spellTimer > 0 && OngoingJump == true)
            {
                OngoingJump = false;
                DisplayMagicUI.Channeling = false;
            }//Stops Jump
            else if (CastingHaste == true)
            {
                spellTimer = 30;
                OngoingHaste = true;
                CastingHaste = false;
            }//Starts Haste
            else if (spellTimer > 0 && OngoingHaste == true)
            {
                OngoingHaste = false;
                DisplayMagicUI.Channeling = false;
                pc.Acceleration = .08f;
            }//Stops Haste



        }//Activates & Deactivates Timed Spells      
        #region JumpTimer
        if (spellTimer > 0 && OngoingJump == true) //starts jump while timer is going and player hasnt canceled it
            pc.JumpForce = .6f;
        else if(spellTimer < 0 && OngoingJump == true)
        {
            pc.JumpForce = .3f;
            DisplayMagicUI.Channeling = false;
            OngoingJump = false;
        }
        #endregion
        #region HasteTimer
        if (spellTimer > 0 && OngoingHaste == true) //starts jump while timer is going and player hasnt cancelled it
            pc.Acceleration = .3f;
        else if (spellTimer < 0 && OngoingHaste == true)
        {
            pc.Acceleration = .08f;
            DisplayMagicUI.Channeling = false;
            OngoingHaste = false;
        }
        #endregion

        spellTimer -= Time.deltaTime;

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
    

    public void Cast(string[] Combination)//Determines What spell to use
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
            
        }//Fireball

        if (Combination[0] == "Evocation" && Combination[1] == "Area" && Combination[2] == "Primal")
        {
            if (DisplayMagicUI.RightHand.transform.childCount == 1)
            {
                DisplayMagicUI.Channeling = true;
                Spell = Instantiate(GreasePoolGameObject, DisplayMagicUI.RightHand.transform);
                DisplayMagicUI.RightHand.transform.GetChild(1).GetComponent<SphereCollider>().isTrigger = false;
                CastingGreasePool = true;
                Debug.LogWarning("Cast Grease Pool");
            }

        }//Grease Pool

        if (Combination[0] == "Transmutation" && Combination[1] == "Stranger" && Combination[2] == "Gravitation")
        {
            DisplayMagicUI.Channeling = true;
            CastingTelekinesis = true;
            Debug.LogWarning("Cast Telekinesis");
        }//Telekinesis

        if (Combination[0] == "Enchantment" && Combination[1] == "Self" && Combination[2] == "Gravitation")
        {
            DisplayMagicUI.Channeling = true;
            CastingJump = true;
            Debug.LogWarning("Cast Jump");
        }//Jump

        if (Combination[0] == "Enchantment" && Combination[1] == "Self" && Combination[2] == "Ascendant")
        {
            DisplayMagicUI.Channeling = true;
            CastingHaste = true;
            Debug.LogWarning("Cast Haste");
        }//Haste

        

    }

    public void Fireball()
    {
        Spell.transform.parent = null;
        Spell.GetComponent<Rigidbody>().useGravity = true;
        Spell.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
        CastingFireball = false;
    }//Code for launching Fireball

    public void GreasePool()
    {
        DisplayMagicUI.RightHand.transform.GetChild(1).GetComponent<SphereCollider>().isTrigger = true;
        Spell.transform.parent = null;
        Spell.GetComponent<Rigidbody>().useGravity = true;
        Spell.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);       
        CastingGreasePool = false;
    }

    public void Telekinesis()
    {

        GetTarget();
        //Determines if object is allowed to be targeted
        if (spellTarget != null)
        {
            if (spellTarget.GetComponent<Rigidbody>() != null && spellTarget != player)
            {
                //activates effects of telekinesis
                spellTarget.GetComponent<Rigidbody>().useGravity = false;

            }
        }
        else
        {
            OngoingTelekinesis = false;
            CastingTelekinesis = false;
            DisplayMagicUI.Channeling = false;
        }
    } //Code for Activating Telekinesis

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
            Debug.LogWarning("No Target Hit");
        /*
        if (spellTarget != null && spellTarget.GetComponent<Rigidbody>() != null)
            Debug.LogWarning("Target: " + spellTarget.name);
        else if (spellTarget != null)
            Debug.LogWarning(spellTarget.name + " cannot be targeted");
        else
            Debug.LogWarning("No Target | " + ray.GetPoint(10f) + " | " + Righthand.transform.position);
            */
    }//Code for Raycasting to Target
}
