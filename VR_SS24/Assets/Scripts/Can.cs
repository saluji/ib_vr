using UnityEngine;

public class Can : MonoBehaviour
{
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip clip;
    
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void OnCollisionEnter()
    {
        source.PlayOneShot(clip);
    }
}
