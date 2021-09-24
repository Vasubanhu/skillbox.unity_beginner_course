using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TwoNumbersComparer : MonoBehaviour
{
    [SerializeField] private InputField _inputField1;
    [SerializeField] private InputField _inputField2;
    [SerializeField] private Text _outputText;
    [SerializeField] private Text _messageText;
    private List<string> messages = new List<string>() { "Некорректный ввод. Введите число.", "Равны" };

    private void Display(double number) => _outputText.text = number.ToString();

    private void Display(string message) => _outputText.text = message;

    private void DisplayMessage(string message) => _messageText.text = message;

    public void Clear()
    {
        _inputField1.text = string.Empty;
        _inputField2.text = string.Empty;
        _outputText.text = string.Empty;
    }

    public void Compare()
    {
        try
        {
            double number1 = double.Parse(_inputField1.text);
            double number2 = double.Parse(_inputField2.text);

            if (number1 == number2)
            {
                Display(messages[1]);
            }
            else if (number1 > number2)
            {
                Display(number1);

                DisplayMessage(string.Empty);
            }
            else
            {
                Display(number2);

                DisplayMessage(string.Empty);
            }
        }
        catch (System.Exception)
        {
            DisplayMessage(messages[0]);
        }
    }
}
