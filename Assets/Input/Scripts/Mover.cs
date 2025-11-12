using UnityEngine;

/// <summary>
/// Moves the object at a constant velocity along a world-space direction.
/// Great for simple linear motion (e.g., moving platform, background drift).
/// </summary>
public class Mover : MonoBehaviour
{
    [SerializeField] private Vector3 direction = Vector3.right; // World-space direction
    [SerializeField] private float speed = 2f;                   // Units per second

    private void Update()
    {
        // Translate in world space so rotation of the object doesn’t affect the path.
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
    }
}
