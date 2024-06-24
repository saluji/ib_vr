using System;
using System.Drawing;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] Dart dartScript;
    [SerializeField] Can canScript;
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
    /*private Rigidbody[] ballRb;
    private Rigidbody tennisballRb;
    void Start()
    {
        for (int i = 0; i < spawnBallObject.Length - 1; i++)
        {
            ballRb[i] = GetComponent<Rigidbody>();
        }
        tennisballRb = spawnTennisballObject.GetComponent<Rigidbody>();
    }*/
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SpawnBasketball();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            SpawnDart();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SpawnDart();
        }
    }
    public void SpawnBasketball()
    {
        for (int i = 0; i < spawnBallObject.Length - 1; i++)
        {
            spawnBallObject[i].transform.position = spawnBallPosition[i].transform.position;
            spawnBallObject[i].transform.rotation = spawnBallPosition[i].transform.rotation;
            //ballRb[i].velocity = Vector3.zero;
        }
    }
    public void SpawnDart()
    {
        dartScript.rb.isKinematic = false;
        for (int i = 0; i < spawnDartObject.Length - 1; i++)
        {
            spawnDartObject[i].transform.position = spawnDartPosition[i].transform.position;
            spawnDartObject[i].transform.rotation = spawnDartPosition[i].transform.rotation;
        }
    }
    public void SpawnCan()
    {
        canScript.rb.isKinematic = true;
        //tennisballRb.velocity = Vector3.zero;

        spawnTennisballObject.transform.position = spawnTennisballPosition.transform.position;
        spawnTennisballObject.transform.rotation = spawnTennisballPosition.transform.rotation;

        for (int i = 0; i < spawnCanObject.Length - 1; i++)
        {
            spawnCanObject[i].transform.position = spawnCanPosition[i].transform.position;
            spawnCanObject[i].transform.rotation = spawnCanPosition[i].transform.rotation;
        }
    }
}
