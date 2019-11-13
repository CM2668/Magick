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

	void OnTriggerStay(Collider obj)
	{
		if(obj.tag == "Player")
		{
			getTarget();
		}
	}

	void getTarget()
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
		else
			Debug.Log("Already have a target");

		//Debug code
		//Debug.DrawRay(ray.origin, ray.direction, Color.red, 5f);
		if (enemy != null && enemy.GetComponent<Rigidbody>() != null)
			Debug.Log("Target: " + enemy.name);
		else if (enemy != null)
			Debug.Log(enemy.name + " cannot be targeted");
		else
			Debug.Log("No Target | " + ray.GetPoint(10f) + " | " + transform.position);
	}
}
