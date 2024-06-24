using System;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject ballButton;
    [SerializeField] GameObject dartButton;
    [SerializeField] GameObject canButton;
    [SerializeField] GameObject[] spawnBallObject;
    [SerializeField] Transform[] spawnBallPosition;
    [SerializeField] GameObject[] spawnDartObject;
    [SerializeField] Transform[] spawnDartPosition;
    [SerializeField] GameObject[] spawnCanObject;
    [SerializeField] Transform[] spawnCanPosition;
    /*[SerializeField] Rigidbody[] rb;
    void Start()
    {
        for (int i = 0; i < spawnObject.Length - 1; i++)
        {
            rb[i] = GetComponent<Rigidbody>();
        }
    }*/
    public void SpawnBall()
    {
        for (int i = 0; i < spawnBallObject.Length - 1; i++)
        {
            spawnBallObject[i].transform.position = spawnBallPosition[i].transform.position;
            //transform.position = spawnPoint.transform.position;
            //transform.rotation = spawnPoint.transform.rotation;
            //rb[i].velocity = Vector3.zero;
        }
    }
}
