using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DIalogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    void Start()
    {
        textComponent.text = lines[0];
    }
    void Update()
    {
        for (int i = 0; i < lines.Length - 1; i++)
        {
            if (Input.GetKeyUp(KeyCode.E) && i != lines.Length - 1)
            {
                i++;
                NextLine(i);
            }
            if (Input.GetKeyUp(KeyCode.Q) && i != 0)
            {
                i--;
                PreviousLine(i);
            }
        }
    }
    void NextLine(int i)
    {
        textComponent.text = string.Empty;
        textComponent.text = lines[i];
    }
    void PreviousLine(int i)
    {
        textComponent.text = string.Empty;
        textComponent.text = lines[i];
    }
}
