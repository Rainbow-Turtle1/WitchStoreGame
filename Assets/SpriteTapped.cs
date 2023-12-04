using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class SpriteTapped : MonoBehaviour
{public GameObject[] ToActivate;
    public GameObject[] ToDeactivate;
    public CinemachineVirtualCamera virtualCamera;

    private TouchControls touchControls;

    private void Awake()
    {
        touchControls = new TouchControls();
    }

    private void OnEnable()
    {
        touchControls.Enable();
        touchControls.Touch.TouchPress.started += ctx => CheckForSpriteTap();
    }

    private void OnDisable()
    {
        touchControls.Disable();
        touchControls.Touch.TouchPress.started -= ctx => CheckForSpriteTap();
    }

    private void CheckForSpriteTap()
    {
        Vector2 touchPosition = touchControls.Touch.TouchPosition.ReadValue<Vector2>();

        Ray ray = Camera.main.ScreenPointToRay(touchPosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        if (hit.collider != null && hit.collider.gameObject == gameObject)
        {
            OnPress();
        }
    }

    private void OnPress()
    {
        // Activate
        foreach (GameObject sprite in ToActivate)
        {
            sprite.SetActive(true);
        }

        // Deactivate 
        foreach (GameObject sprite in ToDeactivate)
        {
            sprite.SetActive(false);
        }

        
        if (virtualCamera != null)
        {
            virtualCamera.Priority = 11; 
        }
        else
        {
            Debug.LogWarning("Cinemachine Virtual Camera not specified!");
        }
    }
}
