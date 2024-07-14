using System.Collections;
using System.Collections.Generic;
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

        // store buildIndex in order to play the right music in space level
        levelManager.buildIndex = 0;
    }
}
