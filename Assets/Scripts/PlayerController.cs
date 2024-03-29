using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    [SerializeField] private Rigidbody2D myRBD2;
    [SerializeField] private float velocityModifier = 5f;
    [SerializeField] private float rayDistance = 10f;
    [SerializeField] private AnimatorController animatorController;
    [SerializeField] private SpriteRenderer spriteRenderer;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;
    private bool singleShotMode = true;
    private bool tripleshoot = true;
    private int jugadorNivel = 1; // Nivel inicial del jugador
    public Text nivelText;

    public AudioSource playeraudio;
    public AudioClip bulletClip;
    public AudioClip treebulletSound;
    private void Start()
    {
        ActualizarTextoNivel();
    }

    private void Update() {
        Vector2 movementPlayer = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        myRBD2.velocity = movementPlayer * velocityModifier;

        animatorController.SetVelocity(velocityCharacter: myRBD2.velocity.magnitude);

        Vector2 mouseInput = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 shootDirection = (mouseInput - (Vector2)firePoint.position).normalized;
        CheckFlip(mouseInput.x);
        Debug.DrawRay(firePoint.position, shootDirection * 10f, Color.red);

        if (Input.GetMouseButtonDown(0))
        {
            if (singleShotMode)
            {
                Shoot(shootDirection);
                playeraudio.PlayOneShot(bulletClip);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            singleShotMode = !singleShotMode;
        }
        if(Input.GetMouseButtonDown(1))
        {
            if (tripleshoot)
            {
                ShootTriple(shootDirection);
                playeraudio.PlayOneShot(treebulletSound);
            }
        }
        if (Input.GetMouseButtonUp(1))
        {
            tripleshoot = !tripleshoot;
        }
    }
    private void Shoot(Vector2 shootDirection)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.velocity = shootDirection * bulletSpeed;

        Destroy(bullet, 2.0f);
    }
    private void ShootTriple(Vector2 shootDirection)
    {
        for (int i = -1; i <= 1; i++)
        {
            Vector2 offsetDirection = shootDirection + new Vector2(i * 0.1f, 0); 
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.velocity = offsetDirection * bulletSpeed;

            Destroy(bullet, 2.0f);
        }
    }
    public void AumentarNivel(int nivelGanado)
    {
        if (jugadorNivel < 4)
        {
            jugadorNivel += nivelGanado;
            ActualizarTextoNivel(); 
        }
    }
    private void CheckFlip(float x_Position){
        spriteRenderer.flipX = (x_Position - transform.position.x) < 0;
    }
    private void ActualizarTextoNivel()
    {
        nivelText.text = "Nivel del jugador: " + jugadorNivel;
    }
    
}
