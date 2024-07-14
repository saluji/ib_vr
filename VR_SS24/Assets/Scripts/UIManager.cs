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
    LevelManager levelManager;

    [SerializeField] GameObject taskPanel;
    [SerializeField] GameObject returnPanel;
    [SerializeField] GameObject controlPanel;
    [SerializeField] GameObject planetPanel;
    [SerializeField] GameObject jupiterPanel;
    [SerializeField] GameObject moonPanel;
    [SerializeField] GameObject earthPanel;
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
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        StartingUI();
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
        AudioManager.instance.PlaySFX(AudioManager.instance.sliderClick);
        gravityManager.SetGravityMode(mode);

        // set gravity text
        textManager.ChangeGravityText();
    }

    public void ShowReturnPanel()
    {
        taskPanel.SetActive(false);
        returnPanel.SetActive(true);
    }

    // public void StartingUI()
    // {
    //     jupiterNextButton.SetActive(GameManager.instance.IsMoonVisitable);
    //     moonNextButton.SetActive(GameManager.instance.IsEarthVisitable);
    //     earthNextButton.SetActive(GameManager.instance.IsGameDone);

    //     if (levelManager.BuildIndex == 0)
    //     {
    //         if (GameManager.instance.IsGameDone)
    //         {
    //             controlPanel.SetActive(false);
    //             planetPanel.SetActive(true);
    //             jupiterPanel.SetActive(false);
    //             moonPanel.SetActive(false);
    //             earthPanel.SetActive(true);
    //         }

    //         else if (GameManager.instance.IsEarthVisitable)
    //         {
    //             controlPanel.SetActive(false);
    //             planetPanel.SetActive(true);
    //             jupiterPanel.SetActive(false);
    //             moonPanel.SetActive(true);
    //             earthPanel.SetActive(false);
    //         }

    //         else if (GameManager.instance.IsMoonVisitable)
    //         {
    //             controlPanel.SetActive(false);
    //             planetPanel.SetActive(true);
    //             jupiterPanel.SetActive(true);
    //             moonPanel.SetActive(false);
    //             earthPanel.SetActive(false);
    //         }

    //         else
    //         {
    //             controlPanel.SetActive(true);
    //             planetPanel.SetActive(false);
    //             jupiterPanel.SetActive(false);
    //             moonPanel.SetActive(false);
    //             earthPanel.SetActive(false);
    //         }
    //     }

    //     taskOneNext.SetActive(false);
    //     taskTwoNext.SetActive(false);
    //     taskThreeNext.SetActive(false);

    //     taskOneButton.SetActive(true);
    //     taskTwoButton.SetActive(false);
    // }

    public void StartingUI()
    {
        jupiterNextButton.SetActive(GameManager.instance.IsMoonVisitable);
        moonNextButton.SetActive(GameManager.instance.IsEarthVisitable);
        earthNextButton.SetActive(GameManager.instance.IsGameDone);

        if (levelManager.BuildIndex == 0)
        {
            if (GameManager.instance.IsGameDone)
            {
                SetPanelStates(false, true, false, false, true);
            }
            else if (GameManager.instance.IsEarthVisitable)
            {
                SetPanelStates(false, true, false, true, false);
            }
            else if (GameManager.instance.IsMoonVisitable)
            {
                SetPanelStates(false, true, true, false, false);
            }
            else
            {
                SetPanelStates(true, false, true, false, false);
            }
        }

        taskOneNext.SetActive(false);
        taskTwoNext.SetActive(false);
        taskThreeNext.SetActive(false);

        taskOneButton.SetActive(true);
        taskTwoButton.SetActive(false);
    }

    private void SetPanelStates(bool control, bool planet, bool jupiter, bool moon, bool earth)
    {
        controlPanel.SetActive(control);
        planetPanel.SetActive(planet);
        jupiterPanel.SetActive(jupiter);
        moonPanel.SetActive(moon);
        earthPanel.SetActive(earth);
    }

}