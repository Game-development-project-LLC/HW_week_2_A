using UnityEngine;

public class Oscillator : MonoBehaviour
{
    [SerializeField] private Vector3 axis = Vector3.right; // direction of oscillation
    [SerializeField] private float amplitude = 2f;          // world units
    [SerializeField] private float frequency = 1f;          // cycles per second

    private Vector3 _center;

    private void Start()
    {
        _center = transform.position; // center is current position (as required)
    }

    private void Update()
    {
        // Smooth speed changes via sine; position(t) = center + axis * amplitude * sin(2π f t)
        float offset = Mathf.Sin(Time.time * Mathf.PI * 2f * frequency) * amplitude;
        transform.position = _center + axis.normalized * offset;
    }
}
