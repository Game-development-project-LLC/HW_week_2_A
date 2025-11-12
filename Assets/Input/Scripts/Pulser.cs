using UnityEngine;

/// <summary>
/// Periodically scales the object up and down like a “heartbeat”.
/// Uses a sine wave so the speed is smooth (fast in the middle, slow at the extremes).
/// we can Attach to any object we want to pulse (UI or world-space).
/// </summary>
public class Pulser : MonoBehaviour
{
    [SerializeField] private float baseScale = 1f;      // Average size (1 = original scale)
    [SerializeField] private float pulseAmount = 0.25f; // +/- scale relative to base
    [SerializeField] private float pulseFrequency = 2f; // Pulses per second

    private void Update()
    {
        // s(t) = base + A * sin(2 * pi *ft)
        float s = baseScale + pulseAmount * Mathf.Sin(Time.time * Mathf.PI * 2f * pulseFrequency);

        // Safety: never go negative (would flip the mesh). Clamp to a tiny positive value.
        if (s < 0.01f) s = 0.01f;

        transform.localScale = new Vector3(s, s, s);
    }
}
