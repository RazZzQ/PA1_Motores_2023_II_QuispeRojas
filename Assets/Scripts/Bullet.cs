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
        // Aplicar velocidad inicial a la bala en la dirección en que se disparó
        rb.velocity = transform.right * bulletSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="EnemyBullet")
        {
            EnemyDispara enemyDispara = collision.GetComponent<EnemyDispara>();
            PatrolMovementController patrolMovement = collision.GetComponent<PatrolMovementController>();

            if (enemyDispara != null)
            {
                PlayerController player = PlayerController.instance;
                int nivelesOtorgados = enemyDispara.nivelesOtorgados;

                player.AumentarNivel(nivelesOtorgados);
            }
            else if (patrolMovement != null)
            {
                int nivelesOtorgados = patrolMovement.nivelesOtorgados;
                PlayerController player = PlayerController.instance;
                player.AumentarNivel(nivelesOtorgados);
            }

            // Destruir la bala
            Destroy(collision.gameObject);
        }
    }
}
