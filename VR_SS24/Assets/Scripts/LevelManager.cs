using Unity.VRTemplate;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int buildIndex;
    public int BuildIndex { get { return buildIndex; } set { } }
    
    void Awake()
    {
        buildIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadSpace()
    {
        buildIndex = 0;
        GameManager.instance.ResetVariables();
        SceneManager.LoadScene(buildIndex);
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

    public void LoadLevel()
    {
        SceneManager.LoadScene(buildIndex);
    }
}
