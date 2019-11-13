using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreaseBall : MonoBehaviour
{
    public GameObject greasepool;
    float lifeTimer = 10;
    float explosionTimer = 3;
    bool collide = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    void Update()
    {
        if (collide == false)
        {
            //GetComponent<Rigidbody>().velocity = transform.forward * 800f * Time.deltaTime;
        }

        lifeTimer -= Time.deltaTime;

        if (lifeTimer <= 0f && collide == false)
        {
            Object.Destroy(gameObject);
        }
    }
    void OnTriggerEnter()
	{
        if (lifeTimer <= 9.7)
        {
            collide = true;
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            Instantiate(greasepool, new Vector3(this.transform.position.x, this.transform.position.y + .1f, this.transform.position.z), new Quaternion(9, 0, 0, 0));
            Object.Destroy(gameObject);
        }
    }
}
