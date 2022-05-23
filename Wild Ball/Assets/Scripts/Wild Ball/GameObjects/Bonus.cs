using UnityEngine;
using System.Linq;
using System.Collections.Generic;

namespace Prototype.WildBall
{
    public class Bonus : BaseObject
    {
        private List<Transform> _childs;

        protected override void Start()
        {
            _childs = transform.Cast<Transform>().ToList();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(GlobalStringVariables.Player) && _childs != null)
            {                              
                _childs[0].gameObject.SetActive(false);
                _childs[1].gameObject.SetActive(false);
                _childs[2].gameObject.SetActive(true);

                Destroy(this);
                Destroy(gameObject, 2f);
            }
        }
    }
}
