using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    Rigidbody2D body;
    public GameObject prefabBala;
    public Transform mira;
    private int velocidadbala = 5;
    private int direccion = 1, direccionY = 1;
    // Start is called before the first frame update
    void Awake()
    {

        body = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        body.velocity = new Vector2 (mira.transform.position.x * direccion*velocidadbala, mira.transform.position.y*direccionY*velocidadbala);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            crearbala();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            crearbala();
        }
    }
    private void crearbala()
    {

        Instantiate(prefabBala, mira.transform.position, mira.transform.rotation);
    }
}
