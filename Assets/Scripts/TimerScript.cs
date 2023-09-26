using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public Text timerText;
    public float tiempoInicial = 10.0f;
    private float tiempoRestante;

    void Start()
    {
        tiempoRestante = tiempoInicial;
    }

    void Update()
    {
        if (tiempoRestante > 0)
        {
            tiempoRestante -= Time.deltaTime;
            MostrarTiempo();
        }
        else
        {
            Ganaste();
        }
    }

    void MostrarTiempo()
    {
        int minutos = (int)(tiempoRestante / 60);
        int segundos = (int)(tiempoRestante % 60);

        timerText.text = "Tiempo: " + minutos.ToString() + ":" + segundos.ToString("00");
    }

    void Ganaste()
    {
        timerText.text = "Ganaste";
    }
}

