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
    int maxCount = 3;

    // lower basket variables
    Transform basket;
    [SerializeField] float minHeight = 2.5f;
    [SerializeField] float lowerAmount = 0.25f;
    bool hasLowered;

    public int Count { get { return count; } set { count = value; } }
    public int MaxCount { get { return maxCount; } }

    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        uIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        textManager = GameObject.Find("TextManager").GetComponent<TextManager>();
        basket = GameObject.Find("Basket").GetComponent<Transform>();


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
        // Check if the ball hits the ground in TaskTwo
        if (collision.collider.CompareTag("Ground") && !isBallDropped && GameManager.instance.state != GameState.TaskThree)
        {
            // Increment the count and handle the GameState transitions for TaskOne
            isBallDropped = true; // Prevents incrementing the count again for the same drop
            count++;
            gameManager.HandleTaskOne(count, maxCount);
            textManager.TaskTwoScore();
        }

        else if (GameManager.instance.state == GameState.TaskThree && collision.collider.CompareTag("Ground") && !hasLowered && basket.position.y > minHeight)
        {
            // lower basket if player fails to throw basketball into basket
            basket.position -= new Vector3(0, lowerAmount, 0);
            hasLowered = true;
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
            gameManager.HandleTaskTwo(count, maxCount);
        }
    }

    public void ResetCount()
    {
        count = 0;
    }
}
