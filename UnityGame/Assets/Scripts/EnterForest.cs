using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterForest : MonoBehaviour
{
    void OnTriggerEnter(Collider obj)
	{
		if (obj.tag == "Player")
			PersistentManager.instance.SetZone("Forest");
	}
}
