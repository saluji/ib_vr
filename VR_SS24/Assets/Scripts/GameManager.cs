using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// public enum GameState
// {
//     TaskZero = 0,
//     TaskOne,
//     TaskTwo,
//     TaskThree,
//     TaskFour
// }

public class GameManager : MonoBehaviour
{
    // visitable planets in ship
    // bool isJupiterVisitable = false;
    bool isMoonVisitable = false;
    bool isEarthVisitable = false;

    // task for minigames in ship
    // public static bool isPracticingDart;
    // public static bool isPracticingCan;
    bool isPracticingDart;
    bool isPracticingCan;

    // tasks for basketball level
    bool inTaskOne;
    bool inTaskTwo;
    bool inTaskThree;
    bool inTaskFour;

    // task counter
    int taskOneCounter;
    int taskTwoCounter;
    int taskThreeCounter;

    // public bool IsJupiterVisitable { get { return isJupiterVisitable; } }
    public bool IsMoonVisitable { get { return isMoonVisitable; } }
    public bool IsEarthVisitable { get { return isEarthVisitable; } }
    public bool IsPracticingCan { get { return isPracticingCan; } set { isPracticingCan = value; } }
    public bool IsPracticingDart { get { return isPracticingDart; } set { isPracticingDart = value; } }
    public bool InTaskOne { get { return inTaskOne; } }
    public bool InTaskTwo { get { return inTaskTwo; } }
    public bool InTaskThree { get { return inTaskThree; } }
    public bool InTaskFour { get { return inTaskFour; } }

    public int TaskOneCounter { get { return taskOneCounter; } }
    public int TaskTwoCounter { get { return taskTwoCounter; } }
    public int TaskThreeCounter { get { return taskThreeCounter; } }

    // public void SetGameState(GameState newState)
    // {
    //     switch(newState)
    // }

    void Awake()
    {
        isPracticingCan = false;
        isPracticingDart = false;

        inTaskOne = false;
        inTaskTwo = false;
        inTaskThree = false;
        inTaskFour = false;

        taskOneCounter = 0;
        taskTwoCounter = 0;
        taskThreeCounter = 0;
    }

    public void IncreaseTaskOneCounter()
    {
        if (InTaskOne)
            taskOneCounter++;
    }
    public void IncreaseTaskTwoCounter()
    {
        if (inTaskTwo)
            taskTwoCounter++;
    }
    public void IncreaseTaskThreeCounter()
    {
        if (inTaskThree)
            taskThreeCounter++;
    }

    public void TaskOne()
    {
        inTaskFour = !inTaskOne;
    }

    public void TaskTwo()
    {
        inTaskFour = !inTaskTwo;
    }

    public void TaskThree()
    {
        inTaskFour = !inTaskThree;
    }

    public void TaskFour()
    {
        inTaskFour = !inTaskFour;
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
