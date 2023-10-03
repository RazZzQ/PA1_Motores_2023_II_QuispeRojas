using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDispara : MonoBehaviour
{
    public GameObject proyectilPrefab;
    public Transform puntoDeDisparo;
    public float velocidadProyectil = 10f;
    public Transform jugador;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Disparar();
        }
    }

    void Disparar()
    {
        Vector2 direccionHaciaJugador = (jugador.position - transform.position).normalized;
        GameObject proyectil = Instantiate(proyectilPrefab, transform.position, transform.rotation);
        Rigidbody2D rb = proyectil.GetComponent<Rigidbody2D>();
        rb.velocity = direccionHaciaJugador * velocidadProyectil;

        Destroy(proyectil, 1.5f);
    }
}
