using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeHandler : MonoBehaviour
{
    [SerializeField] private Text _timeText;
    [SerializeField] private Text _lapCountText;
    [SerializeField] private Text _lapTimeText;
    [SerializeField] private Text _previousLapTimeText;

    private List<float> numbers = new List<float>() { 7.7f, 1.4f, 5.5f, 6.5f, -0.5f };
    private float _currentTime;
    private float _lapsCount;
    private float _currentLapTime;
    private float _previousLapTime;
    private bool _startRace;

    private void Start()
    {
        foreach (float number in numbers)
        {
            Debug.Log(Mathf.Round(number));
        }   
    }

    private void Update()
    {
        Time.timeScale = 0;

        if (_startRace)
        {
            Time.timeScale = 1;

            _currentTime = Mathf.Round(Time.time);
            _timeText.text = _currentTime.ToString();
        }      
    }

    public void RoundPassed()
    {
        CalculateRaceData();
        DisplayRaceData();        
    }
    public void StartRace()
    {
        _startRace = true;       
    }

    private void CalculateRaceData()
    {
        //_previousLapTime = _currentLapTime;
        _currentLapTime = _currentTime;

        _previousLapTime = _currentLapTime - _previousLapTime; // 
    }
    private void DisplayRaceData()
    {
        _lapTimeText.text = _currentLapTime.ToString();
        _previousLapTimeText.text = _previousLapTime.ToString();
        _lapCountText.text = (++_lapsCount).ToString();
    }
}
