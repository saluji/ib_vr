using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum VoiceLine
{
    VoiceLine1,
    VoiceLine2,
    VoiceLine3,
    VoiceLine4,
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }
    LevelManager levelManager;

    [Header("Audio Source")]
    [SerializeField] AudioSource ambienceSource;
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sFXSource;
    [SerializeField] AudioSource voiceSource;

    [Header("Background music")]
    public AudioClip music;
    public AudioClip ambience;

    [Header("Sound effects")]
    public AudioClip basketball;
    public AudioClip button;
    public AudioClip can;
    public AudioClip dart;
    public AudioClip done;
    public AudioClip sliderClick;
    public AudioClip spaceshipIdle;
    public AudioClip teleporter;
    public AudioClip tennisball;

    [Header("Voice lines")]
    public AudioClip space00;
    public AudioClip space01;
    public AudioClip space02;
    public AudioClip space03;

    public AudioClip jupiter00;

    public AudioClip moon00;

    public AudioClip earth00;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        
        musicSource.clip = music;
        ambienceSource.clip = ambience;
        musicSource.Play();
        ambienceSource.Play();

        // Ensure the voice source is ready before playing the clip
        if (voiceSource != null)
        {
            BeginningVoiceLine();
        }
        else
        {
            Debug.LogError("VoiceSource is not assigned!");
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        sFXSource.PlayOneShot(clip);
    }

    public void PlayVoice(AudioClip clip)
    {
        voiceSource.PlayOneShot(clip);
    }

    public void BeginningVoiceLine()
    {
        VoiceLine voiceLineToPlay = GetActiveVoiceLine();
        AudioClip clipToPlay = null;

        switch (voiceLineToPlay)
        {
            case VoiceLine.VoiceLine1:
                clipToPlay = space00;
                break;
            case VoiceLine.VoiceLine2:
                clipToPlay = space01;
                break;
            case VoiceLine.VoiceLine3:
                clipToPlay = space02;
                break;
            case VoiceLine.VoiceLine4:
                clipToPlay = space03;
                break;
            default:
                Debug.LogError("Unhandled voice line case!");
                break;
        }

        if (clipToPlay != null)
        {
            voiceSource.clip = clipToPlay;
            voiceSource.Play();
        }
        else
        {
            Debug.LogError("No clip assigned for the selected voice line!");
        }
    }

    VoiceLine GetActiveVoiceLine()
    {
        if (GameManager.instance.IsGameDone)
            return VoiceLine.VoiceLine4;
        else if (GameManager.instance.IsEarthVisitable)
            return VoiceLine.VoiceLine3;
        else if (GameManager.instance.IsMoonVisitable)
            return VoiceLine.VoiceLine2;
        else
            return VoiceLine.VoiceLine1;
    }
}
