using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tennisball : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Can"))
        {
            GameManager.instance.IsPracticingCan = true;
        }
    }
}
