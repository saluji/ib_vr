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
    int voiceIndex;

    [Header("Audio Source")]
    [SerializeField] AudioSource ambienceSource;
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sFXSource;
    [SerializeField] AudioSource uISource;
    [SerializeField] public AudioSource voiceSource;

    [Header("Music")]
    public AudioClip musicSpace;
    public AudioClip musicJupiter;
    public AudioClip musicMoon;
    public AudioClip musicEarth;
    public AudioClip musicHome;
    public AudioClip[] music;
    public AudioClip[] ambience;

    [Header("Ambience")]
    public AudioClip ambienceSpace;
    public AudioClip ambienceJupiter;
    public AudioClip ambienceMoon;
    public AudioClip ambienceEarth;

    [Header("UI Sound")]
    public AudioClip done01;
    public AudioClip done02;
    public AudioClip fail;
    public AudioClip sliderClick;
    public AudioClip uIClick;

    [Header("Sound effects")]
    public AudioClip basketball;
    public AudioClip buttonPlate;
    public AudioClip can;
    public AudioClip dart;
    public AudioClip teleporter;
    public AudioClip tennisball;

    [Header("Space voice lines")]
    public AudioClip space00;
    public AudioClip space01;
    public AudioClip space02;
    public AudioClip space03;
    public AudioClip space04;
    public AudioClip space05;
    public AudioClip space06;
    public AudioClip space07;
    public AudioClip space08;
    public AudioClip space09;
    public AudioClip space10;

    [Header("Jupiter voice lines")]
    public AudioClip jupiter00;
    public AudioClip jupiter01;
    public AudioClip jupiter02;
    public AudioClip jupiter03;

    [Header("Moon voice lines")]
    public AudioClip moon00;
    public AudioClip moon01;
    public AudioClip moon02;
    public AudioClip moon03;

    [Header("Earth voice lines")]
    public AudioClip earth00;
    public AudioClip earth01;
    public AudioClip earth02;
    public AudioClip earth03;

    [Header("Voice lines")]
    public AudioClip[] voiceLines;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            if (transform.parent != null)
            {
                // set AudioManager as own parent while still being child object
                transform.SetParent(null);
            }
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        SetMusic();
        PlayVoice();
        // SetBeginningAudio();
    }

    public void PlayUI(AudioClip clip)
    {
        uISource.PlayOneShot(clip);
    }

    public void PlaySFX(AudioClip clip)
    {
        sFXSource.PlayOneShot(clip);
    }

    public void PlayVoice()
    {
        if (voiceIndex < voiceLines.Length - 1)
        {
            voiceSource.Stop();
            voiceSource.PlayOneShot(voiceLines[voiceIndex]);
            voiceIndex++;
        }
    }

    public void SetMusic()
    {
        int sceneIndex = levelManager.BuildIndex;
        if (sceneIndex < music.Length && music[sceneIndex] != null)
        {
            musicSource.clip = music[sceneIndex];
            ambienceSource.clip = ambience[sceneIndex];
            musicSource.Play();
            ambienceSource.Play();
        }
    }

    // public void SetMusic()
    // {
    //     switch (levelManager.BuildIndex)
    //     {
    //         case 0:
    //             musicSource.clip = musicSpace;
    //             ambienceSource.clip = ambienceSpace;
    //             break;
    //         case 1:
    //             musicSource.clip = musicJupiter;
    //             ambienceSource.clip = ambienceJupiter;
    //             break;
    //         case 2:
    //             musicSource.clip = musicMoon;
    //             ambienceSource.clip = ambienceMoon;
    //             break;
    //         case 3:
    //             musicSource.clip = musicEarth;
    //             ambienceSource.clip = ambienceEarth;
    //             break;
    //         case 4:
    //             musicSource.clip = musicHome;
    //             // ambienceSource.clip = ambienceHome;
    //             break;
    //         default:
    //             Debug.Log("No source");
    //             break;
    //     }
    //     musicSource.Play();
    //     ambienceSource.Play();
    // }

    // public void SetBeginningAudio()
    // {
    //     switch (levelManager.BuildIndex)
    //     {
    //         // set starting sound for every scene plus condition
    //         case 0:
    //             musicSource.clip = musicSpace;
    //             ambienceSource.clip = ambienceSpace;
    //             if (voiceSource != null)
    //             {
    //                 BeginningVoiceLine();
    //             }
    //             else
    //             {
    //                 Debug.LogError("VoiceSource is not assigned!");
    //             }
    //             break;
    //         case 1:
    //             musicSource.clip = musicJupiter;
    //             ambienceSource.clip = ambienceJupiter;
    //             voiceSource.clip = jupiter00;
    //             break;
    //         case 2:
    //             musicSource.clip = musicMoon;
    //             ambienceSource.clip = ambienceMoon;
    //             voiceSource.clip = moon00;
    //             break;
    //         case 3:
    //             musicSource.clip = musicEarth;
    //             ambienceSource.clip = ambienceEarth;
    //             voiceSource.clip = earth00;
    //             break;
    //         default:
    //             Debug.Log("No source");
    //             break;
    //     }
    //     musicSource.Play();
    //     ambienceSource.Play();

    //     // Only call voiceSource.Play() once for the voice clip
    //     if (voiceSource.clip != null)  // Ensure there is a clip assigned
    //     {
    //         voiceSource.Play();
    //     }
    // }

    void BeginningVoiceLine()
    {
        VoiceLine voiceLineToPlay = GetActiveVoiceLine();
        AudioClip clipToPlay = null;

        switch (voiceLineToPlay)
        {
            case VoiceLine.VoiceLine1:
                clipToPlay = space00;
                break;
            case VoiceLine.VoiceLine2:
                clipToPlay = space04;
                break;
            case VoiceLine.VoiceLine3:
                clipToPlay = space07;
                break;
            case VoiceLine.VoiceLine4:
                clipToPlay = space10;
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
