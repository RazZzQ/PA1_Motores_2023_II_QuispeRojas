using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using System;

public class HealthBarController : MonoBehaviour
{
    [SerializeField] private int maxValue;
    [Header("Health Bar Visual Components")]
    [SerializeField] private RectTransform healthBar;
    [SerializeField] private RectTransform modifiedBar;
    [SerializeField] private float changeSpeed;
    public Text lifetext;
    private int currentValue { get; set; }
    private float _fullWidth;
    private float TargetWidth => (float)currentValue * _fullWidth / maxValue;
    private Coroutine updateHealthBarCoroutine;
    public static HealthBarController instance;
    public AudioSource playeraudio;
    public AudioClip Playerhurt;
    public AudioClip lowlife;
    public event Action onhit;
    // Singleton
    private void Start()
    {
        currentValue = maxValue;
        _fullWidth = healthBar.rect.width;
        instance = this; // Configura el singleton
    }
    public static HealthBarController GetInstance()
    {
        return instance;
    }
    /// <summary>
    /// M�todo <c>UpdateHealth</c> actualiza la vida del personaje de manera visual. Recibe una cantidad de vida modificada.
    /// </summary>
    /// <param name="amount">El valor de vida modificada. Puede ser positivo o negativo.</param>
    public void UpdateHealth(int amount)
    {
        currentValue = Mathf.Clamp(currentValue + amount, 0, maxValue);

        if (updateHealthBarCoroutine != null)
        {
            StopCoroutine(updateHealthBarCoroutine);
        }
        updateHealthBarCoroutine = StartCoroutine(AdjustWidthBar(amount));
        ScreenShake.instance.shakecamera(5f, 1f);
        playeraudio.PlayOneShot(Playerhurt);
        if (currentValue < 40)
        {
            playeraudio.PlayOneShot(lowlife);
        }
        if (currentValue <= 0)
        {
            Die();
        }
    }
    IEnumerator AdjustWidthBar(int amount)
    {
        RectTransform targetBar = amount >= 0 ? modifiedBar : healthBar;
        RectTransform animatedBar = amount >= 0 ? healthBar : modifiedBar;

        targetBar.sizeDelta = SetWidth(targetBar, TargetWidth);

        while (Mathf.Abs(targetBar.rect.width - animatedBar.rect.width) > 1f)
        {
            animatedBar.sizeDelta = SetWidth(animatedBar, Mathf.Lerp(animatedBar.rect.width, TargetWidth, Time.deltaTime * changeSpeed));
            yield return null;
        }

        animatedBar.sizeDelta = SetWidth(animatedBar, TargetWidth);
    }

    private Vector2 SetWidth(RectTransform t, float width)
    {
        return new Vector2(width, t.rect.height);
    }
    private void Die()
{
    // Si el objeto con este script es el jugador, destruirlo
    if (gameObject.gameObject.tag == "Player")
        // Ejemplo: Si el objeto con este script es el jugador, destruirlo
        if (gameObject.gameObject.tag == "Player")
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