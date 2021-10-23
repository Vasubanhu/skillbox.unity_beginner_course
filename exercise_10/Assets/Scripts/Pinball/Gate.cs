using UnityEngine;

public class Gate : MonoBehaviour
{
    static public GameObject PlungerGate;

    private void Awake()
    {
        PlungerGate = gameObject;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            PlungerGate.SetActive(false);
        }
    }
}
