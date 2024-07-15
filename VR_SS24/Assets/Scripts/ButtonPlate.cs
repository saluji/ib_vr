using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonPlate : MonoBehaviour
{
    XRBaseInteractable interactable;
    float hoverCooldown = 1.0f; // Cooldown time in seconds
    bool isCoolingDown = false; // Track if the cooldown is active

    void Awake()
    {
        // Initialize the interactable component
        interactable = GetComponent<XRBaseInteractable>();

        if (interactable != null)
        {
            // Subscribe to the hover enter event
            interactable.hoverEntered.AddListener(OnHoverEnter);
        }
        else
        {
            Debug.LogError("XRBaseInteractable component missing on ButtonPlate.");
        }
    }

    void OnDestroy()
    {
        // Unsubscribe from the hover enter event
        if (interactable != null)
        {
            interactable.hoverEntered.RemoveListener(OnHoverEnter);
        }
    }

    void OnHoverEnter(HoverEnterEventArgs args)
    {
        if (!isCoolingDown)
        {
            StartCoroutine(Cooldown());
            AudioManager.instance.PlayUI(AudioManager.instance.buttonPlate);
        }
    }

    IEnumerator Cooldown()
    {
        isCoolingDown = true;
        yield return new WaitForSeconds(hoverCooldown);
        isCoolingDown = false;
    }
}
