using UnityEngine;

namespace Prototype.WildBall
{
    public class CirclePlatform : BaseObject
    {
        [SerializeField] private float _direction;
        [SerializeField] private float _speed;
        private Rigidbody _rigidbody;

        protected override void Start() => _rigidbody = GetComponent<Rigidbody>();

        protected override void FixedUpdate() => Rotate();

        protected override void Rotate() => _rigidbody.AddTorque(Vector3.up * _speed * _direction * Time.fixedDeltaTime);
    }
}

