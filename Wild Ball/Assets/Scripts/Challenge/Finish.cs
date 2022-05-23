using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public static Vector3 _finish;
    public static int _index = 1;   
    public static int _sceneCount;

    private void Awake()
    {
        _sceneCount = SceneManager.sceneCountInBuildSettings;
        _finish = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player" && _index < _sceneCount)
        {
            SceneManager.LoadSceneAsync(_index++);
        }
        else
        {
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
            Movement._animator.SetBool("Moving", false);
            other.GetComponent<Movement>().enabled = false;

            print("Finish!");
            Destroy(this);
        }
    }
}
