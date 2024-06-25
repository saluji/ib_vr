using System;
using UnityEngine;
public enum GravitationalForceMode { Space = 0, Earth, Moon, Jupiter }
public class GravityManager : MonoBehaviour
{
    public GravitationalForceMode CurrentGravitationalForce;
    void Start()
    {
        SetGravityMode(GravitationalForceMode.Earth);
    }
    public void SetGravityMode(GravitationalForceMode newMode)
    {
        switch (newMode)
        {
            case GravitationalForceMode.Space:
                Physics.gravity = new Vector3(0, 0, 0);
                break;
            case GravitationalForceMode.Earth:
                Physics.gravity = new Vector3(0, -9.81f, 0);
                break;
            case GravitationalForceMode.Moon:
                Physics.gravity = new Vector3(0, -1.622f, 0);
                break;
            case GravitationalForceMode.Jupiter:
                Physics.gravity = new Vector3(0, -24.79f, 0);
                break;
        }
        CurrentGravitationalForce = newMode;
    }
}
