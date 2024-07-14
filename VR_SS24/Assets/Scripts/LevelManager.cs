using Unity.VRTemplate;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    UIManager uIManager;
    int buildIndex;
    int initialBuildIndex;
    public int BuildIndex { get { return buildIndex; } set { buildIndex = value; } }

    void Awake()
    {
        uIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        initialBuildIndex = buildIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadSpace()
    {
        SetBuildIndex(0);
        LoadLevel();
    }

    public void SetBuildIndex(int index)
    {
        buildIndex = index;
    }

    public void LoadLevel()
    {
        if (initialBuildIndex == 0)
        {
            uIManager.ResetAlpha();
        }

        GameManager.instance.ResetVariables();
        SceneManager.LoadScene(buildIndex);
        AudioManager.instance.SetBeginningAudio();
    }
}
