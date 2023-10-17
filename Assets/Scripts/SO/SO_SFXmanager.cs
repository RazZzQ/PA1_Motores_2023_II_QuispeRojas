using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SO_SFXmanager : MonoBehaviour
{
    public AudioMixer Mixer;
    public AudioMixerGroup group;
    public string AudioParameter;
    public void getvolume(ref float volume)
    {
        Mixer.GetFloat(AudioParameter, out volume);
    }
    public void UpdateVolumen(float newvolume)
    {
        newvolume = Mathf.Log10(newvolume) * 20f;
        Mixer.SetFloat(AudioParameter, newvolume);
    }
}
