using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Teleporter : MonoBehaviour
{
    LevelManager levelManager;

    void Awake()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    void OnEnable()
    {
        // Subscribe to the Select Entered event
        GetComponent<XRBaseInteractable>().selectEntered.AddListener(OnSelectEnter);
    }

    void OnDisable()
    {
        // Unsubscribe from the Select Entered event
        GetComponent<XRBaseInteractable>().selectEntered.RemoveListener(OnSelectEnter);
    }

    void OnSelectEnter(SelectEnterEventArgs args)
    {
        levelManager.LoadLevel();
    }
}
