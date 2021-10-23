using UnityEngine;

public class CircleBumper : Bumper
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _points;
    private Vector3 _target;
    private int _index;

    protected override void Start() 
    {
        _target = _points[_index].position;
    } 

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            Vector3 opposite = -collision.rigidbody.velocity;
            collision.rigidbody.AddForce(opposite * _power);
        }
    }

    protected override void Update()
    {
        MoveTo(_target);

        if (CheckPoint(_target))
        {
            _index++;

            if (_index > _points.Length - 1)
            {
                _index = 0;
            }

            _target = _points[_index].position;
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
}