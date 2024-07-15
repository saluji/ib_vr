using UnityEngine;

public class Delete : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        Destroy(other.gameObject);
    }
}
