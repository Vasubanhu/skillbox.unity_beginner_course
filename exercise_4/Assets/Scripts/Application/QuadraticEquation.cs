using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuadraticEquation : MonoBehaviour
{
    [SerializeField] private InputField _inputField1;
    [SerializeField] private InputField _inputField2;
    [SerializeField] private InputField _inputField3;
    [SerializeField] private Text _outputText;
    [SerializeField] private Text _messageText;
    private List<string> messages = new List<string>() { "Некорректный ввод. Введите число.",
                                                         "Некорректный ввод,  \"a\" не может быть равно 0.",
                                                         "Дискриминант меньше 0. Корней нет."};

    private void DisplayMessage(string message) => _messageText.text = message;

    private void DisplayOutput(string message) => _outputText.text = message;

    public void Clear()
    {
        _inputField1.text = string.Empty;
        _inputField2.text = string.Empty;
        _inputField3.text = string.Empty;
        _outputText.text = string.Empty;
    }

    public void Solve()
    {
        try
        {
            double a = double.Parse(_inputField1.text);
            double b = double.Parse(_inputField2.text);
            double c = double.Parse(_inputField3.text);

            if (a == 0)
            {
                DisplayMessage(messages[1]);
            }

            else
            {
                double d = b * b - 4 * a * c;

                if (d < 0)
                {
                    DisplayMessage(messages[2]);
                }

                if (d == 0)
                {
                    double x = (-b / (2 * a));
                    DisplayOutput($"{d}|{x}");
                    DisplayMessage(string.Empty);
                }

                if (d > 0)
                {
                    double x1 = ((-b - (d * d)) / (2 * a));
                    double x2 = ((-b + (d * d)) / (2 * a));
                    DisplayOutput($"{d}|{x1}|{x2}");
                    DisplayMessage(string.Empty);
                }
            }
        }
        catch (System.Exception)
        {
            DisplayMessage(messages[0]);
        }
    }
}
