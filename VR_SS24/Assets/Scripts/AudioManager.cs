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
    public int voiceIndex = 0;

    [Header("Audio Source")]
    [SerializeField] AudioSource ambienceSource;
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sFXSource;
    [SerializeField] AudioSource uISource;
    [SerializeField] AudioSource voiceSource;

    [Header("Music")]
    // public AudioClip musicSpace;
    // public AudioClip musicJupiter;
    // public AudioClip musicMoon;
    // public AudioClip musicEarth;
    // public AudioClip musicHome;
    public AudioClip[] music;
    public AudioClip[] ambience;

    [Header("Voice lines")]
    public AudioClip[] voiceLines;
    
    // [Header("Ambience")]
    // public AudioClip ambienceSpace;
    // public AudioClip ambienceJupiter;
    // public AudioClip ambienceMoon;
    // public AudioClip ambienceEarth;

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
        Debug.Log("Play voice");
        if (voiceIndex < voiceLines.Length)
        {
            Debug.Log("Still below length");
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
}
