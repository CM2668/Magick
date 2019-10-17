using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterForest : MonoBehaviour
{
    void OnTriggerEnter(Collider obj)
	{
		if (obj.tag == "Player")
		{
			Debug.Log("Entered Forest");
			PersistentManager.instance.SetZone("Forest");
		}
	}
}
