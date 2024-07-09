using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;
using UnityEngine.Rendering.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class Basketball : MonoBehaviour
{
    XRBaseInteractable interactable;
    GameManager gameManager;
    UIManager uIManager;
    TextManager textManager;

    bool isBallDropped;
    int count;
    int maxCount = 5;

    public int Count { get { return count; } set { count = value; } }

    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        uIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        textManager = GameObject.Find("TextManager").GetComponent<TextManager>();
        interactable = GetComponent<XRBaseInteractable>();

        interactable.selectEntered.AddListener(OnSelectEnteredHandler);
        interactable.selectExited.AddListener(OnSelectExitedHandler);

        count = 0;
    }

    void OnDestroy()
    {
        // Unsubscribe from the selectExited event to avoid memory leaks
        if (interactable != null)
        {
            interactable.selectEntered.RemoveListener(OnSelectEnteredHandler);
            interactable.selectExited.RemoveListener(OnSelectExitedHandler);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // show return to ship panel if in TaskThree
        if (other.gameObject.CompareTag("Basket") && gameManager.state == GameState.TaskThree)
        {
            uIManager.ShowReturnPanel();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the ball hits the ground
        if (collision.collider.CompareTag("Ground") && !isBallDropped)
        {
            // Increment the count and handle the GameState transitions for TaskOne
            isBallDropped = true; // Prevents incrementing the count again for the same drop
            count++;
            gameManager.HandleTaskOne(count);
        }
    }

    private void OnSelectEnteredHandler(SelectEnterEventArgs args)
    {
        isBallDropped = false;  // Reset the drop flag when the ball is regrabbed
    }

    public void OnSelectExitedHandler(SelectExitEventArgs args)
    {
        if (gameManager.state == GameState.TaskTwo)
        {
            count++;
            gameManager.HandleTaskTwo(count);
        }
        // count++;
        // switch (gameManager.state)
        // {
        //     case GameState.TaskOne:
        //         if (count >= maxCount)
        //         {
        //             uIManager.TaskOneButton.SetActive(true);
        //         }
        //         break;
        //     case GameState.TaskTwo:
        //         if (count >= maxCount)
        //         {
        //             uIManager.TaskTwoButton.SetActive(true);
        //         }
        //         break;
        // }
    }

    // void OnCollisionEnter(Collision other)
    // {
    //     if (args.interactableObject == this && gameManager.state == GameState.TaskTwo)
    //     {
    //         count++;
    //         gameManager.HandleTaskTwo(count);
    //     }
    // }

    // void ResetCount()
    // {
    //     count = 0;
    // }
}
