using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    ControllerInput controllerInput;
    [SerializeField] GameObject menu;
    [SerializeField] Transform menuAnchor;
    bool isUIToggled;

    void Awake()
    {
        controllerInput = new ControllerInput();
        isUIToggled = true;
    }

    void OnEnable()
    {
        controllerInput.UIInput.Enable();
        controllerInput.UIInput.ToggleUI.performed += OnUIToggle;
        controllerInput.UIInput.ResetUIPosition.started += OnResetUIPosition;
    }

    void OnDisable()
    {
        controllerInput.UIInput.Disable();
        controllerInput.UIInput.ToggleUI.performed -= OnUIToggle;
    }

    void OnUIToggle(InputAction.CallbackContext context)
    {
        // toggle menu on / off and reset position to in front of camera
        isUIToggled = !isUIToggled;
        menu.SetActive(isUIToggled);
        if (isUIToggled)
        {
            menu.transform.position = menuAnchor.transform.position;
            menu.transform.rotation = menuAnchor.transform.rotation;
        }
    }

    void OnResetUIPosition(InputAction.CallbackContext context)
    {
        // reset position to in front of camera
        menu.transform.position = menuAnchor.transform.position;
        menu.transform.rotation = menuAnchor.transform.rotation;
    }
}