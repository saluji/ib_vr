using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum GameState
{
    TaskOne,
    TaskTwo
    // TaskThree
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
        UpdateGameState(GameState.TaskOne);
    }

    public void UpdateGameState(GameState newState)
    {
        state = newState;
        switch (newState)
        {
            case GameState.TaskOne:
                break;
            case GameState.TaskTwo:
                break;
            // case GameState.TaskThree:
            //     break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
        OnGameStateChanged?.Invoke(newState);
    }

    // public void HandleTaskOne(int count, int maxCount)
    // {
    //     if (state == GameState.TaskOne && (count >= maxCount))
    //     {
    //         // Show button
    //         uIManager.TaskOneButton.gameObject.SetActive(true);
    //     }
    // }

    public void HandleTaskOne(int count, int maxCount)
    {
        // if (state == GameState.TaskOne && count >= maxCount)
        if (count >= maxCount)
        {
            // Show button
            uIManager.TaskOneButton.gameObject.SetActive(true);
        }
    }

    public void ResetVariables()
    {
        // reset variables if returning to ship
        isPracticingCan = false;
        isPracticingDart = false;
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