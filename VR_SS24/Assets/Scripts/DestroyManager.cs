using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyManager : MonoBehaviour
{
    [SerializeField] SpawnManager spawnManager;
    void Awake()
    {
        //counter = spawnManager.basketballAmount;
    }
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
