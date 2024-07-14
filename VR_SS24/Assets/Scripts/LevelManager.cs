using Unity.VRTemplate;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    UIManager uIManager;
    public int buildIndex;
    public int BuildIndex { get { return buildIndex; } set { buildIndex = value; } }

    void Awake()
    {
        uIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        buildIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadSpace()
    {
        buildIndex = 0;
        LoadLevel();
    }

    public void SetJupiter()
    {
        buildIndex = 1;
    }

    public void SetMoon()
    {
        buildIndex = 2;
    }

    public void SetEarth()
    {
        buildIndex = 3;
    }

    public void SetHome()
    {
        buildIndex = 4;
    }

    public void LoadLevel()
    {
        uIManager.ResetAlpha();
        GameManager.instance.ResetVariables();
        SceneManager.LoadScene(buildIndex);
        AudioManager.instance.SetBeginningAudio();
    }
}
