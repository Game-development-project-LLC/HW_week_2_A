using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Toggles the renderers (show/hide) of this object and its children
/// when a bound Input System action is performed (e.g., Space key) we Put this on the object we want to show/hide. 
/// we Assign an InputActionReference to 'toggleAction' (e.g., Player/Toggle).
/// </summary>
public class ToggleVisibility : MonoBehaviour
{
    [SerializeField] private InputActionReference toggleAction;
    // Bind this to a Button action (e.g., Space). 
    // Example: PlayerControls.inputactions -> Player/Toggle

    private Renderer[] _renderers; // Cache all renderers under this object

    private void Awake()
    {
        // Grab every Renderer in this object hierarchy, including inactive children.
        _renderers = GetComponentsInChildren<Renderer>(true);
    }

    private void OnEnable()
    {
        if (toggleAction != null)
        {
            // Subscribe once when enabled and enable the action.
            toggleAction.action.performed += OnToggle;
            toggleAction.action.Enable();
        }
    }

    private void OnDisable()
    {
        if (toggleAction != null)
        {
            // Cleanly unsubscribe and disable the action to avoid duplicates.
            toggleAction.action.performed -= OnToggle;
            toggleAction.action.Disable();
        }
    }

    private void OnToggle(InputAction.CallbackContext _)
    {
        // Determine the current state (if any renderer is enabled, we’ll flip to off).
        bool anyEnabled = false;
        foreach (var r in _renderers) if (r.enabled) { anyEnabled = true; break; }

        bool newState = !anyEnabled;
        foreach (var r in _renderers) r.enabled = newState;
    }
}
