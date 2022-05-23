using UnityEngine;

namespace Prototype.WildBall
{
    public class Tooltip : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(GlobalStringVariables.Player))
            {
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag(GlobalStringVariables.Player))
            {
                gameObject.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }
}
