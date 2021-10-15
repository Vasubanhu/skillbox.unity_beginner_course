using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _timeToExplosion;
    [SerializeField] private float _explosionPower;
    [SerializeField] private float _explosionRadius;

    private float _timeLimit = 3.0f;
    //private AudioSource _audio;
    //private float _delay = 1.8f;

    private void Start()
    {     
        _timeToExplosion = _timeLimit;
        //_audio = GetComponent<AudioSource>();
        //_audio.PlayDelayed(_delay);
    }

    private void Update()
    {
        _timeToExplosion -= Time.deltaTime;

        if (_timeToExplosion <= 0)
        {           
            Boom();
        }     
    }

    private void Boom()
    {
        Rigidbody[] rigidbodies = FindObjectsOfType<Rigidbody>();

        foreach (Rigidbody rigidbody in rigidbodies)
        {
            float distance = Vector3.Distance(transform.position, rigidbody.position);

            if (distance < _explosionRadius)
            {               
                Vector3 direction = rigidbody.position - transform.position;
                // Увеличение силы взрыва в зависимости от дистанции до объекта
                rigidbody.AddForce(direction.normalized * _explosionPower * (_explosionRadius - distance), ForceMode.Impulse);
            }
        }

        _timeToExplosion = _timeLimit;// опционально
    }
}
