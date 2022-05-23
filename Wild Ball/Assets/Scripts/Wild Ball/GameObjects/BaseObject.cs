using UnityEngine;

namespace Prototype.WildBall
{
    public abstract class BaseObject : MonoBehaviour
    {
        protected virtual void Start() { }

        protected virtual void FixedUpdate() { }

        protected virtual void Update() { }
    
        protected virtual void Rotate() { }
    }
}
