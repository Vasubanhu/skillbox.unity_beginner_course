using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameObjectPanel; 

    private void OnTriggerEnter(Collider other) => StartCoroutine(nameof(GameOver));

    public void Restart() => SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);

    private IEnumerator GameOver()
    {
        yield return new WaitForSecondsRealtime(3);
        StopCoroutine(nameof(GameOver));
        _gameObjectPanel.SetActive(true);
    }
}
