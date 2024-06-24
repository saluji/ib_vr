using System;
using UnityEngine;
public enum gravitationalForce { Space, Earth, Moon, Jupiter }
public class GravityManager : MonoBehaviour
{
    public gravitationalForce gravitationalForce;
    void Start()
    {
        switch (gravitationalForce)
        {
            case gravitationalForce.Space:
                Physics.gravity = new Vector3(0, 0, 0);
                break;
            case gravitationalForce.Earth:
                Physics.gravity = new Vector3(0, -9.81f, 0);
                break;
            case gravitationalForce.Moon:
                Physics.gravity = new Vector3(0, -1.622f, 0);
                break;
            case gravitationalForce.Jupiter:
                Physics.gravity = new Vector3(0, -24.79f, 0);
                break;
        }
    }
}
