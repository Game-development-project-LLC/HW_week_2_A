using UnityEngine;

/// <summary>
/// Spins the object around a local axis at a constant angular speed.
/// </summary>
public class Rotator : MonoBehaviour
{
    [SerializeField] private Vector3 localAxis = Vector3.forward; // Axis in local space
    [SerializeField] private float degreesPerSecond = 90f;        // Angular speed

    private void Update()
    {
        // Rotate around the chosen local axis every frame.
        transform.Rotate(localAxis.normalized, degreesPerSecond * Time.deltaTime, Space.Self);
    }
}
