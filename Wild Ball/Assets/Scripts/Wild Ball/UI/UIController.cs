using UnityEngine;
using UnityEngine.UI;

namespace Prototype.WildBall
{
    public class UIController : MonoBehaviour
    {
        private Text _countdownPanelText;

        private void Awake()
        {
            _countdownPanelText = GameObject.Find(GlobalStringVariables.CountdownPanel).GetComponentInChildren<Text>();
        }

        public void Display(string value) => _countdownPanelText.text = value.ToString();          
    }
}
