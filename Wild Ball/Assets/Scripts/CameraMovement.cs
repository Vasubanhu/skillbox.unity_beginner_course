using UnityEngine;

namespace Prototype.WildBall
{
    public class CameraMovement : MonoBehaviour
    {
        private Transform _player;
        private Vector3 _cameraOffset;

        private void Start()
        {
            _player = GameObject.FindGameObjectWithTag(GlobalStringVariables.Player).transform;

            if (_player != null)
            {
                _cameraOffset = transform.position - _player.position;
            }
        }

        private void LateUpdate() => transform.position = _player.position + _cameraOffset;
    }
}
