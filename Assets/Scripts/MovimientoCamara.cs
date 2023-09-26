using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCamara : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform jugador;
    public Vector3 posicionInicial = new Vector3(-10, 0, -10);

    void Start()
    {
        // Establecer la posición inicial de la cámara
        transform.position = new Vector3(posicionInicial.x, transform.position.y, transform.position.z);
    }

    void Update()
    {
        if (jugador != null)
        {
            // Obtener la posición actual de la cámara
            Vector3 nuevaPosicion = transform.position;
            // Actualizar solo la coordenada X con la posición del jugador
            nuevaPosicion.x = jugador.position.x;
            // Establecer la nueva posición de la cámara
            transform.position = nuevaPosicion;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Player")
        {
            Camera.main.orthographic = true;

            Camera.main.fieldOfView = 10f;
        }
    }
}

