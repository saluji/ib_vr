using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum GameState
{
    TaskOne,
    TaskTwo,
    TaskThree
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

    public bool IsMoonVisitable { get { return isMoonVisitable; } }
    public bool IsEarthVisitable { get { return isEarthVisitable; } }
    public bool IsPracticingCan { get { return isPracticingCan; } set { isPracticingCan = value; } }
    public bool IsPracticingDart { get { return isPracticingDart; } set { isPracticingDart = value; } }

    void Awake()
    {
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
                break;
            case GameState.TaskTwo:
                break;
            case GameState.TaskThree:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
        OnGameStateChanged?.Invoke(newState);
    }

    public void MoonVisitable()
    {
        isMoonVisitable = true;
    }

    public void EarthVisitable()
    {
        isEarthVisitable = true;
    }

    public void HandleTaskOne(int count)
    {
        if (state == GameState.TaskOne && (count >= 3))
        {
            // Show button
            uIManager.TaskOneButton.gameObject.SetActive(true);
        }
    }

    public void HandleTaskTwo(int count)
    {
        if (state == GameState.TaskTwo && count >= 3)
        {
            // Show button
            uIManager.TaskTwoButton.gameObject.SetActive(true);
        }
    }

    public void TaskOneState()
    {
        UpdateGameState(GameState.TaskTwo);
        basketball.Count = 0;
    }

    public void TaskTwoState()
    {
        UpdateGameState(GameState.TaskThree);
        basketball.Count = 0;
    }
}