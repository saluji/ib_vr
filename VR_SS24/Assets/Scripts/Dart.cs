using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart : MonoBehaviour
{
    UIManager uIManager;
    Rigidbody rb;
    bool taskDone = false;

    void Awake()
    {
        uIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other)
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.dart);
        if (!taskDone && other.gameObject.CompareTag("Target"))
        {
            GameManager.instance.IsPracticingDart = true;
            rb.isKinematic = true;
            taskDone = true;
            AudioManager.instance.PlayUI(AudioManager.instance.done01);
            uIManager.UpdateTaskUI();
        }
    }
}
