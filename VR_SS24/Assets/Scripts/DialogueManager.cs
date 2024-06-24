using UnityEngine;
using TMPro;
using System.CodeDom.Compiler;
public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    private int index = 0;
    void Start()
    {
        // Set text to first line of text
        textComponent.text = string.Empty;
        textComponent.text = lines[0];
    }
    // Show next text dialogue
    public void NextText()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            textComponent.text = lines[index];
        }
    }
    // Show previous text dialogue
    public void PreviousText()
    {
        if (index > 0)
        {
            index--;
            textComponent.text = string.Empty;
            textComponent.text = lines[index];
        }
    }
}
