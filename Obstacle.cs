using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour
{
    
    public GameObject explotion;

    

    
    


    // Start is called before the first frame update
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Border")
        {
            Destroy(this.gameObject);
        }
        else if (collision.tag == "Player")
        {

            Destroy(this.gameObject);
            Instantiate(explotion.transform, transform.position, Quaternion.identity);
            
             


        }

         
        if (collision.CompareTag("Health"))
        {
            Destroy(collision.gameObject);

        }
         
        if (collision.CompareTag("Magnet"))
        {
            Destroy(collision.gameObject);

        }
         
        if (collision.CompareTag("Boost"))
        {
            Destroy(collision.gameObject);

        }
         
        if (collision.CompareTag("Gun"))
        {
            Destroy(collision.gameObject);

        }
        
        if (collision.CompareTag("Sheild"))
        {
            Destroy(collision.gameObject);

        }


        if(collision.tag == "DeathArea")
        {
            Destroy(this.gameObject);
            Instantiate(explotion.transform, transform.position, Quaternion.identity);
        }
    }

    private void Update()
    {
        Destroy(this.gameObject, 7f);
    }

}
