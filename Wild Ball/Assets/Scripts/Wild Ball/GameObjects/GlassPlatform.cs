using UnityEngine;

namespace Prototype.WildBall
{
    public class GlassPlatform : BaseObject
    {
        private Transform[] _platforms;
        private string[] _tags;

        protected override void Start()
        {
            _tags = new[] { GlobalStringVariables.Platform, GlobalStringVariables.NonePlatform };
            _platforms = System.Array.FindAll(GetComponentsInChildren<Transform>(), child => child != transform);

            foreach (Transform platform in _platforms)
            {
                int randomIndex = Random.Range(0, 2);
                string randomTag = _tags[randomIndex];
                platform.tag = randomTag;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            Collider platform = collision.GetContact(0).thisCollider;

            if (collision.gameObject.CompareTag(GlobalStringVariables.Player) && platform.CompareTag(GlobalStringVariables.NonePlatform))
            {              
                platform.gameObject.SetActive(false);
            }
        }
    }
}
