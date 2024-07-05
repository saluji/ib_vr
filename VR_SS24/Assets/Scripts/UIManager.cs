using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.UI;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextManager textManager;
    [SerializeField] GravityManager gravityManager;
    [SerializeField] GameObject taskPanel;
    [SerializeField] GameObject returnPanel;
    public Slider gravitySlider;

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
}