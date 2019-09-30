using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grease : MonoBehaviour
{
	Vector3 vel;
	float lifeTimer = 10;
	float explosionTimer = 3;
	bool collide = false;
    float startWalkSpeed;
    float startSprintSpeed;
    bool Playercollision;
    Collider trigger;

    void Start()
    {
        
	}

    void Update()
    {
		if (lifeTimer <= 0f)
		{
			Object.Destroy(gameObject);
		}
		lifeTimer -= Time.deltaTime;
	}

	void OnTriggerExit(Collider obj)
	{
        
        if (obj.tag == "Player")
		{
			Debug.Log("EXIT");
			obj.GetComponent<FirstPersonAIO>().walkSpeed = startWalkSpeed;
			obj.GetComponent<FirstPersonAIO>().sprintSpeed = startSprintSpeed;
            Debug.Log(startWalkSpeed);
		}
	}

	void OnTriggerStay(Collider obj)
	{
        if (obj.tag == "Player")
		{
            if (obj.GetComponent<FirstPersonAIO>().walkSpeed > 0)
            {
                obj.GetComponent<FirstPersonAIO>().walkSpeed = obj.GetComponent<FirstPersonAIO>().walkSpeed - .025f;
            }
            if(obj.GetComponent<FirstPersonAIO>().sprintSpeed > 0)
            {
                obj.GetComponent<FirstPersonAIO>().sprintSpeed = obj.GetComponent<FirstPersonAIO>().sprintSpeed - .05f;
            }
			
		}
	}

    private void OnTriggerEnter(Collider obj)
    {
        if (obj.tag == "Player")
        {
            Playercollision = true;
            trigger = obj;
            startWalkSpeed = obj.GetComponent<FirstPersonAIO>().walkSpeed;
            startSprintSpeed = obj.GetComponent<FirstPersonAIO>().sprintSpeed;
        }
    }

    private void OnDestroy()
    {
        if (Playercollision == true)
        {
            trigger.GetComponent<FirstPersonAIO>().walkSpeed = startWalkSpeed;
            trigger.GetComponent<FirstPersonAIO>().sprintSpeed = startSprintSpeed;
        }
    }
}
