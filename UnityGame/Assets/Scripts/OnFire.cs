using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnFire : MonoBehaviour
{


    void Start()
    {
        
    }

    void Update()
    {
		if (gameObject.tag == "Enemy")
		{
			Debug.Log("Killing: " + gameObject.name);
			PersistentManager.instance.SetSamMurder(true);
			Destroy(gameObject);
		}
    }
}
