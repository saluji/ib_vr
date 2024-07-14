using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Can : MonoBehaviour
{
    void OnCollisionEnter()
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.can);
    }
}
