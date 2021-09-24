using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuessingGame : MonoBehaviour
{
    [SerializeField] private InputField _inputText;
    [SerializeField] private Text _outputText;

    private int _minNumber = 1;
    private int _maxNumber = 100;
    private int _secretNumber;

    private List<string> messages = new List<string>() { "Вы угадали.", "Меньше.", "Больше.", " - не число." };

    private void Start() => _secretNumber = Random.Range(_minNumber, _maxNumber + 1);

    public void ParseText()
    {
        bool result;
        int number;

        result = int.TryParse(_inputText.text, out number);

        if (result)
        {
            CheckNumber(number);
        }
        else
        {
            _outputText.text = $"\"{_inputText.text}\" {messages[3]}";
        }
    }

    public void CheckNumber(int number)
    {
        if (number == _secretNumber)
        {
            _outputText.text = messages[0];
        }
        else
        {
            switch ((int)Mathf.Sign(number - _secretNumber))
            {
                case 1:
                    _outputText.text = messages[1];
                    break;
                case -1:
                    _outputText.text = messages[2];
                    break;
            }
        }
    }
}
