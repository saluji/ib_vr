using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Can : MonoBehaviour
{
    public Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }
    private void OnCollisionEnter()
    {
        rb.isKinematic = false;
    }
    private void OnTriggerEnter()
    {
        rb.isKinematic = false;
    }
}