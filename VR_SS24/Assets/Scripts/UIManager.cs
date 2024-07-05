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
    public Slider gravitySlider;

    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gravityManager = GameObject.Find("GravityManager").GetComponent<GravityManager>();
    }

    void Update()
    {
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