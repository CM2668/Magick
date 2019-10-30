using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class WolfBrain : MonoBehaviour
{
	public NavMeshAgent moveSam;
	GameObject enemy;
	RaycastHit hit;
	Ray ray;
	int layerMask;
	Vector3 home;

	void Start()
	{
		ray = new Ray(transform.position, transform.forward);
		layerMask = 0 << 8;
		layerMask = ~layerMask;
		moveSam = gameObject.GetComponent<NavMeshAgent>();
		home = transform.position;
		moveSam.ResetPath();
	}

	void Update()
	{
		if (enemy != null)
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
		if (obj.tag == "Player")
		{
			if (enemy == null)
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
		Debug.DrawRay(ray.origin, ray.direction, Color.red, 30f);
	}

	void MoveToTarget()
	{
		transform.LookAt(enemy.transform);
		moveSam.SetDestination(enemy.transform.position);
		Debug.Log(Vector3.Distance(gameObject.transform.position, enemy.transform.position));
		if (Vector3.Distance(gameObject.transform.position, enemy.transform.position) <= 1.5f)
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
		if (enemy.tag == "Player")
		{
			PersistentManager.instance.resetWorld();
		}
	}
}
