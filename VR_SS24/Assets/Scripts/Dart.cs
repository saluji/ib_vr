using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart : MonoBehaviour
{
    UIManager uIManager;
    Rigidbody rb;
    bool taskDone = false;
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip clip;

    void Awake()
    {
        uIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        rb = GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other)
    {
        source.PlayOneShot(clip);
        if (!taskDone && other.gameObject.CompareTag("Target"))
        {
            GameManager.instance.IsPracticingDart = true;
            rb.isKinematic = true;
            taskDone = true;
            uIManager.SetDartAlpha();
            uIManager.UpdateTaskUI();
        }
    }
}
