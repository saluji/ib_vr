using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart : MonoBehaviour
{
    UIManager uIManager;
    Rigidbody rb;
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
        if (other.gameObject.CompareTag("Target"))
        {
            rb.isKinematic = true;
            {
                if (GameManager.instance.IsPracticingDart) return;

                if ((uIManager.gravitySlider.value == 3 && GameManager.instance.IsMoonVisitable && GameManager.instance.IsEarthVisitable) ||
                    (uIManager.gravitySlider.value == 2 && GameManager.instance.IsMoonVisitable && !GameManager.instance.IsEarthVisitable) ||
                    (uIManager.gravitySlider.value == 1 && !GameManager.instance.IsMoonVisitable && !GameManager.instance.IsEarthVisitable))
                {
                    GameManager.instance.IsPracticingDart = true;
                    uIManager.UpdateTaskUI();
                    uIManager.SetDartAlpha();
                }
            }

        }
    }
}
