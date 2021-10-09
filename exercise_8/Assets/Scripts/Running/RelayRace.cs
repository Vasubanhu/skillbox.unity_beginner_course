using UnityEngine;

public class RelayRace : MonoBehaviour
{
    [SerializeField] private Transform[] _runners;
    [SerializeField] private float _speed;
    private float _passDistance = 2.0f;
    private int _currentRunner;
    private int _nextRunner;
    private int _stickIndex;
    private RelayRace _currentRunnerComponent;
    private RelayRace _nextRunnerComponent;

    private void Start()
    {
        _nextRunner = _currentRunner + 1;
        _currentRunnerComponent = _runners[_currentRunner].GetComponent<RelayRace>();
        _nextRunnerComponent = _runners[_nextRunner].GetComponent<RelayRace>();
    }

    private void Update()
    {
        float _distance = Vector3.Magnitude(_runners[_nextRunner].position - _runners[_currentRunner].position);

        LookAt(_runners[_nextRunner]);
        MoveTo(_runners[_nextRunner]);

        if (CheckDistance(_distance))
        {
            _nextRunnerComponent.enabled = true;
            _currentRunnerComponent.enabled = false;
            PassBaton();
        }
    }

    private void LookAt(Transform target)
    {
        transform.LookAt(target);
    }

    private void MoveTo(Transform target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
    }

    private bool CheckDistance(float distance)
    {
        return (distance <= _passDistance) ? true : false;
    }

    private void PassBaton()
    {
        _runners[_nextRunner].GetChild(_stickIndex).gameObject.SetActive(true);
        _runners[_currentRunner].GetChild(_stickIndex).gameObject.SetActive(false);
    }
}
