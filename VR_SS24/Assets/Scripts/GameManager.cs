using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum GameState
{
    // TaskZero = 0,
    TaskOne,
    TaskTwo,
    TaskThree,
    TaskFour
}

public class GameManager : MonoBehaviour
{
    // public static GameManager instance;
    public GameState state;
    UIManager uIManager;
    Basketball basketball;
    public static event Action<GameState> OnGameStateChanged;

    // visitable planets in ship
    bool isMoonVisitable = false;
    bool isEarthVisitable = false;

    // task for minigames in ship
    bool isPracticingDart;
    bool isPracticingCan;

    // public bool IsJupiterVisitable { get { return isJupiterVisitable; } }
    public bool IsMoonVisitable { get { return isMoonVisitable; } }
    public bool IsEarthVisitable { get { return isEarthVisitable; } }
    public bool IsPracticingCan { get { return isPracticingCan; } set { isPracticingCan = value; } }
    public bool IsPracticingDart { get { return isPracticingDart; } set { isPracticingDart = value; } }

    // public void SetGameState(GameState newState)
    // {
    //     switch(newState)
    // }

    void Awake()
    {
        // instance = this;
        uIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        basketball = GameObject.Find("Basketball").GetComponent<Basketball>();

        isPracticingCan = false;
        isPracticingDart = false;

    }

    void Start()
    {
        UpdateGameState(GameState.TaskOne);
    }

    public void UpdateGameState(GameState newState)
    {
        state = newState;
        switch (newState)
        {
            // case GameState.TaskZero:
            //     break;
            case GameState.TaskOne:
                // HandleTaskOne();
                break;
            case GameState.TaskTwo:
                // HandleTaskTwo();
                break;
            case GameState.TaskThree:
                // HandleTaskThree();
                break;
            case GameState.TaskFour:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
        OnGameStateChanged?.Invoke(newState);
    }

    // public void HandleTaskOne()
    // {
    //     uIManager.TaskOneButton.SetActive(true);
    // }

    // public void HandleTaskTwo()
    // {
    //     uIManager.TaskTwoButton.SetActive(true);
    // }

    // public void HandleTaskThree()
    // {
    //     uIManager.TaskThreeButton.SetActive(true);
    // }

    public void MoonVisitable()
    {
        isMoonVisitable = true;
    }

    public void EarthVisitable()
    {
        isEarthVisitable = true;
    }

    public void TaskOneState()
    {
        UpdateGameState(GameState.TaskTwo);
        basketball.ReleaseCount = 0;
    }

    public void TaskTwoState()
    {
        UpdateGameState(GameState.TaskThree);
        basketball.ReleaseCount = 0;
    }

    public void TaskThreeState()
    {
        UpdateGameState(GameState.TaskFour);
        basketball.ReleaseCount = 0;
    }
}