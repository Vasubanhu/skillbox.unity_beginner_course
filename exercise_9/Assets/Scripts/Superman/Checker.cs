using UnityEngine;

public class Checker : MonoBehaviour
{
    private int _badGuyLayer = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == _badGuyLayer)
        {
            Destroy(other.gameObject);
        }
    }
}
