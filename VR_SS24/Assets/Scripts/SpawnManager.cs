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

    public void SpawnBasketball()
    {
        if (!isSpawning)
        {
            StartCoroutine(SpawnCooldownCoroutine(() =>
            {
                Instantiate(basketballPrefab, spawnBallPosition.transform.position, spawnBallPosition.transform.rotation);
                basketballPrefab.SetActive(true);
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
                dartPrefab.SetActive(true);
            }));
        }
    }

    public void SpawnTennisball()
    {
        if (!isSpawning)
        {
            StartCoroutine(SpawnCooldownCoroutine(() =>
            {
                Instantiate(canPrefab, spawnCanPosition.transform.position, spawnCanPosition.transform.rotation);
                Instantiate(tennisballPrefab, spawnTennisballPosition.transform.position, spawnTennisballPosition.transform.rotation);
                tennisballPrefab.SetActive(true);
                canPrefab.SetActive(true);
            }));
        }
    }

    public void SpawnTeleporter()
    {
        // only spawn teleporter once
        if (!isTeleporterSpawned)
        {
            Instantiate(teleporterPrefab, spawnTeleporterPosition.transform.position, spawnTeleporterPosition.transform.rotation);
            isTeleporterSpawned = true;
            teleporterPrefab.SetActive(true);
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
