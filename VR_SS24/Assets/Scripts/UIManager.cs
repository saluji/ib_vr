using Unity.VisualScripting;
using UnityEngine;
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
    [SerializeField] GameObject homePanel;

    [Header("Checkmarks")]
    [SerializeField] Image[] gravityCheck;
    [SerializeField] Image[] dartCheck;
    [SerializeField] Image[] canCheck;

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

    float initialAlpha = 0.02f;
    float maxAlpha = 1f;

    public GameObject TaskTwoButton { get { return taskTwoButton; } set { taskTwoButton = value; } }

    void Awake()
    {
        gravityManager = GameObject.Find("GravityManager").GetComponent<GravityManager>();
        textManager = GameObject.Find("TextManager").GetComponent<TextManager>();
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        StartingUI();
    }

    public void Slider()
    {
        GravitationalForceMode mode = (GravitationalForceMode)gravitySlider.value;
        AudioManager.instance.PlayUI(AudioManager.instance.sliderClick);
        gravityManager.SetGravityMode(mode);
        UpdateTaskUI();

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
                SetUIStates(false, true, false, false, true, false, false, false, true, true, true, true);
            }
            else if (GameManager.instance.IsEarthVisitable)
            {
                SetUIStates(false, true, false, true, false, false, false, true, true, true, false, false);
            }
            else if (GameManager.instance.IsMoonVisitable)
            {
                SetUIStates(false, true, true, false, false, false, true, true, true, false, false, false);
            }
            else
            {
                SetUIStates(true, false, true, false, false, true, true, true, false, false, false, false);
            }
        }

        taskOneNext.SetActive(false);
        taskTwoNext.SetActive(false);
        taskThreeNext.SetActive(false);

        taskTwoButton.SetActive(false);
    }

    private void SetUIStates(bool controlMenu, bool planetMenu, bool jupiterMenu, bool moonMenu, bool earthMenu, bool jupiterTask, bool moonTask, bool earthTask, bool jupiterNextPlanet, bool moonNextPlanet, bool earthNextPlanet, bool homeMenu)
    {
        controlPanel.SetActive(controlMenu);
        planetPanel.SetActive(planetMenu);
        jupiterPanel.SetActive(jupiterMenu);
        moonPanel.SetActive(moonMenu);
        earthPanel.SetActive(earthMenu);
        homePanel.SetActive(homeMenu);

        jupiterTaskButton.SetActive(jupiterTask);
        moonTaskButton.SetActive(moonTask);
        earthTaskButton.SetActive(earthTask);

        nextPlanetJupiter.SetActive(jupiterNextPlanet);
        nextPlanetMoon.SetActive(moonNextPlanet);
        nextPlanetEarth.SetActive(earthNextPlanet);
    }

    public void UpdateTaskUI()
    {
        if (GameManager.instance.IsPracticingCan && GameManager.instance.IsPracticingDart && gravitySlider.value == 1)
        {
            taskOneNext.SetActive(true);
        }
        else if (GameManager.instance.IsPracticingCan && GameManager.instance.IsPracticingDart && gravitySlider.value == 2 && GameManager.instance.IsMoonVisitable)
        {
            taskTwoNext.SetActive(true);
        }
        else if (GameManager.instance.IsPracticingCan && GameManager.instance.IsPracticingDart && gravitySlider.value == 3 && GameManager.instance.IsEarthVisitable)
        {
            taskThreeNext.SetActive(true);
        }
        else
        {
            Debug.Log("Task not done");
        }
    }

    private void SetAlpha(Image[] images, float alpha)
    {
        foreach (Image image in images)
        {
            Color color = image.color;
            color.a = alpha;
            image.color = color;
        }
    }

    public void SetGravityAlpha()
    {
        SetAlpha(gravityCheck, maxAlpha);
    }

    public void SetDartAlpha()
    {
        SetAlpha(dartCheck, maxAlpha);
    }

    public void SetCanAlpha()
    {
        SetAlpha(canCheck, maxAlpha);
    }

    public void ResetAlpha()
    {
        SetAlpha(gravityCheck, initialAlpha);
        SetAlpha(dartCheck, initialAlpha);
        SetAlpha(canCheck, initialAlpha);
    }
}
