using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.UI;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    PlayerInput playerInput;
    [SerializeField] Transform menuTransform;
    [SerializeField] Transform menuAnchor;
    
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
        // if (gameManager.IsPracticingCan && gameManager.IsPracticingDart)
        // if (gameManager.IsPracticingCan && gameManager.IsPracticingDart && gameManager.IsJupiterVisitable)

        // able to visit planet after doing minigame task in ship and current gravity is set on jupiter
        if (gameManager.IsPracticingCan && gameManager.IsPracticingDart && gravitySlider.value == 1)
        {
            ShowJupiterButton();
        }
        if (gameManager.IsPracticingCan && gameManager.IsPracticingDart && gravitySlider.value == 2 && gameManager.IsMoonVisitable)
        {
            ShowMoonButton();
        }
        if (gameManager.IsPracticingCan && gameManager.IsPracticingDart && gravitySlider.value == 3 && gameManager.IsEarthVisitable)
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