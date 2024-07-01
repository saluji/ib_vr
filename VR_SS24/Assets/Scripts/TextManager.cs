using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TextManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textComponent;
    [SerializeField] TextMeshProUGUI gravityTextComponent;
    [SerializeField] UIManager uIManager;
    public string[] text;
    public string gravityText;
    public int index;
    void Awake()
    {
        Debug.Log(uIManager.gravitySlider.value.ToString());
        // Set text to first line of text
        index = 0;
        textComponent.text = string.Empty;
        textComponent.text = text[0];

        // Initial text for gravity slider
        gravityTextComponent.text = string.Empty;
        gravityTextComponent.text = "Space";
    }
    public void NextIndex()
    {
        // Show next text and stop index if on last page
        if (index < text.Length - 1)
        {
            index++;
            ShowText();
        }
    }
    public void PreviousIndex()
    {
        // Show previous text and stop index if on first page
        if (index > 0)
        {
            index--;
            ShowText();
        }
    }
    public void ShowText()
    {
        // Show next text
        textComponent.text = string.Empty;
        textComponent.text = text[index];
    }
    public void ChangeGravityText(Slider gravitySlider)
    {
        gravityTextComponent.text = string.Empty;
        gravityTextComponent.text = uIManager.gravitySlider.value.ToString();
    }
}
