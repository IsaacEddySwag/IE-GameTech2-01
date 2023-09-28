using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource audioSource;

    public AudioClip buttonSound;
    public AudioClip doorSound;
    public AudioClip BatterySound;

    public void playButton()
    {
        audioSource.Stop();
        audioSource.clip = buttonSound;
        audioSource.Play();
    }

    public void playDoor()
    {
        audioSource.Stop();
        audioSource.clip = doorSound;
        audioSource.Play();
    }
    public void playBattery()
    {
        audioSource.Stop();
        audioSource.clip = BatterySound;
        audioSource.Play();
    }

}
