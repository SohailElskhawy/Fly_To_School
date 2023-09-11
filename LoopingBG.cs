using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingBG : MonoBehaviour
{

    public static float  backgroundSpeed;
    public Renderer backgroundRenderer;


    // Start is called before the first frame update
     void Start()
    {
        backgroundSpeed = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        backgroundRenderer.material.mainTextureOffset += new Vector2(0f, backgroundSpeed * Time.deltaTime);

    }
}
