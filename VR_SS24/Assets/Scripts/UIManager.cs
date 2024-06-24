using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [SerializeField] DialogueManager dialogueScript;
    [SerializeField] Button nextButton;
    [SerializeField] Button previousButton;
    void Start()
    {
        previousButton.gameObject.SetActive(false);
    }
    public void ShowButton()
    {
        previousButton.gameObject.SetActive((dialogueScript.index > 0) ? true : false);
        nextButton.gameObject.SetActive((dialogueScript.index < dialogueScript.lines.Length - 1) ? true : false);
    }
    /*public void ShowPreviousButton()
    {
        // Don't show previous button when on first page
        //previousButton.gameObject.SetActive((dialogueScript.index > 0) ? true : false);
        if (dialogueScript.index > 0)
        {
            previousButton.gameObject.SetActive(true);
        }
        else
        {
            previousButton.gameObject.SetActive(false);
        }
    }
    public void ShowNextButton()
    {
        // Don't show next button when on first page
        nextButton.gameObject.SetActive((dialogueScript.index < dialogueScript.lines.Length - 1) ? true : false);
    }*/
}