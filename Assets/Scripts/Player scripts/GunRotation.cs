﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotation : MonoBehaviour
{

    private void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotation = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation);

    }



}
