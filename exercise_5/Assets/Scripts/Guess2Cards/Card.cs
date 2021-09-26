using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] private Sprite[] cardContent;
    [SerializeField] private Sprite cardBack;

    public int _cardType = 1;
    private Image _cardImage;
    private GameplayState _gamePlayState;

    private void Start()
    {
        _cardImage = GetComponent<Image>();
        _gamePlayState = FindObjectOfType<GameplayState>();
    }

    public void Swap()
    {
        if (_cardImage.sprite.Equals(cardBack))
        {
            _cardImage.sprite = cardContent[_cardType];
            _gamePlayState.Guess(this);
        }
    }

    public void SetDefaultImage()
    {
        _cardImage.sprite = cardBack;
    }
}
