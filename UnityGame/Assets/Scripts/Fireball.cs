using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    float lifeTimer = 10;
    float explosionTimer = 3;
    bool collide = false;
    void Start()
    {
        
    }

    void Update()
    {
        if (collide == false)
        {
            GetComponent<Rigidbody>().velocity = transform.forward * 1000f * Time.deltaTime;
        }
        else
        {
            explosionTimer -= Time.deltaTime;
            if (explosionTimer <= 0)
            {
                Object.Destroy(gameObject);
            }
        }
        lifeTimer -= Time.deltaTime;  

        if(lifeTimer <= 0f && collide == false)
        {
            Object.Destroy(gameObject);
        }
    }

	void OnTriggerEnter()
	{
        if(lifeTimer <= 9.9)
            {
            collide = true;
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            transform.localScale += new Vector3(1f, 1f, 1f);
        }
        
    }
}
