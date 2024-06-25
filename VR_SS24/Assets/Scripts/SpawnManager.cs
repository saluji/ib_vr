using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    public GameObject basketballPrefab;
    public GameObject dartPrefab;
    public GameObject canPrefab;
    public GameObject tennisballPrefab;
    [SerializeField] DestroyManager destroyManager;
    [SerializeField] Transform[] spawnBallPosition;
    [SerializeField] Transform[] spawnDartPosition;
    [SerializeField] Transform[] spawnCanPosition;
    [SerializeField] Transform spawnTennisballPosition;
    //public GameObject[] basketballList;
    public List<GameObject> basketballList;
    public int basketballCounter;
    public int dartCounter;
    public int canCounter;
    public int tennisballcounter = 1;
    public int counter;
    void Awake()
    {
        counter = 0;
        basketballCounter = spawnBallPosition.Length;
        //basketballList = spawnBallPosition.Length;
        dartCounter = spawnDartPosition.Length;
        canCounter = spawnCanPosition.Length;
        /*if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            SpawnDart();
            SpawnCan();
            SpawnTennisball();
            dartRb = dart.GetComponent<Rigidbody>();
        }
        else
        {
            SpawnBasketball();
        }*/
        SpawnDart();
        SpawnCan();
        SpawnTennisball();
        SpawnBasketball();
    }
    void Start()
    {
        counter++;
    }
    public void SpawnBasketball()
    {
        for (int i = 0; i < basketballCounter; i++)
        {
            //CheckToDestroy(basketballList[i], basketballList.Length);
            basketballList[i] = Instantiate(basketballPrefab, spawnBallPosition[i].transform.position, spawnBallPosition[i].transform.rotation);
        }
    }
    public void SpawnDart()
    {
        for (int i = 0; i < dartCounter; i++)
        {
            Instantiate(dartPrefab, spawnDartPosition[i].transform.position, spawnDartPosition[i].transform.rotation);
        }
    }
    public void SpawnCan()
    {
        for (int i = 0; i < canCounter; i++)
        {
            Instantiate(canPrefab, spawnCanPosition[i].transform.position, spawnCanPosition[i].transform.rotation);
        }
    }
    public void SpawnTennisball()
    {
        Instantiate(tennisballPrefab, spawnTennisballPosition.transform.position, spawnTennisballPosition.transform.rotation);
    }
    public void CheckToDestroy(GameObject checkDestroy, int list)
    {
        if (counter == 1)
        {
            //basketballList.Length = 1;
            DestroyObject(checkDestroy);
        }
    }
    public void DestroyObject(GameObject objectToDestroy)
    {
        Destroy(objectToDestroy.gameObject);
    }
}
