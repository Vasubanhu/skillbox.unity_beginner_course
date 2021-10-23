using UnityEngine;

public class Gravity : MonoBehaviour
{
    private void Awake()
    {
        Physics.gravity = new Vector3(7f, -9.81f, 0f);
    }
}
