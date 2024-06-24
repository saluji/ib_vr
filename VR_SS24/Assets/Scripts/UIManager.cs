using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [SerializeField] TextManager textScript;
    [SerializeField] Button nextButton;
    [SerializeField] Button previousButton;
    void Start()
    {
        previousButton.gameObject.SetActive(false);
    }
    public void ShowButton()
    {
        previousButton.gameObject.SetActive((textScript.index > 0) ? true : false);
        nextButton.gameObject.SetActive((textScript.index < textScript.text.Length - 1) ? true : false);
    }
}