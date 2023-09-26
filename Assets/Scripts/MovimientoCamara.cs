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
        // Establecer la posici�n inicial de la c�mara
        transform.position = new Vector3(posicionInicial.x, transform.position.y, transform.position.z);
    }

    void Update()
    {
        if (jugador != null)
        {
            // Obtener la posici�n actual de la c�mara
            Vector3 nuevaPosicion = transform.position;
            // Actualizar solo la coordenada X con la posici�n del jugador
            nuevaPosicion.x = jugador.position.x;
            // Establecer la nueva posici�n de la c�mara
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

