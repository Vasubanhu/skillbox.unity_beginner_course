using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Prototype.WildBall
{
    public class LevelSelection : MonoBehaviour
    {
        private readonly int _nextIndex = 1;
        private int _sceneCount;
        private readonly int _time = 5;
        private UIController _uiController;

        private void Awake()
        {
            _uiController = GetComponent<UIController>();
            _sceneCount = SceneManager.sceneCountInBuildSettings;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag(GlobalStringVariables.Player) && _nextIndex < _sceneCount)
            {
                StartCoroutine(nameof(LoadNextLevel));
            }
        }

        private IEnumerator LoadNextLevel()
        {
            for (int i = _time; i > 0; i--)
            {
                yield return new WaitForSecondsRealtime(1);  
                _uiController.Display(i.ToString());
            }

            LoadScene(SceneManager.GetActiveScene().buildIndex + _nextIndex);
            StopCoroutine(nameof(LoadNextLevel));
        }

        public void LoadScene(int sceneIndex)
        {
            string pathToScene = SceneUtility.GetScenePathByBuildIndex(sceneIndex);
            string sceneName = System.IO.Path.GetFileNameWithoutExtension(pathToScene);
            SceneManager.LoadSceneAsync(sceneName);
        }

        public void LoadCurrentScene() => SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);

        public int GetSceneIndex() => SceneManager.GetActiveScene().buildIndex;
    }
}
