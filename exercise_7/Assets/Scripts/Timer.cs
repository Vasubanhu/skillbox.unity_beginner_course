using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [HideInInspector] public bool Tick;
    [SerializeField] private float _timeLimit;
    private float _currentTime;
    private Image _image;

    private void Start()
    {
        _currentTime = _timeLimit;
        _image = GetComponent<Image>();
    }

    private void Update()
    {
        Tick = false;
        _currentTime += Time.deltaTime;

        if (_currentTime >= _timeLimit)
        {
            Tick = true;
            _currentTime = 0;
        }

        _image.fillAmount = _currentTime / _timeLimit;
    }
}
