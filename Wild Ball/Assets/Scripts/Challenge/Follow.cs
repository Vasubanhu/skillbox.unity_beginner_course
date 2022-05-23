using UnityEngine;

namespace Prototype.WildBall
{
    public class Follow : MonoBehaviour
    {
        private Transform _player;

        private void Start() => _player = GameObject.FindGameObjectWithTag(GlobalStringVariables.Player).transform;

        private void Update() => transform.position = _player.transform.position;
    }
}
