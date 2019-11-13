using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levitate : MonoBehaviour
{
	public Vector3 startPos;
	public bool floating = false;
	public float i = 0f;

	void Start()
    {
		startPos = transform.position;
	}

    void Update()
    {
		if(!floating)
		{
			if(transform.position.y < startPos.y + 2.5f)
			{
				gameObject.GetComponent<Rigidbody>().velocity = Vector3.up * 2;
			}
			else if(transform.position.y >= startPos.y + 2.5f)
			{
				gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
				floating = true;
			}
		}
		else if(floating)
		{
			gameObject.GetComponent<Rigidbody>().velocity = (Vector3.up * Mathf.Sin(i)) / 2;
			i++;
			if (i == 360)
				i = 0;
		}
    }
}
