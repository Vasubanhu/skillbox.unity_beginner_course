using UnityEngine;

public abstract class Bumper : MonoBehaviour
{
    [SerializeField] protected float _power;

    protected virtual void Start() { }

    protected virtual void Update() { }
}
