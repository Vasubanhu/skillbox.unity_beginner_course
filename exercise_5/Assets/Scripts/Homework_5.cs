using UnityEngine;
using UnityEngine.UI;

public class Homework_5 : MonoBehaviour
{
    [Header("Factorial:"), Range(0, 10), SerializeField] private int _number;
    [SerializeField] private InputField _inputField;
    [SerializeField] private Text _outputText;

    private void Start()
    {
        #region 1.Четные числа

        int min = 1;
        int max = 10;

        Debug.Log($"Четные числа в диапозоне от {min} до {max}:\n");

        for (int i = min; i <= max; i++)
        {
            if (IsEven(i))
            {
                Debug.Log($"{i}\n");
            }
        }

        #endregion
        #region 2.Таблица умножения

        Debug.Log($"Таблица умножения от {min} до {max}:\n");

        for (int i = min; i <= max; i++)
        {
            for (int j = 1; j <= max; j++)
            {
                int result = i * j;
                Debug.Log($"{i} x {j} = {result}\n");
            }
        }
        #endregion
        #region 3.Факториал

        Debug.Log($"Факториал числа {_number} = {Factorial(_number)}\n");

        #endregion
        #region 4.Числа, кратные 3 или 5
        /* 
           Если выписать все натуральные числа меньше 10, кратные 3 или 5, то получим 3, 5, 6 и 9.
           Сумма этих чисел равна 23. Найдите сумму всех чисел меньше 1000, кратных 3 или 5.
        */
        int sum = 0;

        for (int i = 1; i < 1000; i++)
        {        
            if (IsEven3or5(i))
            {
                sum += i;
            }
        }

        Debug.Log($"Cумма всех чисел меньше 1000, кратных 3 или 5 = {sum}\n ");

        #endregion
        #region 5.Четные числа Фибоначчи
        /* Каждый следующий элемент ряда Фибоначчи получается при сложении двух предыдущих. 
           Начиная с 1 и 2, первые 10 элементов будут:

           1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...

           Найдите сумму всех четных элементов ряда Фибоначчи, которая не превышает четыре миллиона.
        */
        int sum_f = 0;
        int max_f = 4000000;

        for (int i = 1; sum_f < max_f; i++)
        {

            if (IsEven(Fibonacci(i)))
            {
                sum_f += Fibonacci(i);
            }
        }      
        
        Debug.Log($"Cумма всех четных элементов ряда Фибоначчи, которая не превышает {max_f} = {sum_f}\n ");

        #endregion
    }

    #region Methods

    private bool IsEven(int number)
    {
        bool result = number % 2 == 0 ? true : false;
        return result;
    }
    private bool IsEven3or5(int number)
    {
        bool result = number % 3 == 0 || number % 5 == 0 ? true : false;
        return result;
    }

    private int Factorial(int number)
    {

        if (number == 0 || number == 1)
        {
            return 1;
        }
        else
        {
            int result = 1;

            for (int i = 2; i <= number; i++)
            {
                result *= i;
            }

            return result;
        }
    }

    public void Factorial_f()
    {
        _outputText.text = $"{_inputField.text}! = {Factorial(int.Parse(_inputField.text))}";
    }

    private int Fibonacci(int number)
    {
        int a = 0;
        int b = 1;
        int temp;

        for (int i = 0; i <= number; i++)
        {
            temp = a;
            a = b;
            b += temp;
        }

        return a;
    }

    #endregion

}
