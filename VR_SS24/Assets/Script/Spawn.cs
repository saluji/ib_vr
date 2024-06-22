using System;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject[] spawnObject;
    [SerializeField] Transform[] spawnPoint;
    //private Rigidbody[] rb;
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }
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
