using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyManager : MonoBehaviour
{
    [SerializeField] SpawnManager spawnManager;
    public void DestroyObject(GameObject objectToDestroy)
    {
        Destroy(objectToDestroy.gameObject);
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Delete"))
        {
            spawnManager.basketballCounter--;
            Destroy(gameObject);
        }
    }
}
