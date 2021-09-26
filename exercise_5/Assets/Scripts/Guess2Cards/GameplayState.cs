using UnityEngine;
using UnityEngine.UI;

public class GameplayState : MonoBehaviour
{
    [SerializeField] private Card[] cards;
    [SerializeField] private Text _scoreText;
    [SerializeField] private int _score;

    private Card _firstCard;
    private Card _secondCard;
    private int[] cardTypes = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4};

    private void Start()
    {
        SetScore(_score);
        ShuffleCards();  
    }

    public void Restart()
    {
        ShuffleCards();

        foreach (Card card in cards)
        {
            card.SetDefaultImage();
        }
    }

    private void SetScore(int score)
    {
        _scoreText.text = $"Score: {score}";
    }

    private void SetCardType()
    {
        for (int i = 0; i < cards.Length; i++)
        {
            cards[i]._cardType = cardTypes[i];
        }
    }

    private void ShuffleCards()
    {
        // Алгоритм тасования Фишера — Йейтса
        System.Random random = new System.Random();

        for (int i = cardTypes.Length - 1; i >= 1; i--)
        {
            int j = random.Next(i + 1);

            int temp = cardTypes[j];
            cardTypes[j] = cardTypes[i];
            cardTypes[i] = temp;
        }

        SetCardType();
    }

    public void Guess(Card card)
    {
        if (_firstCard == null)
        {
            _firstCard = card;
        }
        else if (_secondCard == null)
        {
            _secondCard = card;

            Check();
        }
        else
        {
            _firstCard.SetDefaultImage();
            _secondCard.SetDefaultImage();

            _firstCard = null;
            _secondCard = null;

            Guess(card);
        }
    }

    private void Check()
    {
        if (_firstCard._cardType == _secondCard._cardType)
        {
            _score++;
            // Угаданную пару карт оставляем открытой
            _firstCard = null;
            _secondCard = null;

            SetScore(_score);
        }
        else
        {
            _score--;
            SetScore(_score);
        }
    }
}
