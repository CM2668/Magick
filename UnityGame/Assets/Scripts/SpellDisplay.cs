using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellDisplay : MonoBehaviour
{
    public GameObject fireball;
	public GameObject grease;
    public GameObject player;
    public GameObject playerCamera;
	public GameObject spellTarget;
	public GameObject spellGuide;

	Transform unchild;
	Text text;
    string activeSpell = null; //determines if there is a spell effect currently active
    string input = "";
    string displayText = "";
    double timer;
	public float ForceMod = 1000f;
    public float spellLongevity = 5f; //length of spell effects
    float targetDistance; //distance between target and object (Telekinesis)
    bool playerTouching; //determines if player is touching object that is being targeted
    Vector3 move;
    double spellEffectsTimer = 0;
    GameObject newRune1 = null;
    GameObject newRune2 = null;
    GameObject newRune3 = null;
    char[,] symbols = new char[3,4] {{'\u16B2', '\u16B7', '\u16D2', '\u16C7' }, {'\u16D7', '\u16C1', '\u0000', '\u16C3' }, {'\u16D6', /*'\u16BB'*/'ᚻ', '\u16AB', '\u16C8' }};


    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        //Detects spell inputs
        if (Input.anyKeyDown && timer <= 0 && !string.IsNullOrEmpty(Input.inputString) && activeSpell == null)
        {
            //timer = .5;
            input = Input.inputString.ToLower();
            if (input == "q" || input == "e" || input == "r" || input == "f")
            {
                //ensures spells only go to 3 commands
                if (displayText.Length < 3)
                {
                    //Display rune
                    switch (input)
                    {
                        case "q":
                            if (displayText.Length == 0)
                            {
                                newRune1 = Instantiate(Resources.Load("Runes/Evocation"), gameObject.transform) as GameObject;
                                newRune1.transform.localScale = new Vector3(4f, 4f, 4f);
                                newRune1.transform.localPosition = newRune1.transform.localPosition + new Vector3(-30f, -50f, 0f);

                            }
                            else if (displayText.Length == 1)
                            {
                                newRune2 = Instantiate(Resources.Load("Runes/Self"), gameObject.transform) as GameObject;
                                newRune2.transform.localScale = new Vector3(3.4f, 3.4f, 3.4f);
                                newRune2.transform.localPosition = newRune2.transform.localPosition + new Vector3(0f, -50f, 0f);
                            }
                            else if (displayText.Length == 2)
                            {
                                newRune3 = Instantiate(Resources.Load("Runes/Gravity"), gameObject.transform) as GameObject;
                                newRune3.transform.localScale = new Vector3(2.6f, 2.6f, 2.6f);
                                newRune3.transform.localPosition = newRune3.transform.localPosition + new Vector3(30f, -50f, 0f);
                            }
                            break;
                        case "e":
							if (displayText.Length == 0)
							{
								newRune1 = Instantiate(Resources.Load("Runes/Enchantment"), gameObject.transform) as GameObject;
								newRune1.transform.localScale = new Vector3(4.5f, 4.5f, 4.5f);
								newRune1.transform.localPosition = newRune1.transform.localPosition + new Vector3(-30f, -50f, 0f);

							}
							else if (displayText.Length == 1)
							{
								newRune2 = Instantiate(Resources.Load("Runes/Stranger"), gameObject.transform) as GameObject;
								newRune2.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
								newRune2.transform.localPosition = newRune2.transform.localPosition + new Vector3(0f, -50f, 0f);
							}
							else if (displayText.Length == 2)
							{
								newRune3 = Instantiate(Resources.Load("Runes/Primal"), gameObject.transform) as GameObject;
								newRune3.transform.localScale = new Vector3(4.5f, 4.5f, 4.5f);
								newRune3.transform.localPosition = newRune3.transform.localPosition + new Vector3(30f, -50f, 0f);
							}
							break;
                        case "r":
							if (displayText.Length == 0)
							{
								newRune1 = Instantiate(Resources.Load("Runes/Transmutation"), gameObject.transform) as GameObject;
								newRune1.transform.localScale = new Vector3(3f, 3f, 3f);
								newRune1.transform.localPosition = newRune1.transform.localPosition + new Vector3(-30f, -50f, 0f);

							}
							else if (displayText.Length == 1)
							{
								newRune2 = Instantiate(Resources.Load("Runes/Area"), gameObject.transform) as GameObject;
								newRune2.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
								newRune2.transform.localPosition = newRune2.transform.localPosition + new Vector3(0f, -50f, 0f);
							}
							else if (displayText.Length == 2)
							{
								newRune3 = Instantiate(Resources.Load("Runes/Mental"), gameObject.transform) as GameObject;
								newRune3.transform.localScale = new Vector3(4f, 4f, 4f);
								newRune3.transform.localPosition = newRune3.transform.localPosition + new Vector3(30f, -50f, 0f);
							}
							break;
                        case "f":
							if (displayText.Length == 0)
							{
								newRune1 = Instantiate(Resources.Load("Runes/Illusion"), gameObject.transform) as GameObject;
								newRune1.transform.localScale = new Vector3(2.8f, 2.8f, 2.8f);
								newRune1.transform.localPosition = newRune1.transform.localPosition + new Vector3(-30f, -50f, 0f);

							}
							else if (displayText.Length == 1)
							{
								newRune2 = Instantiate(Resources.Load("Runes/World"), gameObject.transform) as GameObject;
								newRune2.transform.localScale = new Vector3(3.2f, 3.2f, 3.2f);
								newRune2.transform.localPosition = newRune2.transform.localPosition + new Vector3(0f, -50f, 0f);
							}
							else if (displayText.Length == 2)
							{
								newRune3 = Instantiate(Resources.Load("Runes/Ascendant"), gameObject.transform) as GameObject;
								newRune3.transform.localScale = new Vector3(3f, 3f, 3f);
								newRune3.transform.localPosition = newRune3.transform.localPosition + new Vector3(30f, -50f, 0f);
							}
							break;
                        default:
                            break;
                    }

                    displayText += input;
                }
                text.text = displayText;
				
			}
			
        }

        //Detects if spell timer is up or user is ending spell
        if ((spellEffectsTimer <= 0 || Input.GetMouseButtonDown(1)) && activeSpell != null)
        {
            switch (activeSpell)
            {
                case "JUMP":
                    player.GetComponent<FirstPersonAIO>().jumpPower = 5;    // HEY LOOKIE HERE: This should probably be changed to be a variable in some way
                    text.text = "";
                    break;
                case "HASTE":
                    player.GetComponent<FirstPersonAIO>().sprintSpeed = 7;
                    text.text = "";
                    break;
                case "TELEKINESIS":
                    spellTarget.GetComponent<Rigidbody>().useGravity = true;
                    //spellTarget.transform.parent = unchild;
                    text.text = "";
                    break;
                case "LEVITATION":
                    Destroy(spellTarget.GetComponent<Levitate>());
                    spellTarget.GetComponent<Rigidbody>().useGravity = true;
                    spellTarget.GetComponent<Rigidbody>().freezeRotation = false;
                    break;
                default:
                    displayText = "";
                    text.text = "";
                    break;
            }
            //clear runes
            if (newRune1 != null)
            {
                GameObject.Destroy(newRune1);
                newRune1 = null;
            }
            if (newRune2 != null)
            {
                GameObject.Destroy(newRune2);
                newRune2 = null;
            }
            if (newRune3 != null)
            {
                GameObject.Destroy(newRune3);
                newRune3 = null;
            }
            activeSpell = null;
            spellEffectsTimer = 0;
        }

        else if (Input.GetMouseButtonDown(1))
        {
            displayText = "";
            text.text = "";
            //clear runes
            if (newRune1 != null)
            {
                GameObject.Destroy(newRune1);
                newRune1 = null;
            }
            if (newRune2 != null)
            {
                GameObject.Destroy(newRune2);
                newRune2 = null;
            }
            if (newRune3 != null)
            {
                GameObject.Destroy(newRune3);
                newRune3 = null;
            }
        }

        else if (spellEffectsTimer > 0)
        {
            spellEffectsTimer -= Time.deltaTime;
        }
        if (spellEffectsTimer > 0 && activeSpell != null)
		{
			switch (activeSpell)
			{
				case "TELEKINESIS":
                    targetDistance = Vector3.Distance(spellGuide.transform.position, spellTarget.transform.position);
                    ForceMod = 2000;
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
                    break;
				default:
					break;
			}
		}

		timer -= Time.deltaTime;
    }

	void FixedUpdate()
	{
		if(player.GetComponent<FirstPersonAIO>().sprintSpeed != 7)
		{
			//edit the FOV here... somehow
		}

        if (Input.mouseScrollDelta != new Vector2(0, 0))
        {
            switch (activeSpell)
            {
                case "TELEKINESIS":
                    if (Vector3.Distance(spellGuide.transform.position, player.transform.position) <= 10 && Vector3.Distance(spellGuide.transform.position, player.transform.position) >= 3)
                    {
                        //Debug.Log((Vector3.Distance(spellGuide.transform.position, player.transform.position)));
                        move = spellGuide.transform.localPosition;
                        move.z += Input.mouseScrollDelta.y / 10f;
                        spellGuide.transform.localPosition = move;
                    }
                    else if(Vector3.Distance(spellGuide.transform.position, player.transform.position) > 10 && Input.mouseScrollDelta.y <= 0)
                    {
                        //Debug.Log((Vector3.Distance(spellGuide.transform.position, player.transform.position)));
                        move = spellGuide.transform.localPosition;
                        move.z = 9.5f;
                        spellGuide.transform.localPosition = move;
                    }
                    else if (Vector3.Distance(spellGuide.transform.position, player.transform.position) < 3 && Input.mouseScrollDelta.y >= 0)
                    {
                        //Debug.Log((Vector3.Distance(spellGuide.transform.position, player.transform.position)));
                        move = spellGuide.transform.localPosition;
                        move.z = 3.2f;
                        spellGuide.transform.localPosition = move;
                    }
                    break;
                default:
                    break;
            }
        }

		if(Input.GetMouseButtonDown(0) && displayText.Length == 3 && timer <= 0 && activeSpell == null)
		{
            switch (displayText)
            {
                //
                case "qqq":
                    displayText = "";
                    text.text = "";
                    break;
                //
                case "qqe":
                    displayText = "";
                    text.text = "";
                    break;
                //
                case "qqr":
                    displayText = "";
                    text.text = "";
                    break;
                //
                case "qqf":
                    displayText = "";
                    text.text = "";
                    break;
                //
                case "qeq":
                    displayText = "";
                    text.text = "";
                    break;

                //Fireball
                case "qee":
                    displayText = "";
                    text.text = "Fireball";
                    Instantiate(fireball, new Vector3(playerCamera.transform.position.x, playerCamera.transform.position.y + .1f, playerCamera.transform.position.z), playerCamera.transform.rotation);
                    break;
                //
                case "qer":
                    displayText = "";
                    text.text = "";
                    break;
                //
                case "qef":
                    displayText = "";
                    text.text = "";
                    break;
                //
                case "qrq":
                    displayText = "";
                    text.text = "";
                    break;
                //Grease Pool
                case "qre":
                    displayText = "";
                    text.text = "Grease Pool";
                    Instantiate(grease, new Vector3(playerCamera.transform.position.x, playerCamera.transform.position.y + .1f, playerCamera.transform.position.z), playerCamera.transform.rotation);
                    break;
                //
                case "qrr":
                    displayText = "";
                    text.text = "";
                    break;
                //
                case "qrf":
                    displayText = "";
                    text.text = "";
                    break;
                //
                case "qfq":
                    displayText = "";
                    text.text = "";
                    break;
                //
                case "qfe":
                    displayText = "";
                    text.text = "";
                    break;
                //
                case "qfr":
                    displayText = "";
                    text.text = "";
                    break;
                //
                case "qff":
                    displayText = "";
                    text.text = "";
                    break;

                //Jump
                case "eqq":
                    if (activeSpell == null)
                    {
                        displayText = "";
                        text.text = "JUMP";
                        player.GetComponent<FirstPersonAIO>().jumpPower = 10;
                        spellEffectsTimer = spellLongevity;
                        activeSpell = "JUMP";
                    }
                    else
                    {
                        displayText = "";
                        text.text = activeSpell + " IN USE";
                    }
                    break;
                //
                case "eqe":
                    displayText = "";
                    text.text = "";
                    break;
                //
                case "eqr":
                    displayText = "";
                    text.text = "";
                    break;
                //Haste
                case "eqf":
                    if (activeSpell == null)
                    {
                        displayText = "";
                        text.text = "HASTE";
                        player.GetComponent<FirstPersonAIO>().sprintSpeed = 10;
                        spellEffectsTimer = spellLongevity;
                        activeSpell = "HASTE";
                    }
                    else
                    {
                        displayText = "";
                        text.text = activeSpell + "IN USE";
                    }
                    break;

				//Levitation
				case "eeq":
					if (activeSpell == null)
					{
						displayText = "";
						text.text = "LEVITATION";
						getTarget();
						if (spellTarget.GetComponent<Rigidbody>() != null && spellTarget != player)
						{
                            spellTarget.GetComponent<Rigidbody>().useGravity = false;
							spellTarget.GetComponent<Rigidbody>().freezeRotation = true;
							spellTarget.AddComponent<Levitate>();
							spellEffectsTimer = spellLongevity * 6;
							activeSpell = "LEVITATION";
						}
					}
					else
					{
						displayText = "";
						text.text = activeSpell + "IN USE";
					}
					break;
				//
				case "eee":
					displayText = "";
                    text.text = "";
                    break;
				//
				case "eer":
					displayText = "";
                    text.text = "";
                    break;
				//
				case "eef":
					displayText = ""; 
                    text.text = "";
                    break;
				//
				case "erq":
					displayText = "";
                    text.text = "";
                    break;
				//
				case "ere":
					displayText = "";
                    text.text = "";
                    break;
				//
				case "err":
					displayText = "";
                    text.text = "";
                    break;
				//
				case "erf":
					displayText = "";
                    text.text = "";
                    break;
				//
				case "efq":
					displayText = "";
                    text.text = "";
                    break;
				//
				case "efe":
					displayText = "";
                    text.text = "";
                    break;
				//
				case "efr":
					displayText = "";
                    text.text = "";
                    break;
				//
				case "eff":
					displayText = "";
                    text.text = "";
                    break;
				//
				case "rqq":
					displayText = "";
                    text.text = "";
                    break;
				//
				case "rqe":
					displayText = "";
                    text.text = "";
                    break;
				//
				case "rqr":
					displayText = "";
                    text.text = "";
                    break;
				//
				case "rqf":
					displayText = "";
                    text.text = "";
                    break;
				//Telekinesis
				case "req":
					if (activeSpell == null)
					{
						displayText = "";
						text.text = "TELEKINESIS";
						getTarget();
                        if (spellTarget.GetComponent<Rigidbody>() != null && spellTarget != player)
						{
							spellTarget.GetComponent<Rigidbody>().useGravity = false;
							spellEffectsTimer = spellLongevity * 10;
							activeSpell = "TELEKINESIS";
						}
					}
					else
					{
						displayText = "";
						text.text = activeSpell + "IN USE";
					}
					break;
				//
				case "ree":
					displayText = "";
                    text.text = "";
                    break;
				//
				case "rer":
					displayText = "";
                    text.text = "";
                    break;
				//Polymorph Larger
				case "ref":
					displayText = "";
                    text.text = "";
                    break;
				//
				case "rrq":
					displayText = "";
                    text.text = "";
                    break;
				//
				case "rre":
					displayText = "";
                    text.text = "";
                    break;
				//
				case "rrr":
					displayText = ""; 
                    text.text = "";
                    break;
				//
				case "rrf":
					displayText = "";
                    text.text = "";
                    break;
				//
				case "rfq":
					displayText = "";
                    text.text = "";
                    break;
				//
				case "rfe":
					displayText = "";
                    text.text = "";
                    break;
				//
				case "rfr":
					displayText = "";
                    text.text = "";
                    break;
				//
				case "rff":
					displayText = "";
                    text.text = "";
                    break;
				//
				case "fqq":
					displayText = "";
                    text.text = "";
                    break;
				//
				case "fqe":
					displayText = "";
                    text.text = "";
                    break;
				//
				case "fqr":
					displayText = "";
                    text.text = "";
                    break;
				//
				case "fqf":
					displayText = "";
                    text.text = "";
                    break;
				//
				case "feq":
					displayText = "";
                    text.text = "";
                    break;
				//
				case "fee":
					displayText = "";
                    text.text = "";
                    break;
				//
				case "fer":
					displayText = "";
                    text.text = "";
                    break;
				//
				case "fef":
					displayText = "";
                    text.text = "";
                    break;
				//
				case "frq":
					displayText = "";
                    text.text = "";
                    break;
				//
				case "fre":
					displayText = "";
                    text.text = "";
                    break;
				//
				case "frr":
					displayText = "";
                    text.text = "";
                    break;
				//
				case "frf":
					displayText = "";
                    text.text = "";
                    break;
				//
				case "ffq":
					displayText = "";
                    text.text = "";
                    break;
				//
				case "ffe":
					displayText = "";
                    text.text = "";
                    break;
				//
				case "ffr":
					displayText = "";
                    text.text = "";
                    break;
				//
				case "fff":
					displayText = "";
                    text.text = "";
                    break;
				default:
                    displayText = "";
                    text.text = "";
                    break;
            }
            //clear runes
            if (newRune1 != null)
            {
                GameObject.Destroy(newRune1);
                newRune1 = null;
            }
            if (newRune2 != null)
            {
                GameObject.Destroy(newRune2);
                newRune2 = null;
            }
            if (newRune3 != null)
            {
                GameObject.Destroy(newRune3);
                newRune3 = null;
            }

        }
	}

	void getTarget()
	{
		RaycastHit hit;
		Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
		int layerMask = 0 << 8;
		layerMask = ~layerMask;

		if (Physics.Raycast(ray, out hit, 50, layerMask))
		{
			if (hit.collider != null)
			{
				spellTarget = hit.transform.gameObject;
				unchild = spellTarget.transform.parent;
			}
		}
		else
			Debug.Log("Already have a target");

		//Debug code
		//Debug.DrawRay(ray.origin, ray.direction, Color.red, 5f);
		if (spellTarget != null && spellTarget.GetComponent<Rigidbody>() != null)
			Debug.Log("Target: " + spellTarget.name);
		else if (spellTarget != null)
			Debug.Log(spellTarget.name + " cannot be targeted");
		else
			Debug.Log("No Target | " + ray.GetPoint(10f) + " | " + playerCamera.transform.position);
	}


    public void telekinesisCollide(Collider other, bool touch)
    {
        Debug.Log(other);
        Debug.Log(touch);

        if(other = spellTarget.GetComponent<Collider>())
        {
            if(touch == true)
            {
                Debug.Log("Touching: " + other);
                playerTouching = true;
            }
            else if(touch == false)
            {
                Debug.Log("Stopped touching: " + other);
                playerTouching = false;
            }
        }

    }
}

