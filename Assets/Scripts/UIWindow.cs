using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIWindow : MonoBehaviour
{
    public static event Action Enabled;
    public static event Action Disabled;
    public event Action Closed;

    private InputActions _input;

    public void OnCloseWindow() 
    {
        gameObject.SetActive(false);
    }
    
    private void Awake()
    {
        _input = new InputActions();
    }

    private void OnEnable() 
    {
        Enabled?.Invoke();
        _input.UI.Escape.performed += OnEscape;
        _input.UI.Escape.Enable();
    }

    private void OnDisable() 
    {
        Disabled?.Invoke();
        Closed?.Invoke();
        _input.UI.Escape.performed -= OnEscape;
        _input.UI.Escape.Disable();
    }

    private void OnEscape(InputAction.CallbackContext context)
    {
        gameObject.SetActive(false);
    }
}