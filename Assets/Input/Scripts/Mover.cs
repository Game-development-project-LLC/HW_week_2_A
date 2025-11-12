using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Vector3 direction = Vector3.right;
    [SerializeField] private float speed = 2f;

    private void Update()
    {
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
    }
}
