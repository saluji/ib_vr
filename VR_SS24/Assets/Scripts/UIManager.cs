using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.UI;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance { get; private set; }
    GravityManager gravityManager;
    TextManager textManager;
    [SerializeField] GameObject taskPanel;
    [SerializeField] GameObject returnPanel;
    [SerializeField] GameObject jupiterButton;
    [SerializeField] GameObject moonButton;
    [SerializeField] GameObject earthButton;
    [SerializeField] GameObject taskOneButton;
    [SerializeField] GameObject taskTwoButton;
    public Slider gravitySlider;

    public GameObject TaskTwoButton { get { return taskTwoButton; } set { taskTwoButton = value; } }
    void Awake()
    {
        gravityManager = GameObject.Find("GravityManager").GetComponent<GravityManager>();
        textManager = GameObject.Find("TextManager").GetComponent<TextManager>();
        
        jupiterButton.SetActive(GameManager.instance.IsMoonVisitable ? true : false);
        moonButton.SetActive(GameManager.instance.IsEarthVisitable? true : false);
        earthButton.SetActive(GameManager.instance.IsGameDone? true : false);

        taskOneButton.SetActive(true);
        taskTwoButton.SetActive(false);
    }

    void Update()
    {
        // able to visit planet after doing minigame task in ship and current gravity is set to jupiter
        if (GameManager.instance.IsPracticingCan && GameManager.instance.IsPracticingDart && gravitySlider.value == 1)
        {
            ShowJupiterButton();
        }
        // able to visit planet after doing task on jupiter and current gravity is set to moon
        if (GameManager.instance.IsPracticingCan && GameManager.instance.IsPracticingDart && gravitySlider.value == 2 && GameManager.instance.IsMoonVisitable)
        {
            ShowMoonButton();
        }
        // able to visit planet after doing task on moon and current gravity is set to earth
        if (GameManager.instance.IsPracticingCan && GameManager.instance.IsPracticingDart && gravitySlider.value == 3 && GameManager.instance.IsEarthVisitable)
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