using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.UI;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider gravitySlider;
    GravityManager gravityManager;
    TextManager textManager;

    [SerializeField] GameObject taskPanel;
    [SerializeField] GameObject returnPanel;
    [SerializeField] GameObject taskOneNext;
    [SerializeField] GameObject taskTwoNext;
    [SerializeField] GameObject taskThreeNext;
    [SerializeField] GameObject jupiterNextButton;
    [SerializeField] GameObject moonNextButton;
    [SerializeField] GameObject earthNextButton;
    [SerializeField] GameObject taskOneButton;
    [SerializeField] GameObject taskTwoButton;

    public GameObject TaskTwoButton { get { return taskTwoButton; } set { taskTwoButton = value; } }

    void Awake()
    {
        gravityManager = GameObject.Find("GravityManager").GetComponent<GravityManager>();
        textManager = GameObject.Find("TextManager").GetComponent<TextManager>();

        jupiterNextButton.SetActive(GameManager.instance.IsMoonVisitable);
        moonNextButton.SetActive(GameManager.instance.IsEarthVisitable);
        earthNextButton.SetActive(GameManager.instance.IsGameDone);

        taskOneNext.SetActive(false);
        taskTwoNext.SetActive(false);
        taskThreeNext.SetActive(false);

        taskOneButton.SetActive(true);
        taskTwoButton.SetActive(false);
    }

    void Update()
    {
        // able to visit planet after doing minigame task in ship and current gravity is set to jupiter
        if (GameManager.instance.IsPracticingCan && GameManager.instance.IsPracticingDart && gravitySlider.value == 1)
        {
            // ShowJupiterPanel();
            taskOneNext.SetActive(true);
        }

        // able to visit planet after doing task on jupiter and current gravity is set to moon
        if (GameManager.instance.IsPracticingCan && GameManager.instance.IsPracticingDart && gravitySlider.value == 2 && GameManager.instance.IsMoonVisitable)
        {
            // ShowMoonPanel();
            taskTwoNext.SetActive(true);
        }

        // able to visit planet after doing task on moon and current gravity is set to earth
        if (GameManager.instance.IsPracticingCan && GameManager.instance.IsPracticingDart && gravitySlider.value == 3 && GameManager.instance.IsEarthVisitable)
        {
            // ShowEarthPanel();
            taskThreeNext.SetActive(true);
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

    void ShowJupiterPanel()
    {
        taskOneNext.SetActive(true);
    }

    void ShowMoonPanel()
    {
        taskTwoNext.SetActive(true);
    }

    void ShowEarthPanel()
    {
        taskThreeNext.SetActive(true);
    }
}