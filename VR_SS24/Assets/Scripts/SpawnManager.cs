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
    public GameObject teleporterPrefab;

    [SerializeField] Transform spawnBallPosition;
    [SerializeField] Transform spawnDartPosition;
    [SerializeField] Transform spawnCanPosition;
    [SerializeField] Transform spawnTennisballPosition;
    [SerializeField] Transform spawnTeleporterPosition;

    bool isTeleporterSpawned = false;

    // void Awake()
    // {
    //     Instantiate(teleporterPrefab, spawnTeleporterPosition.transform.position, spawnTeleporterPosition.transform.rotation);
    // }

    public void SpawnBasketball()
    {
        Instantiate(basketballPrefab, spawnBallPosition.transform.position, spawnBallPosition.transform.rotation);
        basketballPrefab.SetActive(true);
    }

    public void SpawnDart()
    {
        Instantiate(dartPrefab, spawnDartPosition.transform.position, spawnDartPosition.transform.rotation);
        dartPrefab.SetActive(true);
    }

    public void SpawnTennisball()
    {
        Instantiate(canPrefab, spawnCanPosition.transform.position, spawnCanPosition.transform.rotation);
        Instantiate(tennisballPrefab, spawnTennisballPosition.transform.position, spawnTennisballPosition.transform.rotation);
        tennisballPrefab.SetActive(true);
        canPrefab.SetActive(true);
    }

    public void SpawnTeleporter()
    {
        if (!isTeleporterSpawned)
        {
            Instantiate(teleporterPrefab, spawnTeleporterPosition.transform.position, spawnTeleporterPosition.transform.rotation);
            isTeleporterSpawned = true;
            teleporterPrefab.SetActive(true);
        }

    }
}