using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }
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
}
