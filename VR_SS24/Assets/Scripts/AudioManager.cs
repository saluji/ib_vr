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

    [Header("Music")]
    public AudioClip musicSpace;
    public AudioClip musicJupiter;
    public AudioClip musicMoon;
    public AudioClip musicEarth;

    [Header("Ambience")]
    public AudioClip ambienceSpace;
    public AudioClip ambienceJupiter;
    public AudioClip ambienceMoon;
    public AudioClip ambienceEarth;

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

        SetBeginningAudio();
        // switch (levelManager.BuildIndex)
        // {
        //     // set starting sound for ever scene plus condition
        //     case 0:
        //         musicSource.clip = musicSpace;
        //         ambienceSource.clip = ambienceSpace;
        //         if (voiceSource != null)
        //         {
        //             BeginningVoiceLine();
        //         }
        //         else
        //         {
        //             Debug.LogError("VoiceSource is not assigned!");
        //         }
        //         break;
        //     case 1:
        //         musicSource.clip = musicJupiter;
        //         ambienceSource.clip = ambienceJupiter;
        //         // voiceSource.clip = jupiter00;
        //         voiceSource.clip = space01;
        //         break;
        //     case 2:
        //         musicSource.clip = musicMoon;
        //         ambienceSource.clip = ambienceMoon;
        //         // voiceSource.clip = moon00;
        //         voiceSource.clip = space02;
        //         break;
        //     case 3:
        //         musicSource.clip = musicEarth;
        //         ambienceSource.clip = ambienceEarth;
        //         // voiceSource.clip = earth00;
        //         voiceSource.clip = space03;
        //         break;
        //     default:
        //         Debug.Log("No source");
        //         break;
        // }
        // musicSource.Play();
        // ambienceSource.Play();

        // // Only call voiceSource.Play() once for the voice clip
        // if (voiceSource.clip != null)  // Ensure there is a clip assigned
        // {
        //     voiceSource.Play();
        // }
    }

    public void SetBeginningAudio()
    {
        switch (levelManager.BuildIndex)
        {
            // set starting sound for ever scene plus condition
            case 0:
                musicSource.clip = musicSpace;
                ambienceSource.clip = ambienceSpace;
                if (voiceSource != null)
                {
                    BeginningVoiceLine();
                }
                else
                {
                    Debug.LogError("VoiceSource is not assigned!");
                }
                break;
            case 1:
                musicSource.clip = musicJupiter;
                ambienceSource.clip = ambienceJupiter;
                // voiceSource.clip = jupiter00;
                voiceSource.clip = space01;
                break;
            case 2:
                musicSource.clip = musicMoon;
                ambienceSource.clip = ambienceMoon;
                // voiceSource.clip = moon00;
                voiceSource.clip = space02;
                break;
            case 3:
                musicSource.clip = musicEarth;
                ambienceSource.clip = ambienceEarth;
                // voiceSource.clip = earth00;
                voiceSource.clip = space03;
                break;
            default:
                Debug.Log("No source");
                break;
        }
        musicSource.Play();
        ambienceSource.Play();

        // Only call voiceSource.Play() once for the voice clip
        if (voiceSource.clip != null)  // Ensure there is a clip assigned
        {
            voiceSource.Play();
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
