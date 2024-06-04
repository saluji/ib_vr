using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SpawnBall : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {

    }
    //Spawn ball when pressing B || Y
    public void Spawn()
    {
        transform.position = spawnPoint.transform.position;
        transform.rotation = spawnPoint.transform.rotation;
        rb.velocity = Vector3.zero;
    }
}
