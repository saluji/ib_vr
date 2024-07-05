using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.UI;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    GameManager gameManager;
    GravityManager gravityManager;
    [SerializeField] TextManager textManager;
    [SerializeField] GameObject taskPanel;
    [SerializeField] GameObject returnPanel;
    [SerializeField] GameObject jupiterButton;
    [SerializeField] GameObject moonButton;
    [SerializeField] GameObject earthButton;
    [SerializeField] GameObject taskOneButton;
    [SerializeField] GameObject taskTwoButton;
    [SerializeField] GameObject taskThreeButton;
    [SerializeField] GameObject taskFourButton;
    public Slider gravitySlider;

    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gravityManager = GameObject.Find("GravityManager").GetComponent<GravityManager>();
    }

    void Update()
    {
        // able to visit planet after doing minigame task in ship
        if (gameManager.IsPracticingCan && gameManager.IsPracticingDart)
        {
            ShowJupiterButton();
        }
        if (gameManager.IsPracticingCan && gameManager.IsPracticingDart && gameManager.IsMoonVisitable)
        {
            ShowMoonButton();
        }
        if (gameManager.IsPracticingCan && gameManager.IsPracticingDart && gameManager.IsEarthVisitable)
        {
            ShowEarthButton();
        }
        if (gameManager.TaskOneCounter == 3)
        {
            ShowTaskTwoButton();
        }
        if (gameManager.TaskTwoCounter == 3)
        {
            ShowTaskThreeButton();
        }
        if (gameManager.TaskThreeCounter == 3)
        {
            ShowTaskFourButton();
        }
    }

    public void Slider()
    {
        GravitationalForceMode mode = (GravitationalForceMode)gravitySlider.value;
        gravityManager.SetGravityMode(mode);

        // set gravity text
        textManager.ChangeGravityText();
    }

    public void ShowReturnPanel()
    {
        taskPanel.SetActive(false);
        returnPanel.SetActive(true);
    }
    void ShowJupiterButton()
    {
        jupiterButton.SetActive(true);
    }
    void ShowMoonButton()
    {
        moonButton.SetActive(true);
    }
    void ShowEarthButton()
    {
        earthButton.SetActive(true);
    }
    void ShowTaskTwoButton()
    {
        taskTwoButton.SetActive(true);
    }
    void ShowTaskThreeButton()
    {
        taskThreeButton.SetActive(true);
    }
    void ShowTaskFourButton()
    {
        taskFourButton.SetActive(true);
    }
}