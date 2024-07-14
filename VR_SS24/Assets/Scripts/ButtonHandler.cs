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
        AudioManager.instance.PlaySFX(AudioManager.instance.uIClick);

        // change GameState depending on button tag name
        switch (buttonTag.tag)
        {
            case "TaskOne":
                // GameManager.instance.SwitchToTaskOne();
                GameManager.instance.UpdateGameState(GameState.TaskOne);
                break;
            case "TaskTwo":
                // GameManager.instance.SwitchToTaskTwo();
                GameManager.instance.UpdateGameState(GameState.TaskTwo);
                break;
            default:
                Debug.Log("Not a task button");
                break;
        }
    }
}
