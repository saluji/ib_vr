using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class Basketball : MonoBehaviour
{
    GameManager gameManager;
    UIManager uIManager;
    TextManager textManager;
    // int taskOneCounter;
    // int taskTwoCounter;
    // int taskThreeCounter;

    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        uIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        textManager = GameObject.Find("TextManager").GetComponent<TextManager>();
        // taskOneCounter = 0;
        // taskTwoCounter = 0;
        // taskThreeCounter = 0;
    }

    // public void BasketballMinigame()
    // {
    //     switch (gameManager.state)
    //     {
            // case GameState.TaskOne:

    //     }
    // }

    // public void TaskOne()
    // {
    //     taskOneCounter++;
    //     if (taskOneCounter > 3 && gameManager.state == GameState.TaskOne)
    //     {
    //         uIManager.TaskOneButton.SetActive(true);
    //         gameManager.state = GameState.TaskTwo;
    //     }
    // }

    // public void TaskTwo()
    // {
    //     taskTwoCounter++;
    //     if (taskTwoCounter > 3 && gameManager.state == GameState.TaskTwo)
    //     {
    //         uIManager.TaskTwoButton.SetActive(true);
    //         gameManager.state = GameState.TaskThree;
    //     }
    // }
    // public void TaskThree()
    // {
    //     taskThreeCounter++;
    //     if (taskThreeCounter > 3 && gameManager.state == GameState.TaskThree)
    //     {
    //         uIManager.TaskThreeButton.SetActive(true);
    //         gameManager.state = GameState.TaskFour;
    //     }
    // }

    void OnTriggerEnter(Collider other)
    {
        // show return to ship panel if in TaskFour
        if (other.gameObject.CompareTag("Basket") && gameManager.state == GameState.TaskFour)
        {
            uIManager.ShowReturnPanel();
        }
    }
}
