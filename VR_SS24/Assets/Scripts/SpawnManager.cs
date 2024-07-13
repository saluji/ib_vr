// using System.Collections.Generic;
// using JetBrains.Annotations;
// using UnityEngine;
// using UnityEngine.SceneManagement;
// using System.Collections;

// public class SpawnManager : MonoBehaviour
// {
//     public GameObject basketballPrefab;
//     public GameObject dartPrefab;
//     public GameObject canPrefab;
//     public GameObject tennisballPrefab;
//     public GameObject teleporterPrefab;

//     [SerializeField] Transform spawnBallPosition;
//     [SerializeField] Transform spawnDartPosition;
//     [SerializeField] Transform spawnCanPosition;
//     [SerializeField] Transform spawnTennisballPosition;
//     [SerializeField] Transform spawnTeleporterPosition;

//     bool isTeleporterSpawned = false;

//     public void SpawnBasketball()
//     {
//         Instantiate(basketballPrefab, spawnBallPosition.transform.position, spawnBallPosition.transform.rotation);
//         basketballPrefab.SetActive(true);
//     }

//     public void SpawnDart()
//     {
//         Instantiate(dartPrefab, spawnDartPosition.transform.position, spawnDartPosition.transform.rotation);
//         dartPrefab.SetActive(true);
//     }

//     public void SpawnTennisball()
//     {
//         Instantiate(canPrefab, spawnCanPosition.transform.position, spawnCanPosition.transform.rotation);
//         Instantiate(tennisballPrefab, spawnTennisballPosition.transform.position, spawnTennisballPosition.transform.rotation);
//         tennisballPrefab.SetActive(true);
//         canPrefab.SetActive(true);
//     }

//     public void SpawnTeleporter()
//     {
//         // only spawn teleporter once
//         if (!isTeleporterSpawned)
//         {
//             Instantiate(teleporterPrefab, spawnTeleporterPosition.transform.position, spawnTeleporterPosition.transform.rotation);
//             isTeleporterSpawned = true;
//             teleporterPrefab.SetActive(true);
//         }

//     }
// }

using System.Collections;
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
    public GameObject teleporterPrefab;

    [SerializeField] Transform spawnBallPosition;
    [SerializeField] Transform spawnDartPosition;
    [SerializeField] Transform spawnCanPosition;
    [SerializeField] Transform spawnTennisballPosition;
    [SerializeField] Transform spawnTeleporterPosition;

    bool isTeleporterSpawned = false;
    bool isSpawning = false;  // Track if a spawn operation is in progress
    float cooldownDuration = 1.0f;  // Cooldown duration in seconds

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

    // public void SpawnTeleporter()
    // {
    //     if (!isSpawning)
    //     {
    //         AudioManager.instance.PlaySFX(AudioManager.instance.teleporter);
    //         StartCoroutine(SpawnCooldownCoroutine(() =>
    //         {
    //             // Only spawn teleporter once
    //             if (!isTeleporterSpawned)
    //             {
    //                 Instantiate(teleporterPrefab, spawnTeleporterPosition.transform.position, spawnTeleporterPosition.transform.rotation);
    //                 isTeleporterSpawned = true;
    //                 teleporterPrefab.SetActive(true);
    //             }
    //         }));
    //     }
    // }

    private IEnumerator SpawnCooldownCoroutine(System.Action spawnAction)
    {
        // Start the cooldown
        isSpawning = true;
        spawnAction?.Invoke();  // Perform the spawning action
        yield return new WaitForSeconds(cooldownDuration);  // Wait for the cooldown period
        isSpawning = false;  // End the cooldown
    }
}
