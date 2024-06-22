using System;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SpawnBasketball : MonoBehaviour
{
    [SerializeField] GameObject[] spawnObject;
    [SerializeField] Transform[] spawnPoint;
    /*[SerializeField] Rigidbody[] rb;
    void Start()
    {
        for (int i = 0; i < spawnObject.Length - 1; i++)
        {
            rb[i] = GetComponent<Rigidbody>();
        }
    }*/
    public void SpawnObject()
    {
        for (int i = 0; i < spawnObject.Length - 1; i++)
        {
            spawnObject[i].transform.position = spawnPoint[i].transform.position;
            //transform.position = spawnPoint.transform.position;
            //transform.rotation = spawnPoint.transform.rotation;
            //rb[i].velocity = Vector3.zero;
        }
    }
}
