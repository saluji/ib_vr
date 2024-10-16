using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonPlate : MonoBehaviour
{
    XRBaseInteractable interactable;
    SpawnManager spawnManager;
    float hoverCooldown = 1.0f;
    bool isCoolingDown = false;
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip clip;

    void Awake()
    {
        // Initialize the interactable component
        interactable = GetComponent<XRBaseInteractable>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        source = GetComponent<AudioSource>();

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
            switch (gameObject.tag)
            {
                case "Basketball":
                    spawnManager.SpawnBasketball();
                    StartCoroutine(Cooldown());
                    source.PlayOneShot(clip);
                    break;
                case "Dart":
                    spawnManager.SpawnDart();
                    StartCoroutine(Cooldown());
                    source.PlayOneShot(clip);
                    break;
                case "Tennisball":
                    spawnManager.SpawnTennisball();
                    StartCoroutine(Cooldown());
                    source.PlayOneShot(clip);
                    break;
                default:
                    Debug.Log("No spawn button");
                    break;
            }
        }
    }

    IEnumerator Cooldown()
    {
        isCoolingDown = true;
        yield return new WaitForSeconds(hoverCooldown);
        isCoolingDown = false;
    }
}
