using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _layerMask;

    private float _newSpeed = 100f;
    private Collider[] _colliders;

    private void Start()
    {
         _colliders = Physics.OverlapSphere(transform.position, _radius, _layerMask);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Objects")
        {
            foreach (Collider collider in _colliders)
            {
                float speed = collider.gameObject.GetComponent<HingeJoint>().motor.targetVelocity;
                speed = _newSpeed;
            }
        }
    }
}
