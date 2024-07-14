using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart : MonoBehaviour
{
    UIManager uIManager;
    Rigidbody rb;
    // bool taskDone = false;

    void Awake()
    {
        uIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other)
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.dart);
        if (other.gameObject.CompareTag("Target"))
        {
            // stick dart to dart target
            GameManager.instance.IsPracticingDart = true;
            rb.isKinematic = true;
            uIManager.UpdateTaskUI();
        }
    }
}
