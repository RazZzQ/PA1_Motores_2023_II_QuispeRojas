using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXmanager : MonoBehaviour
{
    public static SFXmanager instance { get; private set; }
    // Start is called before the first frame update
    public SO_audioMixer SFX;
    [Range(0.0001f, 1f)] public float newvolume;
    public float Volumen;
    private void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    private void Update()
    {
        SFX.UpdateVolumen(newvolume);
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SFX.unmutechannel();
        }
        SFX.getvolume(ref Volumen);
    }
}
