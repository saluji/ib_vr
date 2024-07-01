using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextManager textManager;
    [SerializeField] GravityManager gravityManager;
    [SerializeField] Button nextButton;
    [SerializeField] Button previousButton;
    public Slider gravitySlider;

    void Start()
    {
        previousButton.gameObject.SetActive(false);
    }
    public void ShowButton()
    {
        previousButton.gameObject.SetActive((textManager.index > 0) ? true : false);
        nextButton.gameObject.SetActive((textManager.index < textManager.text.Length - 1) ? true : false);
    }
    public void Slider()
    {
        GravitationalForceMode mode = (GravitationalForceMode)gravitySlider.value;
        gravityManager.SetGravityMode(mode);

        // set gravity text from enum int string
        // textManager.gravityTextComponent.text = string.Empty;
        // textManager.gravityTextComponent.text = text[gravitySlider.value.ToString()];
        // textManager.gravityText = gravitySlider.value.ToString();
        textManager.ChangeGravityText(gravitySlider);
    }
}