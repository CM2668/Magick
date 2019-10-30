using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SamBrain : MonoBehaviour
{
	public NavMeshAgent moveSam;
	GameObject enemy;
    GameObject tmp = null;
	RaycastHit hit;
	Ray ray;
	int layerMask;
	Vector3 home;

	void Start()
    {
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
		if(obj.tag == "Player")
		{
            if (enemy == null)
            {
                ray = new Ray(transform.position, transform.forward);
                Debug.DrawRay(ray.origin, ray.direction, Color.red, 5000f);
                GetTarget();
            }
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
		moveSam.SetDestination(enemy.transform.position);
		Debug.Log(Vector3.Distance(gameObject.transform.position, enemy.transform.position));
		if (Vector3.Distance(gameObject.transform.position, enemy.transform.position) <= 1.5f)
			Shank();
	}

	void DeAggro()
	{
		enemy = tmp;
        enemy = null;
		Home();
	}

	void Home()
	{
<<<<<<< HEAD
        if (gameObject.transform.position != home)
        {
            moveSam.SetDestination(home);
        }
       
=======
		if (gameObject.transform.position != home)
			moveSam.SetDestination(home);
		else if (gameObject.transform.position == home)
			transform.LookAt(home + new Vector3(1f, 0f, -1f));
<<<<<<< HEAD
>>>>>>> parent of 2389469... Mountain Shit BABYYYYY
=======
>>>>>>> parent of 2389469... Mountain Shit BABYYYYY
	}

	void Shank()
	{
		if(enemy.tag == "Player")
		{
			//PersistentManager.instance.resetWorld();
		}
	}
}
