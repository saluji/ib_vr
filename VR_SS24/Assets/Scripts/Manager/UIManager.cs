using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider gravitySlider;
    private GravityManager gravityManager;
    private TextManager textManager;
    private LevelManager levelManager;

    private bool isGravitySliderTaskChanged = false;
    private float initialAlpha = 0.02f;
    private float maxAlpha = 1f;

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
        textManager.ChangeGravityText();
        if (!GameManager.instance.IsTaskZeroDone)
        {
            UpdateTaskUI();
            CheckmarkCondition();
        }
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
            jupiterVisitButton.SetActive(GameManager.instance.IsGameDone);
            moonVisitButton.SetActive(GameManager.instance.IsGameDone);
            earthVisitButton.SetActive(GameManager.instance.IsGameDone);
            homePanel.SetActive(GameManager.instance.IsGameDone);

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

    public void UpdateTaskUI()
    {
        if (GameManager.instance.IsTaskZeroDone) return;

        if (GameManager.instance.IsPracticingCan && GameManager.instance.IsPracticingDart)
        {
            if (gravitySlider.value == 1 && !GameManager.instance.IsMoonVisitable && !GameManager.instance.IsEarthVisitable)
            {
                taskOneNext.SetActive(true);
                GameManager.instance.IsTaskZeroDone = true;
            }
            else if (gravitySlider.value == 2 && GameManager.instance.IsMoonVisitable && !GameManager.instance.IsEarthVisitable)
            {
                taskTwoNext.SetActive(true);
                GameManager.instance.IsTaskZeroDone = true;
            }
            else if (gravitySlider.value == 3 && GameManager.instance.IsEarthVisitable)
            {
                taskThreeNext.SetActive(true);
                GameManager.instance.IsTaskZeroDone = true;
            }

            if (GameManager.instance.IsTaskZeroDone)
            {
                AudioManager.instance.PlayUI(AudioManager.instance.done02);
            }
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
        if (!GameManager.instance.IsTaskZeroDone)
        {
            AudioManager.instance.PlayUI(AudioManager.instance.done01);
        }
    }

    void SetGravityAlpha()
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

    void CheckmarkCondition()
    {
        if (isGravitySliderTaskChanged) return;

        bool shouldSetGravityAlpha = false;

        if (gravitySlider.value == 1 && !GameManager.instance.IsMoonVisitable && !GameManager.instance.IsEarthVisitable)
        {
            shouldSetGravityAlpha = true;
        }
        else if (gravitySlider.value == 2 && GameManager.instance.IsMoonVisitable && !GameManager.instance.IsEarthVisitable)
        {
            shouldSetGravityAlpha = true;
        }
        else if (gravitySlider.value == 3 && GameManager.instance.IsEarthVisitable)
        {
            shouldSetGravityAlpha = true;
        }

        if (shouldSetGravityAlpha)
        {
            isGravitySliderTaskChanged = true;
            SetGravityAlpha();
        }
    }
}

// using UnityEngine;
// using UnityEngine.UI;

// public class UIManager : MonoBehaviour
// {
//     public Slider gravitySlider;
//     private GravityManager gravityManager;
//     private TextManager textManager;
//     private LevelManager levelManager;

//     private bool isGravitySliderTaskChanged = false;
//     private float initialAlpha = 0.02f;
//     private float maxAlpha = 1f;

//     private bool isEarthVisitable;
//     private bool isMoonVisitable;
//     private bool isGameDone;

//     // panel variables
//     [Header("Panels")]
//     [SerializeField] GameObject taskPanel;
//     [SerializeField] GameObject returnPanel;
//     [SerializeField] GameObject controlPanel;
//     [SerializeField] GameObject planetPanel;
//     [SerializeField] GameObject jupiterPanel;
//     [SerializeField] GameObject moonPanel;
//     [SerializeField] GameObject earthPanel;
//     [SerializeField] GameObject homePanel;

//     [Header("Checkmarks")]
//     [SerializeField] Image[] gravityCheck;
//     [SerializeField] Image[] dartCheck;
//     [SerializeField] Image[] canCheck;

//     // button variables
//     [Header("Visit button")]
//     [SerializeField] GameObject jupiterVisitButton;
//     [SerializeField] GameObject moonVisitButton;
//     [SerializeField] GameObject earthVisitButton;

