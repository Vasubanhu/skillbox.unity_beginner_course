using UnityEngine;

public class Superman : MonoBehaviour
{
    [SerializeField] private int _power;
    [SerializeField] private int _speed;
    [SerializeField] private Vector3 _target;

    private void OnCollisionEnter(Collision collision)
    {
        print($"{gameObject.name} столкнулся с {collision.gameObject.name}.");
        Rigidbody rigidbody = collision.gameObject.GetComponent<Rigidbody>();

        if (rigidbody != null)
        {
            Vector3 direction = rigidbody.position - transform.position;
            rigidbody.AddForce(direction.normalized * _power, ForceMode.Impulse);
        }
    }

    private void Update()
    {
        MoveTo(_target);

        if (transform.position.z == _target.z)
        {
            gameObject.SetActive(false);
        }
    }

    private void MoveTo(Vector3 target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target, _speed * Time.deltaTime);
    }
}
