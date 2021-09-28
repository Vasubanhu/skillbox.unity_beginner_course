using UnityEngine;
using UnityEngine.UI;

public class Breaking : MonoBehaviour
{
    [SerializeField] private Text _pin1Text;
    [SerializeField] private Text _pin2Text;
    [SerializeField] private Text _pin3Text;
    [SerializeField] private Text _drillText;
    [SerializeField] private Text _hammerText;
    [SerializeField] private Text _lockpickText;
    [Header("PadlockPinsSettings:"), Range(0, 10)] public int Pin1Value;
    [Range(0, 10)] public int Pin2Value;
    [Range(0, 10)] public int Pin3Value;
    [Header("DrillSettings:"), SerializeField, Range(-5, 5)] private int _drillPin1Value;
    [SerializeField, Range(-5, 5)] private int _drillPin2Value;
    [SerializeField, Range(-5, 5)] private int _drillPin3Value;
    [Header("HammerSettings:"), SerializeField, Range(-5, 5)] private int _hammerPin1Value;
    [SerializeField, Range(-5, 5)] private int _hammerPin2Value;
    [SerializeField, Range(-5, 5)] private int _hammerPin3Value;
    [Header("LockpickSettings:"), SerializeField, Range(-5, 5)] private int _lockpickPin1Value;
    [SerializeField, Range(-5, 5)] private int _lockpickPin2Value;
    [SerializeField, Range(-5, 5)] private int _lockpickPin3Value;
    private string[] tools = { "Дрель", "Молоток", "Отмычка" };
    private int[] startPinsValue = { 7, 3, 6 };
    public readonly string _rightCombination = "666";

    private void Start()
    {
        ChangePinsValue(startPinsValue[0], startPinsValue[1], startPinsValue[2]);
        SetDrillValue();
        SetHammerValue();
        SetLockpickValue();
    }

    public void ResetToDefault()
    {
        Pin1Value = 0;
        Pin2Value = 0;
        Pin3Value = 0;
        ChangePinsValue(startPinsValue[0], startPinsValue[1], startPinsValue[2]);
    }

    private void SetPinsValue()
    {
        _pin1Text.text = Pin1Value.ToString();
        _pin2Text.text = Pin2Value.ToString();
        _pin3Text.text = Pin3Value.ToString();
    }

    private void ChangePinsValue(int pin1value, int pin2value, int pin3value)
    {
        Pin1Value += pin1value;
        Pin2Value += pin2value;
        Pin3Value += pin3value;
        IsCorrectValue();
        SetPinsValue();
    }

    private void SetDrillValue()
    {
        string value = $"{tools[0]}\n{_drillPin1Value} | {_drillPin2Value} | {_drillPin3Value}";
        _drillText.text = value;
    }

    private void SetHammerValue()
    {
        string value = $"{tools[1]}\n{_hammerPin1Value} | {_hammerPin2Value} | {_hammerPin3Value}";
        _hammerText.text = value;
    }

    private void SetLockpickValue()
    {
        string value = $"{tools[2]}\n{_lockpickPin1Value} | {_lockpickPin2Value} | {_lockpickPin3Value}";
        _lockpickText.text = value;
    }

    public void Drill()
    {
        ChangePinsValue(_drillPin1Value, _drillPin2Value, _drillPin3Value);
    }

    public void Hammer()
    {
        ChangePinsValue(_hammerPin1Value, _hammerPin2Value, _hammerPin3Value);
    }

    public void Lockpick()
    {
        ChangePinsValue(_lockpickPin1Value, _lockpickPin2Value, _lockpickPin3Value);
    }

    private void IsCorrectValue()
    {
        if (Pin1Value < 0)
            Pin1Value = 0;
        if (Pin1Value > 10)
            Pin1Value = 10;
        if (Pin2Value < 0)
            Pin2Value = 0;
        if (Pin2Value > 10)
            Pin2Value = 10;
        if (Pin3Value < 0)
            Pin3Value = 0;
        if (Pin3Value > 10)
            Pin3Value = 10;
    }
}
