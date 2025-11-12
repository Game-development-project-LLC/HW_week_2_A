using UnityEngine;

/// <summary>
/// Moves the object back and forth (like a pendulum) around its start position,
/// with smooth speed changes provided by a sine function.
/// Place the object at the desired center in the scene; that position becomes the pivot.
/// </summary>
public class Oscillator : MonoBehaviour
{
    [SerializeField] private Vector3 axis = Vector3.right; // Direction of travel (world space)
    [SerializeField] private float amplitude = 2f;          // Max distance from center (units)
    [SerializeField] private float frequency = 1f;          // Cycles per second

    private Vector3 _center; // Where we oscillate around

    private void Start()
    {
        // we use the initial position as the center so designers can place the object in the scene.
        _center = transform.position;
    }

    private void Update()
    {
        // position(t) = center + axis * amplitude * sin(2 * pi * f t)
        float offset = Mathf.Sin(Time.time * Mathf.PI * 2f * frequency) * amplitude;
        transform.position = _center + axis.normalized * offset;
    }
}
