using UnityEngine;

namespace Prototype.WildBall
{
    public class ElevatorSwitcher : Switcher
    {
        private Animator _animator;
        private Transform _trapdoor;
        private readonly float _angle = -45f;
        private PlayerInput _instance;

        protected override void Start()
        {
            base.Start();
            _animator = GameObject.Find(GlobalStringVariables.Elevator).GetComponent<Animator>();
            _trapdoor = GameObject.FindGameObjectWithTag(GlobalStringVariables.Trapdoor).transform;
            _instance = FindObjectOfType<PlayerInput>();
        }

        private void OnTriggerStay(Collider other)
        {
            if (_instance.Interaction)
            {
                _animator.SetTrigger(GlobalStringVariables.Descent);
                _trapdoor.Rotate(Vector3.forward, _angle);
            }
        }

        protected override void OnTriggerExit(Collider other)
        {
            base.OnTriggerExit(other);
        }
    }
}
