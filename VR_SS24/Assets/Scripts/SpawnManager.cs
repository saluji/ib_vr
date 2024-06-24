using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject basketball;
    [SerializeField] GameObject dart;
    [SerializeField] GameObject can;
    [SerializeField] GameObject tennisball;
    [SerializeField] GameObject basketballButton;
    [SerializeField] GameObject dartButton;
    [SerializeField] GameObject canButton;
    [SerializeField] Transform[] spawnBallPosition;
    [SerializeField] GameObject[] spawnDartObject;
    [SerializeField] Transform[] spawnDartPosition;
    [SerializeField] GameObject[] spawnCanObject;
    [SerializeField] Transform[] spawnCanPosition;
    [SerializeField] GameObject spawnTennisballObject;
    [SerializeField] Transform spawnTennisballPosition;
    private int basketballAmount = 5;
    private int dartAmount = 3;
    private int canAmount = 6;
    private Rigidbody dartRb;
    void Awake()
    {
        for (int i = 0; i < basketballAmount; i++)
        {
            Instantiate(basketball, spawnBallPosition[i].transform.position, spawnBallPosition[i].transform.rotation);
        }
        for (int i = 0; i < dartAmount; i++)
        {
            Instantiate(dart, spawnDartPosition[i].transform.position, spawnDartPosition[i].transform.rotation);
        }
        for (int i = 0; i < canAmount; i++)
        {
            Instantiate(can, spawnCanPosition[i].transform.position, spawnCanPosition[i].transform.rotation);
        }
        dartRb = dart.GetComponent<Rigidbody>();
        Instantiate(tennisball, spawnTennisballPosition.transform.position, spawnTennisballPosition.transform.rotation);
    }
    public void SpawnBasketball()
    {
        /*for (int i = 0; i < basketballAmount - 1; i++)
        {
            basketballAmount[i].transform.position = spawnBallPosition[i].transform.position;
            basketballAmount[i].transform.rotation = spawnBallPosition[i].transform.rotation;
            //ballRb[i].velocity = Vector3.zero;
        }*/
    }
    public void SpawnDart()
    {
        /*for (int i = 0; i < dartAmount; i++)
        {
            spawnDartObject[i].transform.position = spawnDartPosition[i].transform.position;
            spawnDartObject[i].transform.rotation = spawnDartPosition[i].transform.rotation;
        }*/
    }
    public void SpawnCan()
    {
        //tennisballRb.velocity = Vector3.zero;

        /*spawnTennisballObject.transform.position = spawnTennisballPosition.transform.position;
        spawnTennisballObject.transform.rotation = spawnTennisballPosition.transform.rotation;

        for (int i = 0; i < canAmount; i++)
        {
            spawnCanObject[i].transform.position = spawnCanPosition[i].transform.position;
            spawnCanObject[i].transform.rotation = spawnCanPosition[i].transform.rotation;
        }*/
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Target"))
        {
            dartRb.isKinematic = true;
        }
        if (other.gameObject.CompareTag("Delete"))
        {
            Destroy(gameObject);
        }
    }
}
