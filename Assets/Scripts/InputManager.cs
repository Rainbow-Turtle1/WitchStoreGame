using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private TouchControls touchControls;

    [SerializeField] private Transform MoveTargetTransform; // Assuming MoveTargetTransform is a 2D Transform
    private Camera mainCamera; // Reference to the camera for converting screen to world coordinates
    [SerializeField] private Animator moveTargetAnimator; // Reference to the Animator component

    private void Awake()
    {
        touchControls = new TouchControls();
        Debug.Log("Touch Controls initialized");
    }

    private void OnEnable()
    {
        touchControls.Enable();
        //Debug.Log("Touch Controls enabled");

        touchControls.Touch.TouchPress.started += ctx => StartTouch(ctx);
    }

    private void OnDisable()
    {
        touchControls.Disable();
        //Debug.Log("Touch Controls disabled");
        
        touchControls.Touch.TouchPress.started -= ctx => StartTouch(ctx);
    }

    private void Start()
    {
        mainCamera = Camera.main; // Assuming your main camera is tagged as "MainCamera"
    }

    private void StartTouch(InputAction.CallbackContext context)
    {
        Vector2 touchPosition = touchControls.Touch.TouchPosition.ReadValue<Vector2>();
        //Debug.Log("Touch Started. Position: " + touchPosition);

        // Conversion for screen coordinates to world coordinates
        Vector3 worldTouchPosition = mainCamera.ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, mainCamera.nearClipPlane));

        MoveTargetTransform.position = new Vector3(worldTouchPosition.x, worldTouchPosition.y, MoveTargetTransform.position.z);

        moveTargetAnimator.SetTrigger("Tapped");
    }
}
