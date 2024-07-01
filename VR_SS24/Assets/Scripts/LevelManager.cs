using Unity.VRTemplate;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int buildIndex;
    void Awake()
    {
        // buildIndex = SceneManager.GetActiveScene().buildIndex;
        buildIndex = 1;
    }
    public void LoadSpace()
    {
        buildIndex = 0;
        LoadLevel(buildIndex);
    }
    public void LoadJupiter()
    {
        buildIndex = 1;
        LoadLevel(buildIndex);
    }
    public void LoadMoon()
    {
        buildIndex = 2;
        LoadLevel(buildIndex);
    }
    public void LoadEarth()
    {
        buildIndex = 3;
        LoadLevel(buildIndex);
    }
    void LoadLevel(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }
}
