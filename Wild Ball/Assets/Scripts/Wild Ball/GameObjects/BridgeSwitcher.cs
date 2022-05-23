using UnityEngine;

namespace Prototype.WildBall
{
    public class BridgeSwitcher : Switcher
    {
        [SerializeField] private GameObject _bridge;
        [SerializeField] private float _angle;
        private Bridge _instance;

        protected override void Start()
        {
            base.Start();
            _instance = FindObjectOfType<Bridge>();
        }

        protected override void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);
            _instance.Rotate(_bridge, _angle);
        }

        protected override void OnTriggerExit(Collider other)
        {
            base.OnTriggerExit(other);
        }
    }
}
