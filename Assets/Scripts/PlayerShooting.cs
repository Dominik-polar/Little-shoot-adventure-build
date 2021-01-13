using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;
    private bool isShooting = false;
    public float attackDelay = 1.5f;
    private bool isAttackPressed;


    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            isAttackPressed= true;
        }
    }

    void FixedUpdate()
    {
        if (isAttackPressed)
        {
            isAttackPressed = false;

            if (isShooting == false)
            {
                isShooting = true;
                Instantiate(bullet, firePoint.position, firePoint.rotation);
                Invoke("AttackComplete", attackDelay);
            }
        }
    }
    void AttackComplete()
    {
        isShooting = false;
    }
}
