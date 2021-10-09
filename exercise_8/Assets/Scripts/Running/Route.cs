using UnityEngine;

public class Route : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private float _speed;
    private Vector3 _target;
    private Vector3 _startPoint;
    private bool _forward = true;
    private int _index;

    private void Start()
    {
        _startPoint = transform.position;
        _target = _points[_index].position;
    }

    private void Update()
    {
        LookAt(_target);
        MoveTo(_target);

        if (CheckPoint(_target))
        {
            if (_forward)
            {
                _index++;
                _target = _points[_index].position;

                if (_index == _points.Length - 1)
                {
                    _forward = false;
                }
            }

            else if (!_forward)
            {
                if (_index == 0)
                {
                    _target = _startPoint;
                    return;
                }

                _index--;
                _target = _points[_index].position;
            }
        }
    }

    private void MoveTo(Vector3 target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target, _speed * Time.deltaTime);
    }

    private bool CheckPoint(Vector3 target)
    {
        return (transform.position == target) ? true : false;
    }

    private void LookAt(Vector3 target)
    {
        transform.LookAt(target);
    }
}
