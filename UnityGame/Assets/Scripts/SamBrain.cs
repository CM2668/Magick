using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamBrain : MonoBehaviour
{
	GameObject enemy;

    void Start()
    {
        
    }

    void Update()
    {
		if(enemy != null)
		{
			Debug.Log("I SEE YOU");
		}
    }

	void FixedUpdate()
	{
		if(enemy != null)
		{
			MoveToTarget();
		}
	}

	void OnTriggerStay(Collider obj)
	{
		if(obj.tag == "Player")
		{
			if(enemy == null)
				GetTarget();
		}
	}

	/*void OnTriggerExit()
	{
		if(enemy != null)
		{
			enemy = null;
			DeAgrro();
			Home();
		}
	}*/

	void GetTarget()
	{
		RaycastHit hit;
		Ray ray = new Ray(transform.position, transform.forward);
		int layerMask = 0 << 8;
		layerMask = ~layerMask;

		if (Physics.Raycast(ray, out hit, 50, layerMask))
		{
			if (hit.transform.gameObject.tag == "Player")
			{
				enemy = hit.transform.gameObject;
			}
		}
	}

	void MoveToTarget()
	{
		transform.LookAt(enemy.transform);
	}

	void DeAgrro()
	{

	}

	void Home()
	{

	}
}
