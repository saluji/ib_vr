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
    // [SerializeField] DestroyManager destroyManager;
    [SerializeField] Transform spawnBallPosition;
    [SerializeField] Transform spawnDartPosition;
    [SerializeField] Transform spawnCanPosition;
    [SerializeField] Transform spawnTennisballPosition;
    // [SerializeField] float spawnDelay = 1;
    // Rigidbody dartRb;

    void Awake()
    {
        // if (SceneManager.GetActiveScene().buildIndex == 0)
        // {
        //     SpawnDart();
        //     SpawnCan();
        //     SpawnTennisball();
        // }
        // else
        // {
        //     SpawnBasketball();
        // }
        SpawnDart();
        SpawnCan();
        SpawnTennisball();
        SpawnBasketball();
        // dartRb = dartPrefab.GetComponent<Rigidbody>();
    }
    public void SpawnBasketball()
    {
        // for (int i = 0; i < 5; i++)
        // {
        Instantiate(basketballPrefab, spawnBallPosition.transform.position, spawnBallPosition.transform.rotation);
        //     StartCoroutine(SpawnCountdown());
        // }
    }
    public void SpawnDart()
    {
        Instantiate(dartPrefab, spawnDartPosition.transform.position, spawnDartPosition.transform.rotation);
    }
    public void SpawnCan()
    {
        // for (int i = 0; i < 2; i++)
        // {
        Instantiate(canPrefab, spawnCanPosition.transform.position, spawnCanPosition.transform.rotation);
        // StartCoroutine(SpawnCountdown());
        // }
    }
    public void SpawnTennisball()
    {
        Instantiate(tennisballPrefab, spawnTennisballPosition.transform.position, spawnTennisballPosition.transform.rotation);
    }
    // public void CheckToDestroy(GameObject checkDestroy)
    // {
    //     DestroyObject(checkDestroy);
    // }
    // public void DestroyObject(GameObject objectToDestroy)
    // {
    //     Destroy(objectToDestroy.gameObject);
    // }
    // IEnumerator SpawnCountdown()
    // {
    //     yield return new WaitForSeconds(spawnDelay);
    // }
}
