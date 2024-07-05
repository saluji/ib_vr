using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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

    // public bool IsJupiterVisitable { get { return isJupiterVisitable; } }
    public bool IsMoonVisitable { get { return isMoonVisitable; } }
    public bool IsEarthVisitable { get { return isEarthVisitable; } }
    public bool IsPracticingCan { get { return isPracticingCan; } set { isPracticingCan = value; } }
    public bool IsPracticingDart { get { return isPracticingDart; } set { isPracticingDart = value; } }
    public bool InTaskOne { get { return inTaskOne; } }
    public bool InTaskTwo { get { return inTaskTwo; } }
    public bool InTaskThree { get { return inTaskThree; } }
    public bool InTaskFour { get { return inTaskFour; } }

    void Awake()
    {
        isPracticingCan = false;
        isPracticingDart = false;

        inTaskOne = false;
        inTaskTwo = false;
        inTaskThree = false;
        inTaskFour = false;
    }
    void Update()
    {

    }

    public void TaskFour()
    {
        inTaskFour = !inTaskFour;
    }
}
