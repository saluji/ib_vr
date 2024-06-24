using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] DialogueManager dialogueScript;
    [SerializeField] Button nextButton;
    [SerializeField] Button previousButton;
    void Start()
    {
        previousButton.gameObject.SetActive(false);
    }
    void Update()
    {

    }
}
