using UnityEngine;

namespace Prototype.WildBall
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField, Range(0, 10)] private float _speed = 2f;
        [SerializeField] private float _jumpPower = 5f;
        private Rigidbody _rigidbody;
        private bool _inAir;

        public bool InAir { get => _inAir; }

        private void Awake() => _rigidbody = GetComponent<Rigidbody>();

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag(GlobalStringVariables.Terrain))
                _inAir = false;
        }

        private void OnCollisionStay(Collision other)
        {
            if (other.gameObject.CompareTag(GlobalStringVariables.Terrain))
                _inAir = false;
        }

        private void OnCollisionExit(Collision other)
        {
            if (other.gameObject.CompareTag(GlobalStringVariables.Terrain))
                _inAir = true;
        }

        public void Move(Vector3 movement) => _rigidbody.AddForce(movement * _speed);

        public void Jump() => _rigidbody.AddForce(Vector3.up * _jumpPower);

#if UNITY_EDITOR
        [ContextMenu("Reset Values")]
        public void ResetValues() => _speed = 2f;
#endif
    }
}
