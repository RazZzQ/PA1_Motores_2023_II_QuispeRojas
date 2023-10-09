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
        if (collision.CompareTag("EnemyBullet"))
        {
            // Obtener el componente EnemyDispara del enemigo que disparó la bala
            EnemyDispara enemyDispara = collision.GetComponentInParent<EnemyDispara>();
            PatrolMovementController patrolMovement = collision.GetComponentInParent<PatrolMovementController>();

            if (enemyDispara != null)
            {
                PlayerController player = PlayerController.instance;
                // Obtener el valor de niveles otorgados por el enemigo que disparó la bala
                int nivelesOtorgados = enemyDispara.nivelesOtorgados;

                // Aumentar el nivel del jugador con el valor del enemigo
                player.AumentarNivel(nivelesOtorgados);
            }
            else if (patrolMovement != null)
            {
                // Obtener el valor de niveles otorgados por el enemigo que disparó la bala
                int nivelesOtorgados = patrolMovement.nivelesOtorgados;
                PlayerController player = PlayerController.instance;
                // Aumentar el nivel del jugador con el valor del enemigo
                player.AumentarNivel(nivelesOtorgados);
            }

            // Destruir la bala
            Destroy(collision.gameObject);
        }
    }
}
