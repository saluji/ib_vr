using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tennisball : MonoBehaviour
{
    UIManager uIManager;
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
        if (GameManager.instance.IsPracticingCan) return;

        if (other.gameObject.CompareTag("Can"))
        {
            if ((uIManager.gravitySlider.value == 3 && GameManager.instance.IsMoonVisitable && GameManager.instance.IsEarthVisitable) ||
                (uIManager.gravitySlider.value == 2 && GameManager.instance.IsMoonVisitable && !GameManager.instance.IsEarthVisitable) ||
                (uIManager.gravitySlider.value == 1 && !GameManager.instance.IsMoonVisitable && !GameManager.instance.IsEarthVisitable))
            {
                GameManager.instance.IsPracticingCan = true;
                uIManager.UpdateTaskUI();
                uIManager.SetCanAlpha();
            }
        }
    }

}
