using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }
    LevelManager levelManager;
    private int voiceIndex = 0;

    [Header("Audio Source")]
    [SerializeField] AudioSource uISource;
    [SerializeField] AudioSource voiceSource;

    [Header("Voice lines")]
    public AudioClip[] voiceLines;

    [Header("UI Sound")]
    public AudioClip done01;
    public AudioClip done02;
    public AudioClip fail;
    public AudioClip sliderClick;
    public AudioClip uIClick;

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
            uISource.enabled = true;
            voiceSource.enabled = true;
        }

        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // SetMusic();
        PlayVoice();
    }

    public void PlayUI(AudioClip clip)
    {
        uISource.PlayOneShot(clip);
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

    // public void SetMusic()
    // {
    //     int sceneIndex = levelManager.BuildIndex;
    //     if (sceneIndex < music.Length && music[sceneIndex] != null)
    //     {
    //         Debug.Log($"Setting music for scene {sceneIndex}: {music[sceneIndex].name}");
    //         musicSource.clip = music[sceneIndex];
    //         musicSource.Play();

    //         if (sceneIndex < ambience.Length && ambience[sceneIndex] != null)
    //         {
    //             Debug.Log($"Setting ambience for scene {sceneIndex}: {ambience[sceneIndex].name}");
    //             ambienceSource.clip = ambience[sceneIndex];
    //             ambienceSource.Play();
    //         }
    //         else
    //         {
    //             Debug.LogWarning($"Ambience clip for scene {sceneIndex} is null or out of range.");
    //         }
    //     }
    //     else
    //     {
    //         Debug.LogError($"Scene index {sceneIndex} is out of bounds for the music array.");
    //     }
    // }
}
