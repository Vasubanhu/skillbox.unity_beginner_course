using System.Collections.Generic;
using UnityEngine;

namespace Prototype.WildBall
{
    public abstract class Switcher : MonoBehaviour
    {
        [SerializeField] private List<Material> _materials;
        private MeshRenderer _meshRenderer;

        protected virtual void Start()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
        }

        protected virtual void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(GlobalStringVariables.Player))
            {
                _meshRenderer.material = _materials[1];
            }
        }

        protected virtual void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag(GlobalStringVariables.Player))
            {
                _meshRenderer.material = _materials[0];
            }
        }
    }
}
