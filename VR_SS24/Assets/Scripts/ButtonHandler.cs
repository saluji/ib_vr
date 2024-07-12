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
    Tag tag;
    Button taskButton;

    void Awake()
    {
        taskButton = GetComponent<Button>();
        taskButton.onClick.AddListener(() => OnButtonClick(tag));
    }

    void OnButtonClick(Tag newTag)
    {
        string tagString = newTag.ToString();
        if (gameObject.CompareTag(tagString))
        {
            switch (newTag)
            {
                case Tag.TaskOne:
                    GameManager.instance.SwitchToTaskOne();
                    break;
                case Tag.TaskTwo:
                    GameManager.instance.SwitchToTaskTwo();
                    break;
                case Tag.MoonVisitable:
                    GameManager.instance.MoonVisitable();
                    break;
                case Tag.EarthVisitable:
                    GameManager.instance.EarthVisitable();
                    break;
                case Tag.GameDone:
                    GameManager.instance.GameDone();
                    break;
            }
        }
    }
}
