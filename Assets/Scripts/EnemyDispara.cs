using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDispara : MonoBehaviour
{
    public GameObject proyectilPrefab;
    public Transform puntoDeDisparo;
    public float velocidadProyectil = 10f;
    public Transform jugador;
    public int nivelesOtorgados = 2;

    private bool isShooting = false;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && !isShooting)
        {
            StartCoroutine(ShootCoroutine());
        }
    }

    IEnumerator ShootCoroutine()
    {
        isShooting = true;
        while (true)
        {
            Vector2 direccionHaciaJugador = (jugador.position - transform.position).normalized;
            GameObject proyectil = Instantiate(proyectilPrefab, puntoDeDisparo.position, transform.rotation);
            Rigidbody2D rb = proyectil.GetComponent<Rigidbody2D>();
            rb.velocity = direccionHaciaJugador * velocidadProyectil;

            Destroy(proyectil, 1.5f);

            // Espera un tiempo antes de disparar de nuevo
            yield return new WaitForSeconds(2.0f);
        }
    }
}
