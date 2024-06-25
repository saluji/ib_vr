using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basketball : MonoBehaviour
{
    [SerializeField] SpawnManager spawnManager;
    public int basketballCounter;
    void Awake()
    {
        basketballCounter = spawnManager.spawnBallPosition.Length;
    }
}