//     [Header("Next planet button")]
//     [SerializeField] GameObject nextPlanetJupiter;
//     [SerializeField] GameObject nextPlanetMoon;
//     [SerializeField] GameObject nextPlanetEarth;

//     [Header("Task buttons")]
//     [SerializeField] GameObject jupiterTaskButton;
//     [SerializeField] GameObject moonTaskButton;
//     [SerializeField] GameObject earthTaskButton;

//     [SerializeField] GameObject taskOneNext;
//     [SerializeField] GameObject taskTwoNext;
//     [SerializeField] GameObject taskThreeNext;

//     [SerializeField] GameObject taskTwoButton;

//     public GameObject TaskTwoButton { get { return taskTwoButton; } set { taskTwoButton = value; } }

//     void Awake()
//     {
//         gravityManager = GameObject.Find("GravityManager").GetComponent<GravityManager>();
//         textManager = GameObject.Find("TextManager").GetComponent<TextManager>();
//         levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();

//         isMoonVisitable = GameManager.instance.IsMoonVisitable;
//         isEarthVisitable = GameManager.instance.IsEarthVisitable;
//         isGameDone = GameManager.instance.IsGameDone;

//         StartingUI();
//     }

//     public void Slider()
//     {
//         GravitationalForceMode mode = (GravitationalForceMode)gravitySlider.value;
//         AudioManager.instance.PlayUI(AudioManager.instance.sliderClick);
//         gravityManager.SetGravityMode(mode);
//         textManager.ChangeGravityText();
//         if (!GameManager.instance.IsTaskZeroDone)
//         {
//             UpdateTaskUI();
//             CheckmarkCondition();
//         }
//     }

//     public void ShowReturnPanel()
//     {
//         taskPanel.SetActive(false);
//         returnPanel.SetActive(true);
//     }

//     public void StartingUI()
//     {

//         if (levelManager.BuildIndex == 0)
//         {
//             jupiterVisitButton.SetActive(isGameDone);
//             moonVisitButton.SetActive(isGameDone);
//             earthVisitButton.SetActive(isGameDone);
//             homePanel.SetActive(isGameDone);

//             SetUIStates(
//                 controlMenu: !isGameDone && !isMoonVisitable,
//                 planetMenu: true,
//                 jupiterMenu: false,
//                 moonMenu: isMoonVisitable && !isEarthVisitable,
//                 earthMenu: isEarthVisitable,
//                 jupiterTask: false,
//                 moonTask: false,
//                 earthTask: false,
//                 jupiterNextPlanet: isGameDone,
//                 moonNextPlanet: isMoonVisitable,
//                 earthNextPlanet: isEarthVisitable
//             );
//         }

//         taskOneNext.SetActive(false);
//         taskTwoNext.SetActive(false);
//         taskThreeNext.SetActive(false);

//         taskTwoButton.SetActive(false);
//     }

//     private void SetUIStates(bool controlMenu, bool planetMenu, bool jupiterMenu, bool moonMenu, bool earthMenu, bool jupiterTask, bool moonTask, bool earthTask, bool jupiterNextPlanet, bool moonNextPlanet, bool earthNextPlanet)
//     {
//         controlPanel.SetActive(controlMenu);
//         planetPanel.SetActive(planetMenu);
//         jupiterPanel.SetActive(jupiterMenu);
//         moonPanel.SetActive(moonMenu);
//         earthPanel.SetActive(earthMenu);

//         jupiterTaskButton.SetActive(jupiterTask);
//         moonTaskButton.SetActive(moonTask);
//         earthTaskButton.SetActive(earthTask);

//         nextPlanetJupiter.SetActive(jupiterNextPlanet);
//         nextPlanetMoon.SetActive(moonNextPlanet);
//         nextPlanetEarth.SetActive(earthNextPlanet);
//     }

//     public void UpdateTaskUI()
//     {
//         if (GameManager.instance.IsTaskZeroDone) return;

//         bool allTasksPracticed = GameManager.instance.IsPracticingCan && GameManager.instance.IsPracticingDart;

//         if (allTasksPracticed)
//         {
//             bool isTaskDone = false;

