using UnityEngine;
using UnityEngine.XR.LegacyInputHelpers;

public class SpawnBall : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Spawn()
    {
            transform.position = spawnPoint.transform.position;
            transform.rotation = spawnPoint.transform.rotation;
    }
}
