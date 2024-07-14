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

    // panel variables
    [Header("Panels")]
    [SerializeField] GameObject taskPanel;
    [SerializeField] GameObject returnPanel;
    [SerializeField] GameObject controlPanel;
    [SerializeField] GameObject planetPanel;
    [SerializeField] GameObject jupiterPanel;
    [SerializeField] GameObject moonPanel;
    [SerializeField] GameObject earthPanel;

    // button variables
    [Header("Visit button")]
    [SerializeField] GameObject jupiterVisitButton;
    [SerializeField] GameObject moonVisitButton;
    [SerializeField] GameObject earthVisitButton;

    [Header("Next planet button")]
    [SerializeField] GameObject nextPlanetJupiter;
    [SerializeField] GameObject nextPlanetMoon;
    [SerializeField] GameObject nextPlanetEarth;

    [Header("Task buttons")]
    [SerializeField] GameObject jupiterTaskButton;
    [SerializeField] GameObject moonTaskButton;
    [SerializeField] GameObject earthTaskButton;

    [SerializeField] GameObject taskOneNext;
    [SerializeField] GameObject taskTwoNext;
    [SerializeField] GameObject taskThreeNext;

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

    public void StartingUI()
    {
        // turn UI in spaceship level on / off depending on conditions

        if (levelManager.BuildIndex == 0)
        {
            jupiterVisitButton.SetActive(GameManager.instance.IsMoonVisitable);
            moonVisitButton.SetActive(GameManager.instance.IsEarthVisitable);
            earthVisitButton.SetActive(GameManager.instance.IsGameDone);
            
            if (GameManager.instance.IsGameDone)
            {
                SetUIStates(false, true, false, false, true, false, false, false, true, true, true);
            }
            else if (GameManager.instance.IsEarthVisitable)
            {
                SetUIStates(false, true, false, true, false, false, false, true, true, true, false);
            }
            else if (GameManager.instance.IsMoonVisitable)
            {
                SetUIStates(false, true, true, false, false, false, true, true, true, false, false);
            }
            else
            {
                SetUIStates(true, false, true, false, false, true, true, true, false, false, false);
            }
        }

        taskOneNext.SetActive(false);
        taskTwoNext.SetActive(false);
        taskThreeNext.SetActive(false);

        taskTwoButton.SetActive(false);
    }

    private void SetUIStates(bool controlMenu, bool planetMenu, bool jupiterMenu, bool moonMenu, bool earthMenu, bool jupiterTask, bool moonTask, bool earthTask, bool jupiterNextPlanet, bool moonNextPlanet, bool earthNextPlanet)
    {
        controlPanel.SetActive(controlMenu);
        planetPanel.SetActive(planetMenu);
        jupiterPanel.SetActive(jupiterMenu);
        moonPanel.SetActive(moonMenu);
        earthPanel.SetActive(earthMenu);

        jupiterTaskButton.SetActive(jupiterTask);
        moonTaskButton.SetActive(moonTask);
        earthTaskButton.SetActive(earthTask);

        nextPlanetJupiter.SetActive(jupiterNextPlanet);
        nextPlanetMoon.SetActive(moonNextPlanet);
        nextPlanetEarth.SetActive(earthNextPlanet);
    }

}