//             if (gravitySlider.value == 1 && !GameManager.instance.IsMoonVisitable && !GameManager.instance.IsEarthVisitable)
//             {
//                 taskOneNext.SetActive(true);
//                 isTaskDone = true;
//             }
//             else if (gravitySlider.value == 2 && GameManager.instance.IsMoonVisitable && !GameManager.instance.IsEarthVisitable)
//             {
//                 taskTwoNext.SetActive(true);
//                 isTaskDone = true;
//             }
//             else if (gravitySlider.value == 3 && GameManager.instance.IsEarthVisitable)
//             {
//                 taskThreeNext.SetActive(true);
//                 isTaskDone = true;
//             }

//             if (isTaskDone)
//             {
//                 GameManager.instance.IsTaskZeroDone = true;
//                 AudioManager.instance.PlayUI(AudioManager.instance.done02);
//             }
//         }
//     }

//     private void SetAlpha(Image[] images, float alpha)
//     {
//         foreach (Image image in images)
//         {
//             Color color = image.color;
//             color.a = alpha;
//             image.color = color;
//         }
//         if (!GameManager.instance.IsTaskZeroDone)
//         {
//             AudioManager.instance.PlayUI(AudioManager.instance.done01);
//         }
//     }

//     void SetGravityAlpha()
//     {
//         SetAlpha(gravityCheck, maxAlpha);
//     }

//     public void SetDartAlpha()
//     {
//         SetAlpha(dartCheck, maxAlpha);
//     }

//     public void SetCanAlpha()
//     {
//         SetAlpha(canCheck, maxAlpha);
//     }

//     public void ResetAlpha()
//     {
//         SetAlpha(gravityCheck, initialAlpha);
//         SetAlpha(dartCheck, initialAlpha);
//         SetAlpha(canCheck, initialAlpha);
//     }

//     void CheckmarkCondition()
//     {
//         if (isGravitySliderTaskChanged) return;

//         bool shouldSetGravityAlpha = false;

//         if (gravitySlider.value == 1 && !isMoonVisitable && !isEarthVisitable)
//         {
//             shouldSetGravityAlpha = true;
//         }
//         else if (gravitySlider.value == 2 && isMoonVisitable && !isEarthVisitable)
//         {
//             shouldSetGravityAlpha = true;
//         }
//         else if (gravitySlider.value == 3 && isEarthVisitable)
//         {
//             shouldSetGravityAlpha = true;
//         }

//         if (shouldSetGravityAlpha)
//         {
//             isGravitySliderTaskChanged = true;
//             SetGravityAlpha();
//         }
//     }
// }

// using UnityEngine;
// using UnityEngine.UI;

// public class UIManager : MonoBehaviour
// {
//     public Slider gravitySlider;
//     private GravityManager gravityManager;
//     private TextManager textManager;
//     private LevelManager levelManager;

//     private bool isGravitySliderTaskChanged = false;
//     private const float InitialAlpha = 0.02f;
//     private const float MaxAlpha = 1f;

//     private bool isEarthVisitable;
//     private bool isMoonVisitable;
//     private bool isGameDone;

//     [Header("Panels")]
//     [SerializeField] GameObject taskPanel;
//     [SerializeField] GameObject returnPanel;
//     [SerializeField] GameObject controlPanel;
//     [SerializeField] GameObject planetPanel;
//     [SerializeField] GameObject jupiterPanel;
//     [SerializeField] GameObject moonPanel;
//     [SerializeField] GameObject earthPanel;
//     [SerializeField] GameObject homePanel;

//     [Header("Checkmarks")]
//     [SerializeField] Image[] gravityCheck;
//     [SerializeField] Image[] dartCheck;
//     [SerializeField] Image[] canCheck;

//     [Header("Visit button")]
//     [SerializeField] GameObject jupiterVisitButton;
//     [SerializeField] GameObject moonVisitButton;
//     [SerializeField] GameObject earthVisitButton;

//     [Header("Next planet button")]
//     [SerializeField] GameObject nextPlanetJupiter;
//     [SerializeField] GameObject nextPlanetMoon;
//     [SerializeField] GameObject nextPlanetEarth;

//     [Header("Task buttons")]
//     [SerializeField] GameObject jupiterTaskButton;
//     [SerializeField] GameObject moonTaskButton;
//     [SerializeField] GameObject earthTaskButton;

//     [SerializeField] GameObject taskOneNext;
//     [SerializeField] GameObject taskTwoNext;
//     [SerializeField] GameObject taskThreeNext;

//     [SerializeField] GameObject taskTwoButton;

//     public GameObject TaskTwoButton { get { return taskTwoButton; } set { taskTwoButton = value; } }

