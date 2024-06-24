using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject basketball;
    [SerializeField] GameObject dart;
    [SerializeField] GameObject can;
    [SerializeField] GameObject tennisball;
    [SerializeField] Dart dartScript;
    [SerializeField] GameObject basketballButton;
    [SerializeField] GameObject dartButton;
    [SerializeField] GameObject canButton;
    [SerializeField] Transform[] spawnBallPosition;
    [SerializeField] Transform[] spawnDartPosition;
    [SerializeField] Transform[] spawnCanPosition;
    [SerializeField] Transform spawnTennisballPosition;
    private int basketballAmount = 5;
    private int dartAmount = 3;
    private int canAmount = 6;
    void Awake()
    {
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
        for (int i = 0; i < basketballAmount; i++)
        {
            Instantiate(basketball, spawnBallPosition[i].transform.position, spawnBallPosition[i].transform.rotation);
        }
    }
    public void SpawnDart()
    {
        for (int i = 0; i < dartAmount; i++)
        {
            Instantiate(dart, spawnDartPosition[i].transform.position, spawnDartPosition[i].transform.rotation);
        }
    }
    public void SpawnCan()
    {
        for (int i = 0; i < canAmount; i++)
        {
            Instantiate(can, spawnCanPosition[i].transform.position, spawnCanPosition[i].transform.rotation);
        }
    }
    public void SpawnTennisball()
    {
        Instantiate(tennisball, spawnTennisballPosition.transform.position, spawnTennisballPosition.transform.rotation);
    }
    public void DestroySpawnedObject()
    {
        Destroy(basketball.gameObject);
        Destroy(dart.gameObject);
        Destroy(can.gameObject);
        Destroy(tennisball.gameObject);
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Delete"))
        {
            DestroySpawnedObject();
        }
    }
}
