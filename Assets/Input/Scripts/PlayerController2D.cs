using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Simple top-down 2D movement driven by the new Input System.
/// Reads a Vector2 action (e.g., WASD) and moves the object.
/// Attach to Player GameObject.
/// In the Inspector, we assign an InputActionReference (Player/Move).
/// </summary>
public class PlayerController2D : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed = 5f;
    // Units per second. Tune in the Inspector.

    [Header("Input")]
    [SerializeField] private InputActionReference moveAction;
    // Expects a Value/Vector2 action (e.g., WASD). 
    // Assign: PlayerControls.inputactions -> Player/Move

    private void OnEnable()
    {
        // Enable the action when this component becomes active.
        if (moveAction != null) moveAction.action.Enable();
    }

    private void OnDisable()
    {
        // Always disable to avoid leaks / duplicate callbacks.
        if (moveAction != null) moveAction.action.Disable();
    }

    private void Update()
    {
        // Read input; zero if not assigned to avoid null-reference errors.
        Vector2 input = moveAction ? moveAction.action.ReadValue<Vector2>() : Vector2.zero;

        // Convert to world-space delta and move the Transform.
        Vector3 delta = new Vector3(input.x, input.y, 0f) * (speed * Time.deltaTime);
        transform.position += delta;
    }
}
