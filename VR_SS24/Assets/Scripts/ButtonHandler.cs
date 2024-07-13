using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    Button taskButton;

    void Awake()
    {
        taskButton = GetComponent<Button>();
        taskButton.onClick.AddListener(() => OnButtonClick(taskButton));
    }

    void OnButtonClick(Button buttonTag)
    {
        // call method depending on button tag name
        switch (buttonTag.tag)
        {
            case "TaskOne":
                GameManager.instance.SwitchToTaskOne();
                break;
            case "TaskTwo":
                GameManager.instance.SwitchToTaskTwo();
                break;
            case "MoonVisitable":
                GameManager.instance.MoonVisitable();
                break;
            case "EarthVisitable":
                GameManager.instance.EarthVisitable();
                break;
            case "GameDone":
                GameManager.instance.GameDone();
                break;
            default:
                Debug.LogWarning("Unknown button tag: " + buttonTag.tag);
                break;
        }
    }
}
