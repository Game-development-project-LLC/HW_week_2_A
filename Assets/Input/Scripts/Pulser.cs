using UnityEngine;

public class Pulser : MonoBehaviour
{
    [SerializeField] private float baseScale = 1f;
    [SerializeField] private float pulseAmount = 0.25f;   // how much to grow/shrink
    [SerializeField] private float pulseFrequency = 2f;   // pulses per second

    private void Update()
    {
        float s = baseScale + pulseAmount * Mathf.Sin(Time.time * Mathf.PI * 2f * pulseFrequency);
        transform.localScale = new Vector3(s, s, s);
    }
}
