using UnityEngine;

namespace Prototype.WildBall
{
    public class Bridge : BaseObject
    {
        public void Rotate(GameObject bridge, float angle)
        {
            bridge.transform.Rotate(Vector3.up, angle);
        }
    }
}
