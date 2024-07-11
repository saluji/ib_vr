using System.Collections;
using System.Collections.Generic;
using Unity.VRTemplate;
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
    int currentScore = 0;
    int maxScore = 5;

    // lower basket variables
    Transform basket;
    [SerializeField] float lowerAmount = 0.25f;
    [SerializeField] float minHeight = -1.75f;
    bool hasLowered;

    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        uIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        textManager = GameObject.Find("TextManager").GetComponent<TextManager>();
        basket = GameObject.Find("Basket").GetComponent<Transform>();


        interactable = GetComponent<XRBaseInteractable>();
        interactable.selectEntered.AddListener(OnSelectEnteredHandler);
    }

    void OnDestroy()
    {
        // Unsubscribe from the selectExited event to avoid memory leaks
        if (interactable != null)
        {
            interactable.selectEntered.RemoveListener(OnSelectEnteredHandler);
        }
    }

    private void OnSelectEnteredHandler(SelectEnterEventArgs args)
    {
        // Reset the drop flag when the ball is regrabbed
        isBallDropped = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            // dribbling logic
            if (GameManager.instance.state == GameState.TaskOne)
            {
                if (!isBallDropped)
                {
                    // Prevents incrementing the count again for the same drop
                    isBallDropped = true;
                    currentScore++;
                }
                else
                {
                    // if ball hits ground twice without regrab, reset score to zero
                    currentScore = 0;
                }

                // Refresh score in UI
                gameManager.HandleTaskOne(currentScore, maxScore);
                textManager.TaskOneScore(currentScore, maxScore);
            }

            // basket logic
            if (GameManager.instance.state == GameState.TaskTwo && !hasLowered && basket.position.y > minHeight)
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
}
