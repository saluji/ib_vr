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
    public GameState state;
    UIManager uIManager;
    public static event Action<GameState> OnGameStateChanged;

    // visitable planets in ship
    bool isMoonVisitable = false;
    bool isEarthVisitable = false;

    // task for minigames in ship
    bool isPracticingDart;
    bool isPracticingCan;

    // task counter
    int taskOneCounter;
    int taskTwoCounter;
    int taskThreeCounter;

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
        uIManager = GameObject.Find("UIManager").GetComponent<UIManager>();

        isPracticingCan = false;
        isPracticingDart = false;
        
        taskOneCounter = 0;
        taskTwoCounter = 0;
        taskThreeCounter = 0;
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
                HandleTaskOne();
                break;
            case GameState.TaskTwo:
                HandleTaskTwo();
                break;
            case GameState.TaskThree:
                HandleTaskThree();
                break;
            case GameState.TaskFour:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
        OnGameStateChanged?.Invoke(newState);
    }

    public void HandleTaskOne()
    {
        taskOneCounter++;
        if (taskOneCounter > 3)
        {
            uIManager.TaskOneButton.SetActive(true);
            UpdateGameState(GameState.TaskTwo);
        }
    }

    public void HandleTaskTwo()
    {
        taskTwoCounter++;
        if (taskTwoCounter > 3)
        {
            uIManager.TaskTwoButton.SetActive(true);
            UpdateGameState(GameState.TaskThree);
        }
    }

    public void HandleTaskThree()
    {
        taskThreeCounter++;
        if (taskThreeCounter > 3)
        {
            uIManager.TaskThreeButton.SetActive(true);
            UpdateGameState(GameState.TaskFour);
        }
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
