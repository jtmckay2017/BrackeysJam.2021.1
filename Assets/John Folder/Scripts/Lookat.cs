using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lookat : MonoBehaviour
{
    public Camera targetCamera;


    // Update is called once per frame
    void Update()
    {
        transform.LookAt(transform.position + targetCamera.transform.rotation * Vector3.left,
        targetCamera.transform.rotation * Vector3.up);
    }
}
