using UnityEngine;

public class Flipper : MonoBehaviour
{
    [SerializeField] private float _initialPosition;
    [SerializeField] private float _extremePosition;
    [SerializeField] private float _hitStrengh;
    [SerializeField] private float _flipperDamper;
    [SerializeField] private string _input;

    private HingeJoint _hinge;
    JointSpring _jointSpring;

    private void Start()
    {
        _hinge = GetComponent<HingeJoint>();
        _hinge.useSpring = true;
        _hinge.useLimits = true;

        _jointSpring = new JointSpring();
        _jointSpring.spring = _hitStrengh;
        _jointSpring.damper = _flipperDamper;      
    }

    private void Update()
    {
        if (Input.GetAxis(_input) == 1)
        {
            _jointSpring.targetPosition = _extremePosition;
        }
        else
        {
            _jointSpring.targetPosition = _initialPosition;
        }

        _hinge.spring = _jointSpring;
    }
}
