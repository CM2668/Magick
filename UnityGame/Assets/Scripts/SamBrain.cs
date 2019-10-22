using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SamBrain : MonoBehaviour
{
	public NavMeshAgent moveSam;
	GameObject enemy;
	RaycastHit hit;
	Ray ray;
	int layerMask;
	Vector3 home;

	void Start()
    {
		ray = new Ray(transform.position + transform.forward, transform.forward);
		layerMask = 0 << 8;
		layerMask = ~layerMask;
		moveSam = gameObject.GetComponent<NavMeshAgent>();
		home = transform.position;
		moveSam.ResetPath();
	}

    void Update()
    {
		if(enemy != null)
		{
			Debug.Log("I SEE YOU");
		}
		if (moveSam.hasPath)
		{
			Debug.Log("MOVING");
		}
    }

	void FixedUpdate()
	{
		if (enemy != null)
		{
			MoveToTarget();
			if (PersistentManager.instance.GetZone() != "Forest")
				DeAggro();
		}
	}

	void OnTriggerStay(Collider obj)
	{
		if(obj.tag == "Player")
		{
			if(enemy == null)
				GetTarget(obj.transform);
		}
	}

	void GetTarget(Transform t)
	{
		if (Physics.Raycast(transform.position + transform.forward, t.position, out hit, 50, layerMask))
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
		moveSam.SetDestination(enemy.transform.position);
		GetTarget(enemy.transform);
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
		if (gameObject.transform.position != home)
			moveSam.SetDestination(home);
		else if (gameObject.transform.position == home)
			transform.LookAt(home + new Vector3(1f, 0f, -1f));
	}

	void Shank()
	{
		if(enemy.tag == "Player")
		{
			PersistentManager.instance.resetWorld();
		}
	}
}
