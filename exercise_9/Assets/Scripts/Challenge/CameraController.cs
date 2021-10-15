using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.LookAt(_target);
        transform.Translate(Vector3.right * _speed * Time.deltaTime);
    }
}
