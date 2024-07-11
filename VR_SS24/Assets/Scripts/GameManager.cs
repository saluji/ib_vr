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
    // Dictionary<string, bool> visitableStatus;
    public static GameManager instance { get; private set; }
    public GameState state;
    UIManager uIManager;
    public static event Action<GameState> OnGameStateChanged;

    // visitable planets in ship
    bool isMoonVisitable = false;
    bool isEarthVisitable = false;

    // task for minigames in ship
    bool isPracticingDart = false;
    bool isPracticingCan = false;

    public bool IsMoonVisitable { get { return isMoonVisitable; } }
    public bool IsEarthVisitable { get { return isEarthVisitable; } }
    public bool IsPracticingCan { get { return isPracticingCan; } set { isPracticingCan = value; } }
    public bool IsPracticingDart { get { return isPracticingDart; } set { isPracticingDart = value; } }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            if (transform.parent != null)
            {
                // set GameManager as own parent while still being child object
                transform.SetParent(null);
            }
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        uIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
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

    public void HandleTaskOne(int score, int maxScore)
    {
        // if (state == GameState.TaskOne && score >= maxScore)
        if (score >= maxScore)
        {
            // Show button
            uIManager.TaskTwoButton.gameObject.SetActive(true);
        }
    }

    public void ResetVariables()
    {
        // reset variables
        isPracticingCan = false;
        isPracticingDart = false;
        UpdateGameState(GameState.TaskZero);
    }

    public void SwitchToTaskOne()
    {
        UpdateGameState(GameState.TaskOne);
    }

    public void SwitchToTaskTwo()
    {
        UpdateGameState(GameState.TaskTwo);
    }

    public void MoonVisitable()
    {
        isMoonVisitable = true;
    }

    public void EarthVisitable()
    {
        isEarthVisitable = true;
    }
}