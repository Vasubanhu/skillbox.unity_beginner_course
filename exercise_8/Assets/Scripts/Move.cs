using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _points;
    [SerializeField] private GameObject _prope;
    private Vector3 _target;
    private int _index;
    private float _angle = 3.0f;

    private void Start() => _target = _points[_index].position;

    private void Update()
    {
        LookAt(_target);
        MoveTo(_target);

        if (CheckPoint(_target))
        {
            _index++;
            _target = _points[_index].position;

            if (_index == _points.Length - 1)
            {
                _index = -1;
            }
        }

        RotatePrope();
    }

    private void RotatePrope() => _prope.transform.Rotate(Vector3.down, _angle);

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
