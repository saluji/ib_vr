using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum GameState
{
    TaskZero,
    TaskOne,
    TaskTwo
}

public class GameManager : MonoBehaviour
{
    public GameState state;
    public static GameManager instance { get; private set; }
    public static event Action<GameState> OnGameStateChanged;

    // visitable planets in ship
    bool isMoonVisitable = false;
    bool isEarthVisitable = false;
    bool isGameDone = false;

    // task for minigames in ship
    bool isPracticingDart = false;
    bool isPracticingCan = false;

    public bool IsMoonVisitable { get { return isMoonVisitable; } set { isMoonVisitable = value; } }
    public bool IsEarthVisitable { get { return isEarthVisitable; } set { isEarthVisitable = value; } }
    public bool IsGameDone { get { return isGameDone; } set { isGameDone = value; } }
    public bool IsPracticingCan { get { return isPracticingCan; } set { isPracticingCan = value; } }
    public bool IsPracticingDart { get { return isPracticingDart; } set { isPracticingDart = value; } }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            if (transform.parent != null)
            {
                // set GameObject as own parent while still being child object
                transform.SetParent(null);
            }
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateGameState(GameState.TaskZero);
    }

    public void UpdateGameState(GameState newState)
    {
        state = newState;
        switch (newState)
        {
            case GameState.TaskZero:
                break;
            case GameState.TaskOne:
                break;
            case GameState.TaskTwo:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
        OnGameStateChanged?.Invoke(newState);
    }

    public void ResetVariables()
    {
        // reset variables
        isPracticingCan = false;
        isPracticingDart = false;
        UpdateGameState(GameState.TaskZero);
    }

    // public void SwitchToTaskOne()
    // {
    //     UpdateGameState(GameState.TaskOne);
    // }

    // public void SwitchToTaskTwo()
    // {
    //     UpdateGameState(GameState.TaskTwo);
    // }
}