//     void Awake()
//     {
//         gravityManager = GameObject.Find("GravityManager").GetComponent<GravityManager>();
//         textManager = GameObject.Find("TextManager").GetComponent<TextManager>();
//         levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();

//         isMoonVisitable = GameManager.instance.IsMoonVisitable;
//         isEarthVisitable = GameManager.instance.IsEarthVisitable;
//         isGameDone = GameManager.instance.IsGameDone;

//         InitializeUI();
//     }

//     public void Slider()
//     {
//         GravitationalForceMode mode = (GravitationalForceMode)gravitySlider.value;
//         AudioManager.instance.PlayUI(AudioManager.instance.sliderClick);
//         gravityManager.SetGravityMode(mode);
//         textManager.ChangeGravityText();

//         if (!GameManager.instance.IsTaskZeroDone)
//         {
//             UpdateTaskUI();
//             CheckmarkCondition();
//         }
//     }

//     public void ShowReturnPanel()
//     {
//         SetPanelState(taskPanel, false);
//         SetPanelState(returnPanel, true);
//     }

//     private void InitializeUI()
//     {
//         if (levelManager.BuildIndex == 0)
//         {
//             jupiterVisitButton.SetActive(isGameDone);
//             moonVisitButton.SetActive(isGameDone);
//             earthVisitButton.SetActive(isGameDone);
//             homePanel.SetActive(isGameDone);

//             SetUIStates(
//                 controlMenu: !isGameDone && !isMoonVisitable,
//                 planetMenu: true,
//                 jupiterMenu: false,
//                 moonMenu: isMoonVisitable && !isEarthVisitable,
//                 earthMenu: isEarthVisitable,
//                 jupiterTask: false,
//                 moonTask: false,
//                 earthTask: false,
//                 jupiterNextPlanet: isGameDone,
//                 moonNextPlanet: isMoonVisitable,
//                 earthNextPlanet: isEarthVisitable
//             );
//         }

//         SetPanelState(taskOneNext, false);
//         SetPanelState(taskTwoNext, false);
//         SetPanelState(taskThreeNext, false);
//         SetPanelState(taskTwoButton, false);
//     }

//     private void SetUIStates(bool controlMenu, bool planetMenu, bool jupiterMenu, bool moonMenu, bool earthMenu, bool jupiterTask, bool moonTask, bool earthTask, bool jupiterNextPlanet, bool moonNextPlanet, bool earthNextPlanet)
//     {
//         controlPanel.SetActive(controlMenu);
//         planetPanel.SetActive(planetMenu);
//         jupiterPanel.SetActive(jupiterMenu);
//         moonPanel.SetActive(moonMenu);
//         earthPanel.SetActive(earthMenu);

//         jupiterTaskButton.SetActive(jupiterTask);
//         moonTaskButton.SetActive(moonTask);
//         earthTaskButton.SetActive(earthTask);

//         nextPlanetJupiter.SetActive(jupiterNextPlanet);
//         nextPlanetMoon.SetActive(moonNextPlanet);
//         nextPlanetEarth.SetActive(earthNextPlanet);
//     }

//     public void UpdateTaskUI()
//     {
//         if (GameManager.instance.IsTaskZeroDone) return;

//         bool allTasksPracticed = GameManager.instance.IsPracticingCan && GameManager.instance.IsPracticingDart;
//         if (!allTasksPracticed) return;

//         bool isTaskDone = false;
//         switch (gravitySlider.value)
//         {
//             case 1 when !GameManager.instance.IsMoonVisitable && !GameManager.instance.IsEarthVisitable:
//                 SetPanelState(taskOneNext, true);
//                 isTaskDone = true;
//                 break;
//             case 2 when GameManager.instance.IsMoonVisitable && !GameManager.instance.IsEarthVisitable:
//                 SetPanelState(taskTwoNext, true);
//                 isTaskDone = true;
//                 break;
//             case 3 when GameManager.instance.IsEarthVisitable:
//                 SetPanelState(taskThreeNext, true);
//                 isTaskDone = true;
//                 break;
//         }

//         if (isTaskDone)
//         {
//             GameManager.instance.IsTaskZeroDone = true;
//             AudioManager.instance.PlayUI(AudioManager.instance.done02);
//         }
//     }

