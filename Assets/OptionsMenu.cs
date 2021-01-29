using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer mixer;



    public void Volume (float volume)
    {
        mixer.SetFloat("volume", Mathf.Log10(volume) *20);
        PlayerPrefs.SetFloat("volume", Mathf.Log10(volume) * 20);
    }
}
