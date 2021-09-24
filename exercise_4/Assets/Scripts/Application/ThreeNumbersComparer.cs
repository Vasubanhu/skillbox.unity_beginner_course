using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThreeNumbersComparer : MonoBehaviour
{
    [SerializeField] private InputField _inputField1;
    [SerializeField] private InputField _inputField2;
    [SerializeField] private InputField _inputField3;
    [SerializeField] private Text _outputText;
    [SerializeField] private Text _messageText;
    private List<string> messages = new List<string>() { "Некорректный ввод. Введите число.", "Равны" };

    private void DisplayOutput(string message) => _outputText.text = message;

    private void DisplayMessage(string message) => _messageText.text = message;

    public void Clear()
    {
        _inputField1.text = string.Empty;
        _inputField2.text = string.Empty;
        _inputField3.text = string.Empty;
        _outputText.text = string.Empty;
    }

    public void Compare()
    {
        try
        {
            double number1 = double.Parse(_inputField1.text);
            double number2 = double.Parse(_inputField2.text);
            double number3 = double.Parse(_inputField3.text);

            if (number1 == number2 && number2 == number3)
            {
                DisplayOutput(messages[1]);
                DisplayMessage(string.Empty);
            }

            else if (number2 > number1 && number1 < number3)
            {
                DisplayOutput($"{number2}, {number3}");
                DisplayMessage(string.Empty);
            }

            else if (number1 > number2 && number2 < number3)
            {
                DisplayOutput($"{number1}, {number3}");
                DisplayMessage(string.Empty);
            }

            else
            {
                DisplayOutput($"{number1}, {number2}");
                DisplayMessage(string.Empty);
            }
        }
        catch (System.Exception)
        {
            DisplayMessage(messages[0]);
        }
    }
}
