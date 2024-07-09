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
    int releaseCount;
    int maxCount = 5;

    public int ReleaseCount { get { return releaseCount; } set { releaseCount = value; } }

    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        uIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        textManager = GameObject.Find("TextManager").GetComponent<TextManager>();
        interactable = GetComponent<XRBaseInteractable>();
        interactable.selectExited.AddListener(OnSelectExitedHandler);
        releaseCount = 0;
    }

    void OnDestroy()
    {
        // Unsubscribe from the selectExited event to avoid memory leaks
        if (interactable != null)
        {
            interactable.selectExited.RemoveListener(OnSelectExitedHandler);
        }
    }

    public void OnSelectExitedHandler(SelectExitEventArgs args)
    {
        releaseCount++;
        switch (gameManager.state)
        {
            case GameState.TaskOne:
                if (releaseCount >= maxCount)
                {
                    uIManager.TaskOneButton.SetActive(true);
                }
                break;
            case GameState.TaskTwo:
                if (releaseCount >= maxCount)
                {
                    uIManager.TaskTwoButton.SetActive(true);
                }
                break;
            case GameState.TaskThree:
                if (releaseCount >= maxCount)
                {
                    uIManager.TaskThreeButton.SetActive(true);
                }
                break;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // show return to ship panel if in TaskFour
        if (other.gameObject.CompareTag("Basket") && gameManager.state == GameState.TaskFour)
        {
            uIManager.ShowReturnPanel();
        }
    }
}
