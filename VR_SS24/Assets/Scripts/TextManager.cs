using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TextManager : MonoBehaviour
{
    UIManager uIManager;
    Basketball basketball;
    [SerializeField] TextMeshProUGUI gravityTextComponent;
    [SerializeField] TextMeshProUGUI score;

    void Awake()
    {
        uIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        basketball = GameObject.Find("Basketball").GetComponent<Basketball>();
    }

    public void TaskOneScore(int currentScore, int maxScore)
    {
        score.text = string.Empty;
        score.text = currentScore + " / " + maxScore;
    }

    public void ChangeGravityText()
    {
        // change gravity text on terminal depending on slider
        gravityTextComponent.text = string.Empty;
        gravityTextComponent.text = "Gravity mode: " + ((GravitationalForceMode)uIManager.gravitySlider.value).ToString();
    }
}
