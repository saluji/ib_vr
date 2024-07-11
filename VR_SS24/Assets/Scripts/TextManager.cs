using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TextManager : MonoBehaviour
{
    UIManager uIManager;
    Basketball basketball;
    [SerializeField] TextMeshProUGUI gravityTextComponent;
    [SerializeField] TextMeshProUGUI t1Score;
    [SerializeField] TextMeshProUGUI t2Score;

    void Awake()
    {
        uIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        basketball = GameObject.Find("Basketball").GetComponent<Basketball>();
        TaskOneScore();
        TaskTwoScore();

        // gravityTextComponent.text = string.Empty;
        // gravityTextComponent.text = "Gravity mode: Space";

        // t1Score.text = string.Empty;
        // t1Score.text = basketball.Count + " / " + basketball.MaxCount;

        // t2Score.text = string.Empty;
        // t2Score.text = basketball.Count + " / " + basketball.MaxCount;
    }

    public void TaskOneScore()
    {
        t1Score.text = string.Empty;
        t1Score.text = basketball.Count + " / " + basketball.MaxCount;
    }

    public void TaskTwoScore()
    {
        t2Score.text = string.Empty;
        t2Score.text = basketball.Count + " / " + basketball.MaxCount;
    }
    // public void TaskText(int index)
    // {
    //     taskTextComponent.text = string.Empty;
    //     if (index < 2)
    //     {
    //         taskTextComponent.text = taskText[index] + " " + basketball.Count + " / " + basketball.MaxCount;
    //     }
    //     else if (index == 2)
    //     {
    //         taskTextComponent.text = taskText[2];
    //     }
    // }

    public void ChangeGravityText()
    {
        // change gravity text on terminal depending on slider
        gravityTextComponent.text = string.Empty;
        gravityTextComponent.text = "Gravity mode: " + ((GravitationalForceMode)uIManager.gravitySlider.value).ToString();
    }
}
