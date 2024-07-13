using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tennisball : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.tennisball);
        if (other.gameObject.CompareTag("Can"))
        {
            GameManager.instance.IsPracticingCan = true;
        }
    }
}
