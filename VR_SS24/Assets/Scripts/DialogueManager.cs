using UnityEngine;
using TMPro;
public class DialogueManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textComponent;
    public string[] lines;
    public int index;
    void Start()
    {
        // Set text to first line of text
        index = 0;
        textComponent.text = string.Empty;
        textComponent.text = lines[0];
    }
    public void NextText()
    {
        // Show next text and stop index if on last page
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            textComponent.text = lines[index];
        }
    }
    public void PreviousText()
    {
        // Show previous text and stop index if on first page
        if (index > 0)
        {
            index--;
            textComponent.text = string.Empty;
            textComponent.text = lines[index];
        }
    }
}
