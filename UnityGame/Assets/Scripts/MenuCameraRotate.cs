using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCameraRotate : MonoBehaviour
{

    public float rotSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotSpeed, 0, Space.Self);

    }
}
