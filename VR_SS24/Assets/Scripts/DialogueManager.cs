using UnityEngine;
using TMPro;
using System.CodeDom.Compiler;
public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    void Start()
    {
        textComponent.text = string.Empty;
        textComponent.text = lines[0];
    }
    void Update()
    {
        for (int index = 0; index < lines.Length - 1; index++)
        {
            if (Input.GetKeyUp(KeyCode.E) && index < lines.Length - 1)
            {
                NextText(index);
            }
            if (Input.GetKeyUp(KeyCode.Q) && index + 1 > 0)
            {
                PreviousText(index);
            }
        }
    }
    public void NextText(int index)
    {
        index++;
        textComponent.text = string.Empty;
        textComponent.text = lines[index];
    }
    public void PreviousText(int index)
    {
        index--;
        textComponent.text = string.Empty;
        textComponent.text = lines[index];
    }
}
