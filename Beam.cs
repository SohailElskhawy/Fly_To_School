using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Beam : MonoBehaviour
{
    public Transform firePoint;
    public GameObject Bullit;

   

    private void Start()
    {
        StartCoroutine(Shootbeam());

        

    }


    private void Update()
    {
        
    }


    public void Shoot()
    {
        Instantiate(Bullit.transform, firePoint.position, firePoint.rotation);
    }

    public IEnumerator Shootbeam()
    {

        while (true)
        {
            yield return new WaitForSeconds(1.5f);
            Shoot();
            





        }

    }
}
