using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Camera.main.GetComponent<CameraShake>().PlayCameraShakeAnimation(.15f, .2f));
    }

    
}
