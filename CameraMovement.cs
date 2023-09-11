using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public static float cameraSpeed;


     void Start()
    {
        cameraSpeed = 5f;
    }





    void Update()
    {
        transform.position += new Vector3(0, cameraSpeed * Time.deltaTime, 0);

        
    }
}
