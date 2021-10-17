using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int _cueBallPower;
    [SerializeField] private int _cueBallSpeed;
    [SerializeField] private Transform _balls;

    private Rigidbody _rigidbody;
    private bool _isLaunched;
    [HideInInspector] public static readonly int _ballLayer = 12;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == _ballLayer && !_isLaunched)
        {
            _isLaunched = true;
            LaunchBall(_rigidbody, collision.gameObject.transform);
            Destroy(this);
        }
    }

    private void LaunchBall(Rigidbody rigidbody, Transform ball)
    {
        Vector3 direction = ball.position - rigidbody.position;
        rigidbody.AddForce(direction.normalized * _cueBallPower, ForceMode.Impulse);
        //rigidbody.AddForce(Vector3.forward * _cueBallPower, ForceMode.VelocityChange);
    }

    private void Update()
    {
        if (!_isLaunched)
        {
            MoveTo(_balls);
        }
    }

    private void MoveTo(Transform target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, _cueBallSpeed * Time.deltaTime);
    }
}
