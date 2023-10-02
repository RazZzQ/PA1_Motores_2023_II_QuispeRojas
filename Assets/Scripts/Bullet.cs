using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 10f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Aplicar velocidad inicial a la bala en la direcci�n en que se dispar�
        rb.velocity = transform.right * bulletSpeed;
    }
}
