using System;
using System.Collections;
using UnityEngine;

namespace Prototype.WildBall
{
    public class AnimationController : MonoBehaviour
    {
        private Animator _animator;
        private System.Random _random;

        private IEnumerator Start()
        {
            _random = new System.Random(Guid.NewGuid().GetHashCode());
            _animator = GetComponent<Animator>();

            while (true)
            {
                yield return new WaitForSeconds(3);

                _animator.SetInteger(GlobalStringVariables.StateIndex, _random.Next(0, 3));
                SetTrigger(GlobalStringVariables.State);
            }
        }

        public void SetTrigger(string trigger) => _animator.SetTrigger(trigger);
    }
}
