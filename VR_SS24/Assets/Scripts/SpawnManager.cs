using System.Collections;
using UnityEngine;

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
    bool isSpawning = false;
    float cooldownDuration = 1.0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SpawnTennisball();
        }
    }
    public void SpawnBasketball()
    {
        if (!isSpawning)
        {
            StartCoroutine(SpawnCooldownCoroutine(() =>
            {
                Instantiate(basketballPrefab, spawnBallPosition.transform.position, spawnBallPosition.transform.rotation);
            }));
        }
    }

    public void SpawnDart()
    {
        if (!isSpawning)
        {
            StartCoroutine(SpawnCooldownCoroutine(() =>
            {
                Instantiate(dartPrefab, spawnDartPosition.transform.position, spawnDartPosition.transform.rotation);
            }));
        }
    }

    public void SpawnTennisball()
    {
        if (!isSpawning)
        {
            StartCoroutine(SpawnCooldownCoroutine(() =>
            {
                Instantiate(canPrefab, spawnCanPosition.position, spawnCanPosition.rotation);
                Instantiate(tennisballPrefab, spawnTennisballPosition.position, spawnTennisballPosition.rotation);
            }));
        }
    }

    public void SpawnTeleporter()
    {
        // only spawn teleporter once
        if (!isTeleporterSpawned)
        {
            Instantiate(teleporterPrefab, spawnTeleporterPosition.transform.position, spawnTeleporterPosition.transform.rotation);
            AudioManager.instance.PlaySFX(AudioManager.instance.teleporter);
        }
    }

    private IEnumerator SpawnCooldownCoroutine(System.Action spawnAction)
    {
        isSpawning = true;
        spawnAction?.Invoke();
        yield return new WaitForSeconds(cooldownDuration);
        isSpawning = false;
    }
}
