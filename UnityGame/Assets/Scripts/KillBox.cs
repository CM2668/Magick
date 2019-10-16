using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class KillBox : MonoBehaviour
{
	public GameObject player;
	public Vector3 startPos;
	public Quaternion startRot;

	void Update()
	{
		if (player == null)
		{
			player = GameObject.FindGameObjectWithTag("Player");
			if (player != null)
			{
				startPos = player.transform.position;
				startRot = player.transform.rotation;
			}
		}
	}

	void OnTriggerEnter(Collider obj)
	{
		
		if(obj.tag == "Player")
		{
			player.transform.rotation = startRot;
			player.transform.position = startPos;
		}
	}
}
