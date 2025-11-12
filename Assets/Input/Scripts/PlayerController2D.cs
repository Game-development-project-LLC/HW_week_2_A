using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController2D : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private InputActionReference moveAction; // Vector2 from WASD/Arrows

    private void OnEnable()
    {
        if (moveAction != null) moveAction.action.Enable();
    }

    private void OnDisable()
    {
        if (moveAction != null) moveAction.action.Disable();
    }

    private void Update()
    {
        Vector2 input = Vector2.zero;
        if (moveAction != null) input = moveAction.action.ReadValue<Vector2>();
        // Move in X/Y plane:
        Vector3 delta = new Vector3(input.x, input.y, 0f) * (speed * Time.deltaTime);
        transform.position += delta;
    }
}
