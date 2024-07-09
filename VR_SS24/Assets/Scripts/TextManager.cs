using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TextManager : MonoBehaviour
{
    UIManager uIManager;
    [SerializeField] TextMeshProUGUI gravityTextComponent;
    void Awake()
    {
        uIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        gravityTextComponent.text = string.Empty;
        gravityTextComponent.text = "Gravity mode: Space";
    }
    public void ChangeGravityText()
    {
        // change gravity text on terminal depending on slider
        gravityTextComponent.text = string.Empty;
        gravityTextComponent.text = "Gravity mode: " + ((GravitationalForceMode)uIManager.gravitySlider.value).ToString();
    }
}
