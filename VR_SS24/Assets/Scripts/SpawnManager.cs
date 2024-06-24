using System;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] Dart dart;
    [SerializeField] Can can;
    [SerializeField] GameObject basketballButton;
    [SerializeField] GameObject dartButton;
    [SerializeField] GameObject canButton;
    [SerializeField] GameObject[] spawnBallObject;
    [SerializeField] Transform[] spawnBallPosition;
    [SerializeField] GameObject[] spawnDartObject;
    [SerializeField] Transform[] spawnDartPosition;
    [SerializeField] GameObject[] spawnCanObject;
    [SerializeField] Transform[] spawnCanPosition;
    [SerializeField] GameObject spawnTennisballObject;
    [SerializeField] Transform spawnTennisballPosition;
    /*[SerializeField] Rigidbody[] rb;
    void Start()
    {
        for (int i = 0; i < spawnObject.Length - 1; i++)
        {
            rb[i] = GetComponent<Rigidbody>();
        }
    }*/
    public void SpawnBasketball()
    {
        for (int i = 0; i < spawnBallObject.Length - 1; i++)
        {
            spawnBallObject[i].transform.position = spawnBallPosition[i].transform.position;
            spawnBallObject[i].transform.rotation = spawnBallPosition[i].transform.rotation;
            //rb[i].velocity = Vector3.zero;
        }
    }
    public void SpawnDart()
    {
        dart.rb.isKinematic = false;
        for (int i = 0; i < spawnDartObject.Length - 1; i++)
        {
            spawnDartObject[i].transform.position = spawnDartPosition[i].transform.position;
            spawnDartObject[i].transform.rotation = spawnDartPosition[i].transform.rotation;
        }
    }
    public void SpawnCan()
    {
        can.rb.isKinematic = true;
        spawnTennisballObject.transform.position = spawnTennisballPosition.transform.position;
        for (int i = 0; i < spawnCanObject.Length - 1; i++)
        {
            spawnCanObject[i].transform.position = spawnCanPosition[i].transform.position;
            spawnCanObject[i].transform.rotation = spawnCanPosition[i].transform.rotation;
        }
    }
}
