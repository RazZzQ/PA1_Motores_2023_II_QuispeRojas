using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerActions : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public float velocityNor = 3;
    public float raydistance = 10;
    public AnimatorController Acontroller;
    public SpriteRenderer SP;
    public Bullet Bulletprefab;
    public float bulletSpeed = 10;
    private Vector2 _distance;

    public void PlayerMovement(InputAction.CallbackContext context)
    {
        Vector2 movement = context.ReadValue<Vector2>();
        rb2D.velocity = movement * velocityNor;

        Acontroller.SetVelocity(velocityCharacter: rb2D.velocity.magnitude);
    }
    public void Fire(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            _distance = (mousePosition - (Vector2)transform.position).normalized;

            Bullet mybullet = Instantiate(Bulletprefab, transform.position, Quaternion.identity);
            Rigidbody2D bulletRb = mybullet.GetComponent<Rigidbody2D>();
            bulletRb.velocity = _distance * bulletSpeed;

            Destroy(mybullet, 2.0f);
        }
    }
    public void aim(InputAction.CallbackContext context)
    {
        Vector2 cursorPosition = context.ReadValue<Vector2>();
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(cursorPosition);

        CheckFlip(worldPosition.x);

        _distance = worldPosition - (Vector2)transform.position;
    }
    private void CheckFlip(float X)
    {
        SP.flipX = (X - transform.position.x) < 0;
    }
}
