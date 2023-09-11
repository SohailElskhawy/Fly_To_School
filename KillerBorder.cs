using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerBorder : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            Destroy(collision.gameObject);

        }

        else if (collision.tag == "Health")
        {
            Destroy(collision.gameObject);

        }
        else if (collision.tag == "Magnet")
        {
            Destroy(collision.gameObject);

        }
        else if (collision.tag == "Boost")
        {
            Destroy(collision.gameObject);

        }
        else if (collision.tag == "Gun")
        {
            Destroy(collision.gameObject);

        }
        else if (collision.tag == "Sheild")
        {
            Destroy(collision.gameObject);

        }

        if(collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }

        if(collision.tag == "Bullit")
        {
            Destroy(collision.gameObject);
        }
    }
}
