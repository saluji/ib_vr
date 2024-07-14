using System.Collections;
using UnityEngine;

public class ButtonPlate : MonoBehaviour
{
    float hoverCooldown = 1.0f; // Cooldown time in seconds
    private Color initialColor; // To store the initial color
    private Renderer buttonRenderer;

    private bool isCoolingDown = false; // Track if the cooldown is active

    void Awake()
    {
        buttonRenderer = GetComponent<Renderer>();

        if (buttonRenderer == null)
        {
            Debug.LogError("Renderer component is missing from this GameObject.");
            return;
        }

        // Store the initial color of the button
        initialColor = buttonRenderer.material.color;
    }

    void Update()
    {
        // Check if the Space key is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isCoolingDown)
            {
                StartCoroutine(HoverCooldownCoroutine());
            }
        }
    }

    private void HandleHoverEnter()
    {
        Debug.Log("Space key pressed over the button.");

        // Change the button's color
        buttonRenderer.material.color = Color.black;

        // Play the hover sound
        AudioManager.instance.PlaySFX(AudioManager.instance.buttonPlate);

        // Perform additional actions if needed
    }

    private void HandleHoverExit()
    {
        Debug.Log("Space key released or no longer hovering over the button.");

        // Reset the button's color to the initial color
        buttonRenderer.material.color = initialColor;

        // Perform additional actions if needed
    }

    private IEnumerator HoverCooldownCoroutine()
    {
        // Handle hover enter
        HandleHoverEnter();

        // Set cooldown flag
        isCoolingDown = true;

        // Wait for the specified cooldown time
        yield return new WaitForSeconds(hoverCooldown);

        // Reset cooldown flag
        isCoolingDown = false;

        // Handle hover exit
        HandleHoverExit();
    }
}
