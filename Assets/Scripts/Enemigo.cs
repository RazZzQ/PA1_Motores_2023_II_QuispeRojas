using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public Transform jugador;
    public float velocidad;
    private Vector2 posicionInicial;
    private bool jugadorEnArea;
    private bool enMovimiento;
    private Vector2 destino;
    private Rigidbody2D rb2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        posicionInicial = transform.position;
        destino = posicionInicial;
        enMovimiento = false;
    }

    void Update()
    {
        if (jugadorEnArea)
        {
            Vector2 direccion = (jugador.position - transform.position).normalized;

            rb2d.velocity = direccion * velocidad;
        }
        else if(enMovimiento)
        {
            Vector2 direccion = (destino - (Vector2)transform.position).normalized;
            rb2d.velocity = direccion * velocidad;
            float distancia = Vector2.Distance(transform.position, destino);
            if (distancia < 0.1f)
            {
                enMovimiento = false;
                rb2d.velocity = Vector2.zero; 
            }
        }
        else
        {
            rb2d.velocity = Vector2.zero;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorEnArea = true;
            enMovimiento = false;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorEnArea = false;
            enMovimiento = true;
            destino = posicionInicial;
        }
    }
}
