using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SamBrain : MonoBehaviour
{
	public NavMeshAgent Sam;
	GameObject enemy;
	RaycastHit hit;
	Ray ray;
	int layerMask;

	void Start()
    {
		ray = new Ray(transform.position, transform.forward);
		layerMask = 0 << 8;
		layerMask = ~layerMask;
		Sam = gameObject.GetComponent<NavMeshAgent>();
	}

    void Update()
    {
		if(enemy != null)
		{
			//Debug.Log("I SEE YOU");
		}
    }

	void FixedUpdate()
	{
		if(enemy != null)
			MoveToTarget();
		if (PersistentManager.instance.GetZone() != "Forest")
			DeAggro();
	}

	void OnTriggerStay(Collider obj)
	{
		if(obj.tag == "Player")
		{
			if(enemy == null)
				GetTarget();
		}
	}

	void GetTarget()
	{
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
		Sam.SetDestination(enemy.transform.position);
		GetTarget();
		Debug.Log(hit.distance);
		if (hit.distance <= 1)
			Shank();
	}

	void DeAggro()
	{
		enemy = null;
		Home();
	}

	void Home()
	{
		Sam.SetDestination(new Vector3(-56f, 11f, 46.6f));
	}

	void Shank()
	{
		if(enemy.tag == "Player")
		{
			PersistentManager.instance.resetWorld();
		}
	}
}
