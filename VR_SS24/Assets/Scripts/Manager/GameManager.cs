using System;
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

    // visitable planets
    bool isMoonVisitable = false;
    bool isEarthVisitable = false;
    bool isGameDone = false;

    // ship task conditions
    bool isTaskZeroDone = false;
    bool isPracticingDart = false;
    bool isPracticingCan = false;

    // basketball conditions
    bool isTaskOneDone = false;
    bool isTaskTwoDone = false;

    public bool IsMoonVisitable { get { return isMoonVisitable; } set { isMoonVisitable = value; } }
    public bool IsEarthVisitable { get { return isEarthVisitable; } set { isEarthVisitable = value; } }
    public bool IsGameDone { get { return isGameDone; } set { isGameDone = value; } }
    public bool IsTaskZeroDone { get { return isTaskZeroDone; } set { isTaskZeroDone = value; } }
    public bool IsTaskOneDone { get { return isTaskOneDone; } set { isTaskOneDone = value; } }
    public bool IsTaskTwoDone { get { return isTaskTwoDone; } set { isTaskTwoDone = value; } }
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
        isTaskZeroDone = false;
        isTaskOneDone = false;
        isTaskTwoDone = false;
        isPracticingCan = false;
        isPracticingDart = false;
        UpdateGameState(GameState.TaskZero);
    }
}
