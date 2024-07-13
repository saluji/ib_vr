using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }

    [Header("Audio Source")]
    [SerializeField] AudioSource ambienceSource;
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sFXSource;
    [SerializeField] AudioSource voiceSource;

    [Header("Background Clip")]
    public AudioClip music;
    public AudioClip ambience;

    [Header("SFX Clip")]
    public AudioClip basketball;
    public AudioClip button;
    public AudioClip can;
    public AudioClip dart;
    public AudioClip done;
    public AudioClip spaceshipIdle;
    public AudioClip sliderClick;
    public AudioClip teleporter;
    public AudioClip tennisball;

    [Header("Voice Clip")]
    public AudioClip space00;

    void Awake()
    {
        musicSource.clip = music;
        ambienceSource.clip = ambience;
        musicSource.Play();
        ambienceSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        sFXSource.PlayOneShot(clip);
    }

    public void PlayVoice(AudioClip clip)
    {
        voiceSource.PlayOneShot(clip);
    }
}
