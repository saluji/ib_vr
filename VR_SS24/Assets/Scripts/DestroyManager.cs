using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyManager : MonoBehaviour
{
    public void DestroyObject()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Delete"))
        {
            DestroyObject();
        }
    }
}
