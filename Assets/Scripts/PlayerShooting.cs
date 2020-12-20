using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;
    private bool isShooting = false;


    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            isShooting = true;
        }

        if (isShooting == true)
        {
            Instantiate(bullet,firePoint.position, firePoint.rotation);
            isShooting = false;
        }
    }
}
