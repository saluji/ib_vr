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
    LevelManager levelManager;
    Rigidbody rb;

    // dribbling variables
    bool isBallDropped;
    int currentScore = 0;
    int maxScore = 3;

    // lower basket variables
    Transform basket;
    float lowerAmount = 0.25f;
    float minHeight = -2f;
    bool hasLowered = false;

    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        uIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        textManager = GameObject.Find("TextManager").GetComponent<TextManager>();
        basket = GameObject.Find("Basket").GetComponent<Transform>();

        // logic for the basketball to keep bouncing near the ground and stopping after certain threshold depending on planet
        rb = GetComponent<Rigidbody>();
        switch (levelManager.BuildIndex)
        {
            case 1:
                {
                    rb.sleepThreshold = Physics.bounceThreshold = 1.25f;
                    break;
                }
            case 2:
                {
                    rb.sleepThreshold = Physics.bounceThreshold = 0.001f;
                    break;
                }
            case 3:
                {
                    rb.sleepThreshold = Physics.bounceThreshold = 0.05f;
                    break;
                }
        }

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
            // dribbling score logic
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
        // show return to ship panel if succeeding to throw basketball into basket
        if (other.gameObject.CompareTag("Basket") && gameManager.state == GameState.TaskTwo)
        {
            uIManager.ShowReturnPanel();
        }
    }
}
