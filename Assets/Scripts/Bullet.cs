using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            HealthBarController EnemyHealt = HealthBarController.instance;
            EnemyHealt.UpdateHealth(-damage);
            Destroy(gameObject);
        }
    }
}
