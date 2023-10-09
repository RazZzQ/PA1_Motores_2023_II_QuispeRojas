using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int damage = 10; // Cantidad de da�o que inflige el enemigo al jugador

    private HealthBarController playerHealthBar; // Referencia a la barra de salud del jugador

    private static EnemyController instance; // Singleton de EnemyController

    private void Awake()
    {
        instance = this; // Configura el singleton
    }

    public static EnemyController GetInstance()
    {
        return instance; // Funci�n para acceder al singleton desde otros scripts
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag =="Bullet")
        {
            // Llama a la funci�n UpdateHealth en la barra de salud del jugador para hacerle da�o
            HealthBarController enemyHealthBar = HealthBarController.GetInstance();
            enemyHealthBar.UpdateHealth(-damage);
        }
    }
}
