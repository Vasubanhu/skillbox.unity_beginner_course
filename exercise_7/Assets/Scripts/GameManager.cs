using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] panels;
    [SerializeField] private Sprite[] buttonSprites;
    [SerializeField] private Timer _harvestTimer;
    [SerializeField] private Timer _salaryTimer;
    [SerializeField] private Image _enemyWaveTimerImage;
    [SerializeField] private Image _peasantCreateTimerImage;
    [SerializeField] private Image _warriorCreateTimerImage;
    [SerializeField] private Button _peasantCreateButton;
    [SerializeField] private Button _warriorCreateButton;
    [SerializeField] private Button _switchSoundButton;
    [Header("MainPanelOutput:"), SerializeField] private Text _wheatCountText;
    [SerializeField] private Text _peasantsCountText;
    [SerializeField] private Text _warriorsCountText;
    [SerializeField] private Text _enemiesCountText;
    [SerializeField] private Text _roundCountText;
    [Header("LosePanelOutput:"), SerializeField] private Text _roundExperiencedText;
    [SerializeField] private Text _wheatProducedText;
    [SerializeField] private Text _peasantsHiredText;
    [SerializeField] private Text _warriorsHiredText;
    [Header("PausePanelOutput:"), SerializeField] private Text _goalsText;
    [Header("GameSettings:"), SerializeField] private int _wheatCount;
    [SerializeField] private int _peasantsCount;
    [SerializeField] private int _warriorsCount;
    [SerializeField] private int _wheatPerPeasant;
    [SerializeField] private int _wheatToWarrior;
    [SerializeField] private int _peasantCost;
    [SerializeField] private int _warriorCost;
    [SerializeField] private int _enemyWaveIncrease;
    [SerializeField] private int _nextEnemyWave;
    [SerializeField] private float _peasantCreateTime;
    [SerializeField] private float _warriorCreateTime;
    [SerializeField] private float _enemyWaveLimitTime;

    private float _peasantCreateTimer = -2;
    private float _warriorCreateTimer = -2;
    private float _enemyWaveTimer;

    private bool _tick;
    private int _round = 1;
    private int _delaySpawn = 3;

    private int _startPeasantCount = 3;
    private int _startWheatCount = 30;
    private int _totalWarriorsHired;

    private int _goalPeasantCount = 60;
    private int _goalWheatCount = 500;

    private bool _peasantCreateButtonIsInteractable;
    private bool _warriorCreateButtonIsInteractable;
    private Image _switchSoundImage;
    private bool _isClicked;
    private AudioManager _audioManager;

    private void Start()
    {
        _audioManager = FindObjectOfType<AudioManager>();
        _switchSoundImage = _switchSoundButton.GetComponent<Image>();

        _peasantCreateButtonIsInteractable = true;
        _warriorCreateButtonIsInteractable = true;

        SetEnemyTimer();
        DisplayText();
    }

    private void Update()
    {
        SpawnEnemyWave();
        СalculateResources();
        CheckButtonAvailability();
        CreateVillagers();
        DisplayText();
        GameOver();
    }

    #region Game
    private void Pause() => Time.timeScale = 0;

    private void Resume() => Time.timeScale = 1;

    private void GameOver()
    {
        Win();
        Lose();
    }

    private void Win()
    {
        if (_peasantsCount >= _goalPeasantCount || _wheatCount >= _goalWheatCount)
        {
            _audioManager.Stop("BackgroundTheme");
            Pause();
            panels[1].SetActive(true);
            panels[0].SetActive(false);
        }
    }

    private void Lose()
    {
        if (_warriorsCount < 0)
        {
            _audioManager.Stop("BackgroundTheme");
            Pause();
            panels[2].SetActive(true);
            DisplayTotalStats();
            panels[0].SetActive(false);
        }
    }

    public void SwitchPausePanel()
    {
        if (!_isClicked)
        {
            _audioManager.Play("ClickButton");
        }
        
        Pause();
        panels[3].SetActive(true);
        _goalsText.text = $"If you want to win, you must collect {_goalWheatCount} units of wheat, " +
                          $"or the total number of peasants must be {_goalPeasantCount}";
    }

    public void ResumeGame()
    {
        if (!_isClicked)
        {
            _audioManager.Play("ClickButton");
        }
        Resume();
        panels[3].SetActive(false);
    }

    public void SwitchSound()
    {
        if (_isClicked)
        {
            _switchSoundImage.sprite = buttonSprites[0];
            _audioManager.Play("BackgroundTheme");
            _audioManager.Stop("ClickButton");
        }

        else
        {
            _switchSoundImage.sprite = buttonSprites[1];
            _audioManager.Stop("BackgroundTheme");
            _audioManager.Play("ClickButton");
        }

        _isClicked = !_isClicked;
    }
    #endregion
    #region Enemy
    private void SetEnemyTimer() => _enemyWaveTimer = _enemyWaveLimitTime;

    private void SpawnEnemyWave()
    {
        _tick = false;

        _enemyWaveTimer -= Time.deltaTime;
        _enemyWaveTimerImage.fillAmount = _enemyWaveTimer / _enemyWaveLimitTime;

        if (_enemyWaveTimer <= 0)
        {
            _tick = true;
            SetEnemyTimer();
            CheckEnemyWave();
        }
    }

    private void CheckEnemyWave()
    {
        if (_tick)
        {
            _round++;

            if (_round > _delaySpawn)
            {
                if (!_isClicked)
                {
                    _audioManager.Play("Raid");
                }            
                _warriorsCount -= _nextEnemyWave;
                _nextEnemyWave += _enemyWaveIncrease;
            }
        }
    }
    #endregion
    #region Village
    public void StartCreatePeasant()
    {
        if (!_isClicked)
        {
            _audioManager.Play("ClickButton");
        }
        _wheatCount -= _peasantCost;
        _peasantCreateTimer = _peasantCreateTime;
        _peasantCreateButtonIsInteractable = false;
    }

    public void StartCreateWarrior()
    {
        if (!_isClicked)
        {
            _audioManager.Play("ClickButton");
        }
        _wheatCount -= _warriorCost;
        _warriorCreateTimer = _warriorCreateTime;
        _warriorCreateButtonIsInteractable = false;
    }

    private void CreateVillagers()
    {
        CreatePeasant();
        CreateWarrior();
    }

    private void CreatePeasant()
    {
        if (_peasantCreateTimer > 0)
        {
            _peasantCreateTimer -= Time.deltaTime;
            _peasantCreateTimerImage.fillAmount = _peasantCreateTimer / _peasantCreateTime;
        }
        else if (_peasantCreateTimer > -1)
        {
            if (!_isClicked)
            {
                _audioManager.Play("SpawnPeasant");
            }       
            _peasantCreateTimerImage.fillAmount = 1;
            _peasantsCount++;
            _peasantCreateTimer = -2;
            _peasantCreateButtonIsInteractable = true;
        }
    }

    private void CreateWarrior()
    {
        if (_warriorCreateTimer > 0)
        {
            _warriorCreateTimer -= Time.deltaTime;
            _warriorCreateTimerImage.fillAmount = _warriorCreateTimer / _warriorCreateTime;
        }
        else if (_warriorCreateTimer > -1)
        {
            if (!_isClicked)
            {
                _audioManager.Play("SpawnWarrior");
            }          
            _warriorCreateTimerImage.fillAmount = 1;
            _warriorsCount++;
            _totalWarriorsHired++;
            _warriorCreateTimer = -2;
            _warriorCreateButtonIsInteractable = true;
        }
    }

    private void CheckButtonAvailability()
    {
        if (_peasantCreateButtonIsInteractable)
        {
            _peasantCreateButton.interactable = true;
        }

        if (!_peasantCreateButtonIsInteractable || _wheatCount < _peasantCost)
        {
            _peasantCreateButton.interactable = false;
        }

        if (_warriorCreateButtonIsInteractable)
        {
            _warriorCreateButton.interactable = true;
        }

        if (!_warriorCreateButtonIsInteractable || _wheatCount < _warriorCost)
        {
            _warriorCreateButton.interactable = false;
        }
    }

    private void СalculateResources()
    {
        if (_harvestTimer.Tick)
        {
            if (!_isClicked)
            {
                _audioManager.Play("Harvesting");
            }
            _wheatCount += _peasantsCount * _wheatPerPeasant;
        }

        if (_salaryTimer.Tick)
        {
            if (!_isClicked)
            {
                _audioManager.Play("SalaryDay");
            }
            _wheatCount -= _warriorsCount * _wheatToWarrior;
        }
    }
    #endregion
    #region Output
    private void DisplayText()
    {
        _wheatCountText.text = _wheatCount.ToString();
        _peasantsCountText.text = _peasantsCount.ToString();
        _warriorsCountText.text = _warriorsCount.ToString();
        _enemiesCountText.text = _nextEnemyWave.ToString();
        _roundCountText.text = $"Round {_round}";
    }

    private void DisplayTotalStats()
    {
        _roundExperiencedText.text = $"Rounds\nexperienced:\n\n{_round - 1}";
        _wheatProducedText.text = $"Wheat\nproduced:\n\n{_wheatCount - _startWheatCount}";
        _peasantsHiredText.text = $"Peasants\nhired:\n\n{_peasantsCount - _startPeasantCount}";
        _warriorsHiredText.text = $"Warriors\nhired:\n\n{_totalWarriorsHired}";
    }
    #endregion
}
