using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calculator : MonoBehaviour
{
    [SerializeField] private InputField _inputField1;
    [SerializeField] private InputField _inputField2;
    [SerializeField] private Text _outputText;
    [SerializeField] private Text _messageText;
    private List<string> messages = new List<string>() { "Некорректный ввод. Введите число.", "Деление на 0." };

    public void Clear()
    {
        _inputField1.text = string.Empty;
        _inputField2.text = string.Empty;
        _outputText.text = string.Empty;
    }

    private void Display(double number) => _outputText.text = number.ToString();

    private void DisplayMessage(string message) => _messageText.text = message;

    public void Add()
    {
        try
        {
            Display(double.Parse(_inputField1.text) + double.Parse(_inputField2.text));
            DisplayMessage(string.Empty);
        }
        catch (System.Exception)
        {
            DisplayMessage(messages[0]);
        }
    }

    public void Subtract()
    {
        try
        {
            Display(double.Parse(_inputField1.text) - double.Parse(_inputField2.text));
            DisplayMessage(string.Empty);
        }
        catch (System.Exception)
        {
            DisplayMessage(messages[0]);
        }
    }

    public void Multiply()
    {
        try
        {
            Display(double.Parse(_inputField1.text) * double.Parse(_inputField2.text));
            DisplayMessage(string.Empty);
        }
        catch (System.Exception)
        {
            DisplayMessage(messages[0]);
        }
    }

    public void Divide()
    {
        if (_inputField2.text != 0.ToString())
        {
            try
            {
                Display(double.Parse(_inputField1.text) / double.Parse(_inputField2.text));
                DisplayMessage(string.Empty);
            }
            catch (System.Exception)
            {
                DisplayMessage(messages[0]);
            }
        }
        else
        {
            DisplayMessage(messages[1]);
        }
    }
}
