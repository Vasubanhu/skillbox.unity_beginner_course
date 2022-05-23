using UnityEngine;

public class Movement : MonoBehaviour
{
    public static Animator _animator;
    [SerializeField] private int _power;
    private Rigidbody _rigidbody;
    private bool _isMoving;

    private void Start()
    {
        _isMoving = true;
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {      
        if (_isMoving)
        {
            _animator.SetBool("Moving", true);
            _rigidbody.AddForce(Vector3.forward * _power * Time.fixedDeltaTime);
        }
        else
        {
            _rigidbody.velocity = Vector3.zero;
            _animator.SetBool("Moving", false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isMoving = !_isMoving;
        }
    }
}
