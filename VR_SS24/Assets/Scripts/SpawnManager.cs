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
    [SerializeField] Basketball basketball;
    public Transform[] spawnBallPosition;
    public Transform[] spawnDartPosition;
    public Transform[] spawnCanPosition;
    public Transform spawnTennisballPosition;
    public int basketballCounter;
    public int dartCounter;
    public int canCounter;
    public int tennisballcounter = 1;
    void Awake()
    {
        basketballCounter = spawnBallPosition.Length;
        dartCounter = spawnDartPosition.Length;
        canCounter= spawnCanPosition.Length;
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
    public void SpawnBasketball()
    {
        for (int i = 0; i < basketball.basketballCounter; i++)
        {
            Instantiate(basketballPrefab, spawnBallPosition[i].transform.position, spawnBallPosition[i].transform.rotation);
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
}
