using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public enum Tag
{
    TaskOne,
    TaskTwo,
    MoonVisitable,
    EarthVisitable,
    GameDone
}

public class ButtonHandler : MonoBehaviour
{
    // Tag buttonTag;
    string buttonTag;
    Button taskButton;

    void Awake()
    {
        taskButton = GetComponent<Button>();
        taskButton.onClick.AddListener(() => OnButtonClick(taskButton));
        // taskButton.onClick.AddListener(() => OnButtonClick(buttonTag));
        // taskButton.onClick.AddListener(OnButtonClick);
    }
    // void OnButtonClick()
    // {
    //     string tagString = 
    //     switch()
    // }
    // void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.Space)) // Example key
    //     {
    //         Debug.Log("Switching to Task Two");
    //         GameManager.instance.SwitchToTaskTwo();
    //     }
    // }

    void OnButtonClick(Button buttonTag)
    {
        switch (buttonTag.tag)
        {
            case "TaskOne":
                Debug.Log("Switching to Task One");
                GameManager.instance.SwitchToTaskOne();
                break;
            case "TaskTwo":
                Debug.Log("Switching to Task Two");
                GameManager.instance.SwitchToTaskTwo();
                break;
            case "MoonVisitable":
                Debug.Log("Switching to Moon Visitable");
                GameManager.instance.MoonVisitable();
                break;
            case "EarthVisitable":
                Debug.Log("Switching to Earth Visitable");
                GameManager.instance.EarthVisitable();
                break;
            case "GameDone":
                Debug.Log("Switching to Game Done");
                GameManager.instance.GameDone();
                break;
            default:
                Debug.LogWarning("Unknown button tag: " + buttonTag.tag);
                break;
        }
    }

    // void OnButtonClick()
    // {
    //     Debug.Log($"Button clicked with assigned tag: {buttonTag}");

    //     switch (buttonTag)
    //     {
    //         case "TaskOne":
    //             Debug.Log("Switching to Task One");
    //             GameManager.instance.SwitchToTaskOne();
    //             break;
    //         case "TaskTwo":
    //             Debug.Log("Switching to Task Two");
    //             GameManager.instance.SwitchToTaskTwo();
    //             break;
    //         case "MoonVisitable":
    //             Debug.Log("Switching to Moon Visitable");
    //             GameManager.instance.MoonVisitable();
    //             break;
    //         case "EarthVisitable":
    //             Debug.Log("Switching to Earth Visitable");
    //             GameManager.instance.EarthVisitable();
    //             break;
    //         case "GameDone":
    //             Debug.Log("Switching to Game Done");
    //             GameManager.instance.GameDone();
    //             break;
    //         default:
    //             Debug.LogError($"Unhandled tag case: {buttonTag}");
    //             break;
    //     }
    // }

    // void OnButtonClick()
    // {
    //     string newTag = gameObject.CompareTag(buttonTag).ToString();
    //     switch (newTag)
    //     {
    //         case "TaskOne":
    //             Debug.Log("Switching to Task One");
    //             GameManager.instance.SwitchToTaskOne();
    //             break;
    //         case "TaskTwo":
    //             Debug.Log("Switching to Task Two");
    //             GameManager.instance.SwitchToTaskTwo();
    //             break;
    //     }
    // }

    // void OnButtonClick()
    // {
    //     Debug.Log($"Button clicked with tag: {buttonTag}"); // Debug log to check the tag

    //     switch (buttonTag)
    //     {
    //         case Tag.TaskOne:
    //             Debug.Log("Switching to Task One");
    //             GameManager.instance.SwitchToTaskOne();
    //             break;
    //         case Tag.TaskTwo:
    //             Debug.Log("Switching to Task Two");
    //             GameManager.instance.SwitchToTaskTwo();
    //             break;
    //         case Tag.MoonVisitable:
    //             Debug.Log("Switching to Moon Visitable");
    //             GameManager.instance.MoonVisitable();
    //             break;
    //         case Tag.EarthVisitable:
    //             Debug.Log("Switching to Earth Visitable");
    //             GameManager.instance.EarthVisitable();
    //             break;
    //         case Tag.GameDone:
    //             Debug.Log("Switching to Game Done");
    //             GameManager.instance.GameDone();
    //             break;
    //         default:
    //             Debug.LogError("Unhandled tag case");
    //             break;
    //     }

    // void OnButtonClick(Tag newTag)
    // {
    //     Debug.Log($"Button clicked with tag: {buttonTag}");
    //     string tagString = newTag.ToString();
    //     if (gameObject.CompareTag(tagString))
    //     {
    //         switch (newTag)
    //         {
    //             case Tag.TaskOne:
    //                 Debug.Log("Switching to Task One");
    //                 GameManager.instance.SwitchToTaskOne();
    //                 break;
    //             case Tag.TaskTwo:
    //                 Debug.Log("Switching to Task Two");
    //                 GameManager.instance.SwitchToTaskTwo();
    //                 break;
    //             case Tag.MoonVisitable:
    //                 Debug.Log("Switching to Moon Visitable");
    //                 GameManager.instance.MoonVisitable();
    //                 break;
    //             case Tag.EarthVisitable:
    //                 Debug.Log("Switching to Earth Visitable");
    //                 GameManager.instance.EarthVisitable();
    //                 break;
    //             case Tag.GameDone:
    //                 Debug.Log("Switching to Game Done");
    //                 GameManager.instance.GameDone();
    //                 break;
    //         }
    //     }
    // }
    // void OnButtonClick(Tag newTag)
    // {
    //     Debug.Log($"Button clicked with tag: {buttonTag}");
    //     string tagString = newTag.ToString();
    //     if (gameObject.CompareTag(tagString))
    //     {
    //         switch (newTag)
    //         {
    //             case Tag.TaskOne:
    //                 Debug.Log("Switching to Task One");
    //                 GameManager.instance.SwitchToTaskOne();
    //                 break;
    //             case Tag.TaskTwo:
    //                 Debug.Log("Switching to Task Two");
    //                 GameManager.instance.SwitchToTaskTwo();
    //                 break;
    //             case Tag.MoonVisitable:
    //                 Debug.Log("Switching to Moon Visitable");
    //                 GameManager.instance.MoonVisitable();
    //                 break;
    //             case Tag.EarthVisitable:
    //                 Debug.Log("Switching to Earth Visitable");
    //                 GameManager.instance.EarthVisitable();
    //                 break;
    //             case Tag.GameDone:
    //                 Debug.Log("Switching to Game Done");
    //                 GameManager.instance.GameDone();
    //                 break;
    //         }
    //     }
    // }
}
