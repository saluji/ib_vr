using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    public GameObject basketballPrefab;
    public GameObject dartPrefab;
    public GameObject canPrefab;
    public GameObject tennisballPrefab;
    [SerializeField] Transform spawnBallPosition;
    [SerializeField] Transform spawnDartPosition;
    [SerializeField] Transform spawnCanPosition;
    [SerializeField] Transform spawnTennisballPosition;

    void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            SpawnBasketball();
        }
        else
        {
            SpawnDart();
            SpawnTennisball();
        }
    }

    public void SpawnBasketball()
    {
        Instantiate(basketballPrefab, spawnBallPosition.transform.position, spawnBallPosition.transform.rotation);
    }

    public void SpawnDart()
    {
        Instantiate(dartPrefab, spawnDartPosition.transform.position, spawnDartPosition.transform.rotation);
    }

    public void SpawnTennisball()
    {
        Instantiate(canPrefab, spawnCanPosition.transform.position, spawnCanPosition.transform.rotation);
        Instantiate(tennisballPrefab, spawnTennisballPosition.transform.position, spawnTennisballPosition.transform.rotation);
    }
}