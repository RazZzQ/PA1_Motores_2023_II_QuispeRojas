using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class HealthBarController : MonoBehaviour
{
    public int maxValue = 100;
    public int currentValue = 100;
    public Text lifetext;

    private static HealthBarController instance;

    // Singleton
    public static HealthBarController Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            // Si ya existe una instancia, destruye esta para asegurarte de que solo haya una.
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void UpdateHealth(int amount)
    {
        currentValue = Mathf.Clamp(currentValue + amount, 0, maxValue);

        if (currentValue <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Ejemplo: Si el objeto con este script es el jugador, destruirlo
        if (gameObject.gameObject.tag=="Player")
        {
            Destroy(gameObject);
            if (lifetext != null)
            {
                lifetext.text = "Game Over";
            }
        }
        else if (gameObject.gameObject.tag == "EnemyBullet")
        {
            Destroy(gameObject);
        }
    }
}