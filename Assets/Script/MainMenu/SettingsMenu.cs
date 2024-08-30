using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

  public void UpdateVolume(float volume)
    {
        audioMixer.SetFloat("Volume",  volume);
    }
}
