using UnityEngine;
using UnityEngine.InputSystem;

public class InputActionMapChanger : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;

    private InputActionMap _uiMap;
    private InputActionMap _playerMap;

    private void Start() 
    {
        _uiMap = _playerInput.actions.FindActionMap("UI");
        _playerMap = _playerInput.actions.FindActionMap("Player");
    }
    
    private void OnEnable() 
    {
        UIWindow.Enabled += OnWindowEndbled;
        UIWindow.Disabled += OnWindowDisabled;
    }

    private void OnDisable() 
    {
        UIWindow.Enabled -= OnWindowEndbled;
        UIWindow.Disabled -= OnWindowDisabled;
    }

    private void OnWindowEndbled()
    {
        _playerInput.SwitchCurrentActionMap(_uiMap.name);
    }

    private void OnWindowDisabled()
    {
        _playerInput.SwitchCurrentActionMap(_playerMap.name);
    }
    
}
