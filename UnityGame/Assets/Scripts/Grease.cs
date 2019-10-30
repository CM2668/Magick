using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grease : MonoBehaviour
{
	Vector3 vel;
	float lifeTimer = 10;
    float startWalkSpeed;
    float startSprintSpeed;
    Vector3 greaseLocation;
    bool Playercollision;
    bool collision;
    Collider trigger;
    GameObject ground;

    void Start()
    {
        greaseLocation = gameObject.transform.position;
    }

    void Update()
    {
		if (lifeTimer <= 0f)
		{
			Object.Destroy(gameObject);
		}
		lifeTimer -= Time.deltaTime;

        getGround();
    }

    private void OnTriggerEnter(Collider obj)
    {
        //Debug.Log(obj.tag);
        if (obj.tag == "Player")
        {
            Playercollision = true;
            trigger = obj;
            startWalkSpeed = obj.GetComponent<FirstPersonAIO>().walkSpeed;
            startSprintSpeed = obj.GetComponent<FirstPersonAIO>().sprintSpeed;
        }
    }

    void OnTriggerExit(Collider obj)
	{
           
        if (obj.tag == "Player")
		{
			//Debug.Log("EXIT");
			obj.GetComponent<FirstPersonAIO>().walkSpeed = startWalkSpeed;
			obj.GetComponent<FirstPersonAIO>().sprintSpeed = startSprintSpeed;
            //Debug.Log(startWalkSpeed);
		}
	}

	void OnTriggerStay(Collider obj)
	{
        if (obj.tag == "Player")
		{
            if (obj.GetComponent<FirstPersonAIO>().walkSpeed > 0.5)
            {
                obj.GetComponent<FirstPersonAIO>().walkSpeed = obj.GetComponent<FirstPersonAIO>().walkSpeed - .025f;
            }
            if(obj.GetComponent<FirstPersonAIO>().sprintSpeed > 0.5)
            {
                obj.GetComponent<FirstPersonAIO>().sprintSpeed = obj.GetComponent<FirstPersonAIO>().sprintSpeed - .05f;
            }
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


    void getGround()
    {
        RaycastHit hit;
        Ray ray = new Ray(gameObject.transform.position, transform.up);
        int layerMask = 0 << 8;
        layerMask = ~layerMask;

        //Debug.DrawRay(ray.origin, ray.direction, Color.red, 30f);

        if (Physics.Raycast(ray, out hit, 500, layerMask))
        {
            ground = null;
            if(hit.collider.tag == "Ground")
            {
                ground = hit.collider.gameObject;
            }
            if (ground != null && hit.distance >= .2f && hit.collider.gameObject.tag == "Ground")
            {
                float test = hit.distance;
                gameObject.transform.position -= new Vector3(0, .1f, 0);
            }
            else if(ground == null)
            {
                gameObject.transform.position -= new Vector3(0, .1f, 0);
            }
            //unchild = spellTarget.transform.parent;
        }
    }

        //Debug code
        //Debug.DrawRay(ray.origin, ray.direction, Color.red, 5f);
        //if (spellTarget != null && spellTarget.GetComponent<Rigidbody>() != null)
        //    Debug.Log("Target: " + spellTarget.name);
        //else if (spellTarget != null)
        //    Debug.Log(spellTarget.name + " cannot be targeted");
        //else
        //    Debug.Log("No Target | " + ray.GetPoint(10f) + " | " + playerCamera.transform.position);
    

}
