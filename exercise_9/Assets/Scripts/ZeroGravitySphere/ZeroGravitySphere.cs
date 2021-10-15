using UnityEngine;

public class ZeroGravitySphere : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _points;

    private Transform _target;
    private int _index;

    private void Start()
    {
        _target = _points[_index];
    }

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Rigidbody>().useGravity = false;
    }

    private void OnTriggerExit(Collider other)
    {
        other.GetComponent<Rigidbody>().useGravity = true;
    }

    private void Update()
    {
        
        LookAt(_target);
        MoveTo(_target);
        Debug.DrawLine(transform.position, _target.position, Color.cyan, 5f);

        if (CheckPoint(_target.position))
        {
            _index++;
            _target = _points[_index];

            if (_index == _points.Length - 1)
            {
                _index = -1;
            }
        }
    }

    private void MoveTo(Transform target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
    }

    private bool CheckPoint(Vector3 target)
    {
        return (transform.position == target) ? true : false;
    }

    private void LookAt(Transform target)
    {
        transform.LookAt(target);
    }
}
