using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tennisball : MonoBehaviour
{
    UIManager uIManager;
    bool taskDone = false;
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip clip;

    void Awake()
    {
        uIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        source = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other)
    {
        source.PlayOneShot(clip);
        if (!taskDone && other.gameObject.CompareTag("Can"))
        {
            GameManager.instance.IsPracticingCan = true;
            taskDone = true;
            uIManager.SetCanAlpha();
            uIManager.UpdateTaskUI();
        }
    }
}
