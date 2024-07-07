using Unity.VRTemplate;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // int buildIndex;
    int buildIndex = 0;

    void Awake()
    {
        // buildIndex = SceneManager.GetActiveScene().buildIndex;
        // buildIndex = 1;
    }
    public void LoadSpace()
    {
        buildIndex = 0;
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
