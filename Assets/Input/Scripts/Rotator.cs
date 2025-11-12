using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private Vector3 localAxis = Vector3.up; // which axis to rotate around
    [SerializeField] private float degreesPerSecond = 90f;

    private void Update()
    {
        transform.Rotate(localAxis.normalized, degreesPerSecond * Time.deltaTime, Space.Self);
    }
}