//     private void SetAlpha(Image[] images, float alpha)
//     {
//         foreach (Image image in images)
//         {
//             Color color = image.color;
//             color.a = alpha;
//             image.color = color;
//         }

//         if (!GameManager.instance.IsTaskZeroDone)
//         {
//             AudioManager.instance.PlayUI(AudioManager.instance.done01);
//         }
//     }

//     private void CheckmarkCondition()
//     {
//         if (isGravitySliderTaskChanged) return;

//         bool shouldSetGravityAlpha = gravitySlider.value switch
//         {
//             1 when !isMoonVisitable && !isEarthVisitable => true,
//             2 when isMoonVisitable && !isEarthVisitable => true,
//             3 when isEarthVisitable => true,
//             _ => false
//         };

//         if (shouldSetGravityAlpha)
//         {
//             isGravitySliderTaskChanged = true;
//             SetAlpha(gravityCheck, MaxAlpha);
//         }
//     }

//     private void SetPanelState(GameObject panel, bool state)
//     {
//         panel.SetActive(state);
//     }
// }

// using UnityEngine;
// using UnityEngine.UI;

// public class UIManager : MonoBehaviour
// {
//     public Slider gravitySlider;
//     private GravityManager gravityManager;
//     private TextManager textManager;
//     private LevelManager levelManager;

//     private bool isGravitySliderTaskChanged = false;
//     private const float InitialAlpha = 0.02f;
//     private const float MaxAlpha = 1f;

//     private bool isEarthVisitable;
//     private bool isMoonVisitable;
//     private bool isGameDone;

//     [Header("Panels")]
//     [SerializeField] GameObject taskPanel;
//     [SerializeField] GameObject returnPanel;
//     [SerializeField] GameObject controlPanel;
//     [SerializeField] GameObject planetPanel;
//     [SerializeField] GameObject jupiterPanel;
//     [SerializeField] GameObject moonPanel;
//     [SerializeField] GameObject earthPanel;
//     [SerializeField] GameObject homePanel;

//     [Header("Checkmarks")]
//     [SerializeField] Image[] gravityCheck;
//     [SerializeField] Image[] dartCheck;
//     [SerializeField] Image[] canCheck;

//     [Header("Visit button")]
//     [SerializeField] GameObject jupiterVisitButton;
//     [SerializeField] GameObject moonVisitButton;
//     [SerializeField] GameObject earthVisitButton;

//     [Header("Next planet button")]
//     [SerializeField] GameObject nextPlanetJupiter;
//     [SerializeField] GameObject nextPlanetMoon;
//     [SerializeField] GameObject nextPlanetEarth;

//     [Header("Task buttons")]
//     [SerializeField] GameObject jupiterTaskButton;
//     [SerializeField] GameObject moonTaskButton;
//     [SerializeField] GameObject earthTaskButton;

//     [SerializeField] GameObject taskOneNext;
//     [SerializeField] GameObject taskTwoNext;
//     [SerializeField] GameObject taskThreeNext;

//     [SerializeField] GameObject taskTwoButton;

//     public GameObject TaskTwoButton { get { return taskTwoButton; } set { taskTwoButton = value; } }

//     void Awake()
//     {
//         gravityManager = GameObject.Find("GravityManager").GetComponent<GravityManager>();
//         textManager = GameObject.Find("TextManager").GetComponent<TextManager>();
//         levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();

//         isMoonVisitable = GameManager.instance.IsMoonVisitable;
//         isEarthVisitable = GameManager.instance.IsEarthVisitable;
//         isGameDone = GameManager.instance.IsGameDone;

//         InitializeUI();
//     }

//     public void Slider()
//     {
//         GravitationalForceMode mode = (GravitationalForceMode)gravitySlider.value;
//         AudioManager.instance.PlayUI(AudioManager.instance.sliderClick);
//         gravityManager.SetGravityMode(mode);
//         textManager.ChangeGravityText();

//         if (!GameManager.instance.IsTaskZeroDone)
//         {
//             UpdateTaskUI();
//             CheckmarkCondition();
//         }
//     }

//     public void ShowReturnPanel()
//     {
//         SetPanelState(taskPanel, false);
//         SetPanelState(returnPanel, true);
//     }

//     private void InitializeUI()
//     {
//         if (levelManager.BuildIndex == 0)
//         {
//             jupiterVisitButton.SetActive(isGameDone);
//             moonVisitButton.SetActive(isGameDone);
//             earthVisitButton.SetActive(isGameDone);
//             homePanel.SetActive(isGameDone);

