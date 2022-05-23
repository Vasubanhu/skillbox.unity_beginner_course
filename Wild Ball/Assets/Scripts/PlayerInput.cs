using UnityEngine;

namespace Prototype.WildBall
{
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerInput : MonoBehaviour
    {
        private Vector3 _movement;
        private PlayerMovement _playerMovement;
        private bool _jump;
        [HideInInspector] public bool Interaction;
        //private Animation _animation;

        private void Awake()
        {
            _playerMovement = GetComponent<PlayerMovement>();
            //_animation = GetComponentInParent<Animation>();
        }

        private void Update()
        {
            float horizontal = Input.GetAxis(GlobalStringVariables.HorizontalAxis);
            float vertical = Input.GetAxis(GlobalStringVariables.VerticalAxis);

            _jump = Input.GetButtonDown(GlobalStringVariables.JumpButton);
            _movement = new Vector3(horizontal, 0, vertical).normalized;

            Interaction = Input.GetButtonDown(GlobalStringVariables.InteractionButton);

            if (_jump && !_playerMovement.InAir)
            {
                _playerMovement.Jump();
            }
        }

        private void FixedUpdate()
        {           
            _playerMovement.Move(_movement);         
        }
    }
}
