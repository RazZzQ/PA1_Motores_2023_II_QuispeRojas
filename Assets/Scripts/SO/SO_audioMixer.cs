using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "SO_mixerChannel", menuName = "scriptableObjects/Audio/SO_mixerchannel", order = 0)]
public class SO_audioMixer : ScriptableObject
{
    public AudioMixer Mixer;
    public AudioMixerGroup group;
    public string AudioParameter;
    public void mutechannel()
    {
        Mixer.SetFloat(AudioParameter, -80f);
    }
    public void unmutechannel()
    {
        Mixer.SetFloat(AudioParameter, 0f);
    }
    public void getvolume(ref float volume)
    {
        Mixer.GetFloat (AudioParameter, out volume); 
    }
    public void UpdateVolumen(float newvolume)
    {
        newvolume = Mathf.Log10(newvolume) * 20f;
        Mixer.SetFloat(AudioParameter, newvolume);
    }
}
