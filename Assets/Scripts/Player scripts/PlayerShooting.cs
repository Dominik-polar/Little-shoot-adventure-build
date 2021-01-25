using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform firePoint;
    public Transform firePoint2;
    public GameObject bullet;
    private bool isShooting = false;
    public float attackDelay = 1.5f;
    private bool isAttackPressed;
    public bool firesecondbullet = false;


    void Update()
    {
        if (Input.GetButton("Fire1"))
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
                if(firesecondbullet == true)
                {
                    Instantiate(bullet, firePoint2.position, firePoint2.rotation);
                }
            }
        }
    }
    void AttackComplete()
    {
        isShooting = false;
    }
}
