using Unity.VisualScripting;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
