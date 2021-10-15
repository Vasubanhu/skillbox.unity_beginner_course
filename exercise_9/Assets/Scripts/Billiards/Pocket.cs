using UnityEngine;

public class Pocket : MonoBehaviour
{
    private static int _count;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == GameManager._ballLayer)
        {
            print($"В лузу попало {++_count}.");
            Destroy(other.gameObject, 3f);
        }
    }
}
