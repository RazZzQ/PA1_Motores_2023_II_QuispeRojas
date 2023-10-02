using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public static ScreenShake Instance;

    public Transform virtualCameraTransform;
    public Vector3 originalCameraPosition;
    private float shakeTimer;
    private float shakeIntensity;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        virtualCameraTransform = GetComponent<Transform>();
    }

    public void ShakeCamera(float intensity, float duration)
    {
        originalCameraPosition = virtualCameraTransform.localPosition;
        shakeIntensity = intensity;
        shakeTimer = duration;
    }

    private void Update()
    {
        if (shakeTimer > 0)
        {
            Vector3 shakeAmount = RandomVector3InUnitSphere() * shakeIntensity;
            shakeAmount.z = 0;

            virtualCameraTransform.localPosition = originalCameraPosition + shakeAmount;

            shakeTimer -= Time.deltaTime;
        }
        else
        {
            virtualCameraTransform.localPosition = originalCameraPosition;
        }
    }
    private Vector3 RandomVector3InUnitSphere()
    {
        float randomX = Random.Range(-1f, 1f);
        float randomY = Random.Range(-1f, 1f);
        float randomZ = Random.Range(-1f, 1f);

        return new Vector3(randomX, randomY, randomZ).normalized;
    }
}
