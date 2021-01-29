using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SavedSettings : MonoBehaviour
{
    public float value;
    public AudioMixer mixer;

    void Start()
    {
        value = PlayerPrefs.GetFloat("volume");
        mixer.SetFloat("volume", value);
    }

}