//             SetUIStates(
//                 controlMenu: !isGameDone && !isMoonVisitable,
//                 planetMenu: true,
//                 jupiterMenu: false,
//                 moonMenu: isMoonVisitable && !isEarthVisitable,
//                 earthMenu: isEarthVisitable,
//                 jupiterTask: false,
//                 moonTask: false,
//                 earthTask: false,
//                 jupiterNextPlanet: isGameDone,
//                 moonNextPlanet: isMoonVisitable,
//                 earthNextPlanet: isEarthVisitable
//             );
//         }

//         SetPanelState(taskOneNext, false);
//         SetPanelState(taskTwoNext, false);
//         SetPanelState(taskThreeNext, false);
//         SetPanelState(taskTwoButton, false);
//     }

//     private void SetUIStates(bool controlMenu, bool planetMenu, bool jupiterMenu, bool moonMenu, bool earthMenu, bool jupiterTask, bool moonTask, bool earthTask, bool jupiterNextPlanet, bool moonNextPlanet, bool earthNextPlanet)
//     {
//         controlPanel.SetActive(controlMenu);
//         planetPanel.SetActive(planetMenu);
//         jupiterPanel.SetActive(jupiterMenu);
//         moonPanel.SetActive(moonMenu);
//         earthPanel.SetActive(earthMenu);

//         jupiterTaskButton.SetActive(jupiterTask);
//         moonTaskButton.SetActive(moonTask);
//         earthTaskButton.SetActive(earthTask);

//         nextPlanetJupiter.SetActive(jupiterNextPlanet);
//         nextPlanetMoon.SetActive(moonNextPlanet);
//         nextPlanetEarth.SetActive(earthNextPlanet);
//     }

//     public void UpdateTaskUI()
//     {
//         if (GameManager.instance.IsTaskZeroDone) return;

//         if (GameManager.instance.IsPracticingCan && GameManager.instance.IsPracticingDart)
//         {
//             bool isTaskDone = false;

//             if (gravitySlider.value == 1 && !isMoonVisitable && !isEarthVisitable)
//             {
//                 SetPanelState(taskOneNext, true);
//                 isTaskDone = true;
//             }
//             else if (gravitySlider.value == 2 && isMoonVisitable && !isEarthVisitable)
//             {
//                 SetPanelState(taskTwoNext, true);
//                 isTaskDone = true;
//             }
//             else if (gravitySlider.value == 3 && isEarthVisitable)
//             {
//                 SetPanelState(taskThreeNext, true);
//                 isTaskDone = true;
//             }

//             if (isTaskDone)
//             {
//                 GameManager.instance.IsTaskZeroDone = true;
//                 AudioManager.instance.PlayUI(AudioManager.instance.done02);
//             }
//         }
//     }

//     private void SetAlpha(Image[] images, float alpha)
//     {
//         foreach (Image image in images)
//         {
//             Color color = image.color;
//             color.a = alpha;
//             image.color = color;
//         }
//         if (!GameManager.instance.IsTaskZeroDone)
//         {
//             AudioManager.instance.PlayUI(AudioManager.instance.done01);
//         }
//     }

//     private void CheckmarkCondition()
//     {
//         if (isGravitySliderTaskChanged) return;

//         bool shouldSetGravityAlpha = false;

//         if (gravitySlider.value == 1 && !isMoonVisitable && !isEarthVisitable)
//         {
//             shouldSetGravityAlpha = true;
//         }
//         else if (gravitySlider.value == 2 && isMoonVisitable && !isEarthVisitable)
//         {
//             shouldSetGravityAlpha = true;
//         }
//         else if (gravitySlider.value == 3 && isEarthVisitable)
//         {
//             shouldSetGravityAlpha = true;
//         }

//         if (shouldSetGravityAlpha)
//         {
//             isGravitySliderTaskChanged = true;
//             SetAlpha(gravityCheck, MaxAlpha);
//         }
//     }

//     public void ResetAlpha()
//     {
//         SetAlpha(gravityCheck, InitialAlpha);
//         SetAlpha(dartCheck, InitialAlpha);
//         SetAlpha(canCheck, InitialAlpha);
//     }

//     private void SetPanelState(GameObject panel, bool state)
//     {
//         panel.SetActive(state);
//     }
// }
