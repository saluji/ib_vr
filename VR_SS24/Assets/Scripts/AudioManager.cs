using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

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

    [Header("Background")]
    public AudioClip[] music;
    public AudioClip[] ambience;

    [Header("Voice lines")]
    public AudioClip[] voiceLines;

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

            levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
            ambienceSource.enabled = true;
            musicSource.enabled = true;
            sFXSource.enabled = true;
            uISource.enabled = true;
            voiceSource.enabled = true;
        }

        else
        {
            Destroy(gameObject);
        }
        // SetMusic();
        // PlayVoice();
    }

    void Start()
    {
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
        // play voice clips in correct order
        if (voiceIndex < voiceLines.Length)
        {
            voiceSource.Stop();
            voiceSource.PlayOneShot(voiceLines[voiceIndex]);
            voiceIndex++;
        }
    }

    // public void SetMusic()
    // {
    //     // set fitting music for the scene
    //     int sceneIndex = levelManager.BuildIndex;
    //     if (sceneIndex < music.Length && music[sceneIndex] != null)
    //     {
    //         musicSource.clip = music[sceneIndex];
    //         ambienceSource.clip = ambience[sceneIndex];
    //         musicSource.Play();
    //         ambienceSource.Play();
    //     }
    // }

    public void SetMusic()
    {
        int sceneIndex = levelManager.BuildIndex;
        if (sceneIndex < music.Length && music[sceneIndex] != null)
        {
            Debug.Log($"Setting music for scene {sceneIndex}: {music[sceneIndex].name}");
            musicSource.clip = music[sceneIndex];
            musicSource.Play();

            if (sceneIndex < ambience.Length && ambience[sceneIndex] != null)
            {
                Debug.Log($"Setting ambience for scene {sceneIndex}: {ambience[sceneIndex].name}");
                ambienceSource.clip = ambience[sceneIndex];
                ambienceSource.Play();
            }
            else
            {
                Debug.LogWarning($"Ambience clip for scene {sceneIndex} is null or out of range.");
            }
        }
        else
        {
            Debug.LogError($"Scene index {sceneIndex} is out of bounds for the music array.");
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
