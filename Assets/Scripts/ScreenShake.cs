using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public static ScreenShake instance { get; private set; }

    private CinemachineVirtualCamera virtualCamera;
    private float shaketimer;

    private void Awake()
    {
        instance = this;
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }
    public void shakecamera(float intensidad, float time)
    {
        CinemachineBasicMultiChannelPerlin perlin = virtualCamera.GetCinemachineComponent
            <CinemachineBasicMultiChannelPerlin>();

        perlin.m_AmplitudeGain = intensidad;
        shaketimer = time;
    }
    private void Update()
    {
        if(shaketimer > 0)
        {
            shaketimer -= Time.deltaTime;
            if(shaketimer <= 0f)
            {
                CinemachineBasicMultiChannelPerlin perlin = virtualCamera.GetCinemachineComponent
                    <CinemachineBasicMultiChannelPerlin>();

                perlin.m_AmplitudeGain = 0f;
            }
        }
    }
}
