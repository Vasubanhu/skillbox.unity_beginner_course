using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text _timerText;
    [SerializeField] private float _timeRemaining;
    [SerializeField] private GameObject[] panels;
    private Breaking _instance;

    private void Start()
    {      
        _instance = FindObjectOfType<Breaking>();
        Pause();
    }

    private void Update()
    {
        DisplayTimer();
        GameOver();
    }

    private void SetTimer() => _timeRemaining = 60.0f;

    private void Pause() => Time.timeScale = 0;

    private void Resume() => Time.timeScale = 1;

    private void DisplayTimer()
    {
        if (_timeRemaining > 0)
        {
            _timeRemaining -= Time.deltaTime;
            _timerText.text = Mathf.Round(_timeRemaining).ToString();
        }
    }

    private void GameOver()
    {
        Win();
        Lose();
    }

    private void Win()
    {
        string result = $"{_instance.Pin1Value}{_instance.Pin2Value}{_instance.Pin3Value}";

        if (result == _instance._rightCombination)
        {
            panels[2].SetActive(true);
            panels[1].SetActive(false);
            Pause();
        }
    }

    private void Lose()
    {
        if (_timeRemaining <= 0)
        {
            panels[3].SetActive(true);
            panels[1].SetActive(false);
            Pause();
        }      
    }

    public void Restart()
    {
        SetTimer();
        panels[1].SetActive(true);
        panels[2].SetActive(false);
        panels[3].SetActive(false);
        _instance.ResetToDefault();
        Resume();
    }

    public void StartGame()
    {
        SetTimer();
        panels[1].SetActive(true);
        panels[0].SetActive(false);
        _instance.ResetToDefault();
        Resume();
    }
}
