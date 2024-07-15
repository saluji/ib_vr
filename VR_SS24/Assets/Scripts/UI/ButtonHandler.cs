using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    Button taskButton;
    Dictionary<string, bool> voiceClipPlayed;

    void Awake()
    {
        taskButton = GetComponent<Button>();
        taskButton.onClick.AddListener(() => OnButtonClick(taskButton));
        voiceClipPlayed = new Dictionary<string, bool>();
    }

    void OnButtonClick(Button buttonTag)
    {
        AudioManager.instance.PlayUI(AudioManager.instance.uIClick);

        // Check the button's tag to determine the action
        switch (buttonTag.tag)
        {
            case "TaskOne":
                GameManager.instance.UpdateGameState(GameState.TaskOne);
                PlayVoiceIfNotPlayed("TaskOne");
                break;
            case "TaskTwo":
                GameManager.instance.UpdateGameState(GameState.TaskTwo);
                PlayVoiceIfNotPlayed("TaskTwo");
                break;
            case "VoiceClip":
                PlayVoiceIfNotPlayed("VoiceClip");
                break;
            default:
                Debug.Log("Unassigned tag");
                break;
        }
    }

    void PlayVoiceIfNotPlayed(string tag)
    {
        // only play voice lines once
        if (!voiceClipPlayed.ContainsKey(tag))
        {
            // Call PlayVoice from AudioManager
            AudioManager.instance.PlayVoice();

            // Mark this button's tag as played
            if (!voiceClipPlayed.ContainsKey(tag))
            {
                voiceClipPlayed.Add(tag, true);
            }
        }
    }
}