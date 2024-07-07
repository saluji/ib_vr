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
    bool isResetUIPositionPressed;

    void Awake()
    {
        controllerInput = new ControllerInput();
    }

    void OnEnable()
    {
        controllerInput.UIInput.Enable();
        controllerInput.UIInput.ToggleUI.performed += OnUIToggle;
        controllerInput.UIInput.ResetUIPosition.started += OnResetPosition;
    }

    void OnDisable()
    {
        controllerInput.UIInput.Disable();
        controllerInput.UIInput.ToggleUI.performed -= OnUIToggle;
    }

    void OnUIToggle(InputAction.CallbackContext context)
    {
        isUIToggled = !isUIToggled;
        menu.SetActive(isUIToggled);
    }
    void OnResetPosition(InputAction.CallbackContext context)
    {
        isUIToggled = !isUIToggled;
    }
}