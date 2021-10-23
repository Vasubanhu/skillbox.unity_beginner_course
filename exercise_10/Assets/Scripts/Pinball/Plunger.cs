using UnityEngine;

public class Plunger : MonoBehaviour
{
    [SerializeField] private float _force;
    private SpringJoint _springJoint;
    private Rigidbody _rigidbody;
    private float _distance = 1f;
    private bool _isLock;
    private bool _keyPressed;
    private float _countdown = 3.5f;
    private float _timer;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _springJoint = GetComponent<SpringJoint>();
        _springJoint.maxDistance = _distance;
        _timer = _countdown;
    }

    private void FixedUpdate()
    {
        if (_isLock)
        {
            _springJoint.maxDistance = _distance / 2;
            _rigidbody.AddForce(Vector3.left * _force);
            _isLock = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_isLock && !_keyPressed)
        {            
            Gate.PlungerGate.SetActive(true);
            _keyPressed = true;
            _isLock = true;
        }

        if (_keyPressed)
        {
            _timer -= Time.deltaTime;

            if(_timer <= 0)
            {
                _timer = _countdown;
                _keyPressed = false;
                return;
            }
        }         
    }
}
