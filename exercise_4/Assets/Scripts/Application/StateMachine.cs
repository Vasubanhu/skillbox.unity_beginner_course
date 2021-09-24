using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private GameObject[] screens;
    private GameObject _currentScreen;
    private int _index;

    private void Awake()
    {
        screens[_index].SetActive(true);
        _currentScreen = screens[_index];
    }

    public void ChangeScreen(GameObject screen)
    {
        if (screen != null)
        {
            _currentScreen.SetActive(false);
            screen.SetActive(true);
            _currentScreen = screen;
        }     
    }
}
