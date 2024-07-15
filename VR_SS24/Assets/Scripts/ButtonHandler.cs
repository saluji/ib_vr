using System.Collections;
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

// using UnityEngine;
// using UnityEngine.UI;
// using System.Collections;
// using System.Collections.Generic;

// public class ButtonHandler : MonoBehaviour
// {
//     Button taskButton;
//     static Dictionary<string, bool> playedButtons = new Dictionary<string, bool>();

//     void Awake()
//     {
//         taskButton = GetComponent<Button>();
//         taskButton.onClick.AddListener(() => OnButtonClick(taskButton));
//     }

//     void OnButtonClick(Button button)
//     {
//         AudioManager.instance.PlayUI(AudioManager.instance.uIClick);

//         if (button.CompareTag("TaskOne"))
//         {
//             GameManager.instance.UpdateGameState(GameState.TaskOne);
//             HandleVoiceClip(button);
//         }
//         else if (button.CompareTag("TaskTwo"))
//         {
//             GameManager.instance.UpdateGameState(GameState.TaskTwo);
//             HandleVoiceClip(button);
//         }
//         else if (button.CompareTag("VoiceClip"))
//         {
//             HandleVoiceClip(button);
//         }
//         else
//         {
//             Debug.Log("Button does not match any known tags.");
//         }
//     }

//     void HandleVoiceClip(Button button)
//     {
//         if (!playedButtons.ContainsKey(button.name) || !playedButtons[button.name])
//         {
//             PlayVoiceClip(button);
//             playedButtons[button.name] = true;

//             // After the voice clip finishes, show the associated button
//             StartCoroutine(ShowButtonAfterVoiceClip(button));
//         }
//         else
//         {
//             Debug.Log("Voice clip already played for this button.");
//         }
//     }

//     void PlayVoiceClip(Button button)
//     {
//         switch (button.tag)
//         {
//             case "TaskOne":
//                 AudioManager.instance.PlayVoice(AudioManager.instance.space01); // Example clip for TaskOne
//                 break;
//             case "TaskTwo":
//                 AudioManager.instance.PlayVoice(AudioManager.instance.space02); // Example clip for TaskTwo
//                 break;
//             case "VoiceClip":
//                 AudioClip clip = GetVoiceClipForButton(button);
//                 if (clip != null)
//                 {
//                     AudioManager.instance.PlayVoice(clip);
//                 }
//                 else
//                 {
//                     Debug.LogError("No voice clip assigned for this button.");
//                 }
//                 break;
//             default:
//                 Debug.Log("Button does not have a voice clip associated.");
//                 break;
//         }
//     }

//     IEnumerator ShowButtonAfterVoiceClip(Button button)
//     {
//         // Wait until the voice clip has finished playing
//         yield return new WaitUntil(() => !AudioManager.instance.voiceSource.isPlaying);

//         // Find the button to show
//         Button associatedButton = GetAssociatedButton(button);
//         if (associatedButton != null)
//         {
//             associatedButton.gameObject.SetActive(true);
//         }
//     }

//     Button GetAssociatedButton(Button button)
//     {
//         // Implement your logic to find the associated button to show
//         // This is an example using button names, you can modify as needed
//         string associatedButtonName = button.name + "_Associated";
//         GameObject associatedButtonObject = GameObject.Find(associatedButtonName);
//         if (associatedButtonObject != null)
//         {
//             return associatedButtonObject.GetComponent<Button>();
//         }
//         return null;
//     }

//     AudioClip GetVoiceClipForButton(Button button)
//     {
//         // Example method to get the voice clip for a specific button
//         if (button.name.Contains("Button1"))
//         {
//             return AudioManager.instance.space00;
//         }
//         else if (button.name.Contains("Button2"))
//         {
//             return AudioManager.instance.space01;
//         }
//         else if (button.name.Contains("Button3"))
//         {
//             return AudioManager.instance.space02;
//         }
//         // Add more conditions as needed
//         return null;
//     }
// }
