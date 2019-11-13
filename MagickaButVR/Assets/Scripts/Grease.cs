using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grease : MonoBehaviour
{

	float lifeTimer = 10;
	float explosionTimer = 3;

    GameObject player;

    private void Start()
    {
        player = GameObject.Find("OVRPlayerController");
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
			player.GetComponent<OVRPlayerController>().Acceleration = .08f;
		}
	}

	void OnTriggerStay(Collider obj)
	{
        if (obj.tag == "Player")
		{
            
            player.GetComponent<OVRPlayerController>().Acceleration = .01f;
		}
	}

    private void OnTriggerEnter(Collider obj)
    {
        if (obj.tag == "Player")
        {
            player.GetComponent<OVRPlayerController>().Acceleration=.01f;
        }
    }

    private void OnDestroy()
    {
        player.GetComponent<OVRPlayerController>().Acceleration = .08f;
    }
}
