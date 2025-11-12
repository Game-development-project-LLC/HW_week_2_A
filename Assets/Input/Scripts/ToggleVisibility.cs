using UnityEngine;
using UnityEngine.InputSystem;

public class ToggleVisibility : MonoBehaviour
{
    [SerializeField] private InputActionReference toggleAction; // bind to e.g. Keyboard.space
    private Renderer[] _renderers;

    private void Awake()
    {
        _renderers = GetComponentsInChildren<Renderer>(true);
    }

    private void OnEnable()
    {
        if (toggleAction != null)
        {
            toggleAction.action.performed += OnToggle;
            toggleAction.action.Enable();
        }
    }

    private void OnDisable()
    {
        if (toggleAction != null)
        {
            toggleAction.action.performed -= OnToggle;
            toggleAction.action.Disable();
        }
    }

    private void OnToggle(InputAction.CallbackContext ctx)
    {
        // Component is responsible for showing/hiding the object.
        foreach (var r in _renderers) r.enabled = !r.enabled;
    }
}
