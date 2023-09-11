using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public float timeDeath;
    private void Update()
    {
        Destroy(gameObject, timeDeath);
    }
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Border")
        {
            Destroy(this.gameObject);
        }


        
    }
}
