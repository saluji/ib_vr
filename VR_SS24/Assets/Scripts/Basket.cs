using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    [SerializeField] float lowerAmount = 0.25f;
    [SerializeField] float minHeight = 3f;

    Basketball basketball;
    Vector3 initialBallPosition;

    float groundLevelY = 0f;
    bool hasLowered = false;

    void Awake()
    {
        basketball = FindObjectOfType<Basketball>();
        if (basketball != null)
        {
            initialBallPosition = basketball.transform.position;
        }
    }

    void Update()
    {
        // Ensure that we only check for ground collisions and lower the basket during TaskThree
        if (GameManager.instance.state == GameState.TaskThree)
        {
            // Check if thebasketball has hit the ground and if the height threshold condition is met
            if (basketball != null && basketball.transform.position.y < minHeight && basketball.transform.position.y < initialBallPosition.y)
            {
                // Only lower the basket if the condition is met and it hasn't been lowered already
                if (!hasLowered)
                {
                    hasLowered = true;
                    // Lower the basket and clamp to ground level
                    transform.position = new Vector3(transform.position.x, Mathf.Max(transform.position.y - lowerAmount, groundLevelY), transform.position.z);
                    initialBallPosition = basketball.transform.position;  // Update the initialbasketball position
                }
            }
        }
    }

    // if (GameManager.instance.state == GameState.TaskThree)
    // {
    //     RaycastHit hit;
    //     // if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity)&& hit.collider.CompareTag("Ground") && !hasLowered)
    //     if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity))
    //     {
    //         if (hit.collider.CompareTag("Ground"))
    //         {
    //             // Lower the basketball only once for each basketball
    //             if (!hasLowered)
    //             {
    //                 hasLowered = true;
    //                 transform.position -= new Vector3(0, dropAmount, 0);
    //             }
    //         }
    //     }
    // }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Basketball"))
        {
            Debug.Log("Basketball hit the basket.");
            if (GameManager.instance.state == GameState.TaskThree)
            {
                Debug.Log("GameState is TaskThree.");
                if (transform.position.y > minHeight)
                {
                    LowerBasket();
                    Debug.Log("Lowering the basket.");
                }
            }
        }
    }

    public void LowerBasket()
    {
        if (hasLowered)
        {
            // Move the basket down
            transform.position -= new Vector3(0, lowerAmount, 0);

            // Ensure the basket doesn't go below the minimum height
            if (transform.position.y < minHeight)
            {
                transform.position = new Vector3(transform.position.x, minHeight, transform.position.z);
            }

            // Reset the flag
            hasLowered = false;
        }
    }

    public void ResetLowerFlag()
    {
        hasLowered = false;
    }
}
