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
    [SerializeField] float lowerAmount = 0.25f;
    float minHeight = -1.75f;
    bool hasLowered;

    // public int Count { get { return count; } set { count = value; } }
    public int Count { get { return count; } }
    public int MaxCount { get { return maxCount; } }

    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        uIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        textManager = GameObject.Find("TextManager").GetComponent<TextManager>();
        basket = GameObject.Find("Basket").GetComponent<Transform>();


        interactable = GetComponent<XRBaseInteractable>();
        interactable.selectEntered.AddListener(OnSelectEnteredHandler);
        // interactable.selectExited.AddListener(OnSelectExitedHandler);

        count = 0;
    }

    void OnDestroy()
    {
        // Unsubscribe from the selectExited event to avoid memory leaks
        if (interactable != null)
        {
            interactable.selectEntered.RemoveListener(OnSelectEnteredHandler);
            // interactable.selectExited.RemoveListener(OnSelectExitedHandler);
        }
    }

    private void OnSelectEnteredHandler(SelectEnterEventArgs args)
    {
        // Reset the drop flag when the ball is regrabbed
        isBallDropped = false;
    }

    // public void OnSelectExitedHandler(SelectExitEventArgs args)
    // {
    // if (gameManager.state == GameState.TaskOne)
    // {
    //     count++;
    //     gameManager.HandleTaskOne(count, maxCount);
    // }
    // }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            // dribbling logic
            if (GameManager.instance.state == GameState.TaskOne && !isBallDropped)
            {
                // Increment the count and handle the GameState transitions for TaskOne
                isBallDropped = true; // Prevents incrementing the count again for the same drop
                count++;
                gameManager.HandleTaskOne(count, maxCount);
                textManager.TaskOneScore();
            }

            // basket logic
            else if (GameManager.instance.state == GameState.TaskTwo && !hasLowered && basket.position.y > minHeight)
            {
                // lower basket if player fails to throw basketball into basket
                basket.position -= new Vector3(0, lowerAmount, 0);
                hasLowered = true;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // show return to ship panel if in TaskTwo
        if (other.gameObject.CompareTag("Basket") && gameManager.state == GameState.TaskTwo)
        {
            uIManager.ShowReturnPanel();
        }
    }

    // public void ResetCount()
    // {
    //     count = 0;
    // }
}
