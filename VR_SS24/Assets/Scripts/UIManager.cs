using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
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
    public Slider gravitySlider;

    public GameObject TaskOneButton { get { return taskOneButton; } set { taskOneButton = value; } }
    public GameObject TaskTwoButton { get { return taskTwoButton; } set { taskTwoButton = value; } }
    public GameObject TaskThreeButton { get { return taskThreeButton; } set { taskThreeButton = value; } }

    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gravityManager = GameObject.Find("GravityManager").GetComponent<GravityManager>();
        // GameManager.OnGameStateChanged += ShowButton;
    }

    // void OnDestroy()
    // {
    //     GameManager.OnGameStateChanged -= ShowButton;
    // }

    // void ShowButton(GameState state)
    // {
    //     taskTwoButton.SetActive(state == GameState.TaskTwo);
    //     taskThreeButton.SetActive(state == GameState.TaskThree);
    // }

    void Update()
    {
        // able to visit planet after doing minigame task in ship and current gravity is set to jupiter
        if (gameManager.IsPracticingCan && gameManager.IsPracticingDart && gravitySlider.value == 1)
        {
            ShowJupiterButton();
        }
        // able to visit planet after doing task on jupiter and current gravity is set to moon
        if (gameManager.IsPracticingCan && gameManager.IsPracticingDart && gravitySlider.value == 2 && gameManager.IsMoonVisitable)
        {
            ShowMoonButton();
        }
        // able to visit planet after doing task on moon and current gravity is set to earth
        if (gameManager.IsPracticingCan && gameManager.IsPracticingDart && gravitySlider.value == 3 && gameManager.IsEarthVisitable)
        {
            ShowEarthButton();
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
}