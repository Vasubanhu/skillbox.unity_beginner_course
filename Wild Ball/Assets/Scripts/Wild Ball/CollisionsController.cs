using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Prototype.WildBall
{
    public class CollisionsController : MonoBehaviour
    {
        private LevelSelection _instance;
        private Animator _animator;
        private CameraMovement _camera;
        private List<Transform> _childs;

        private void Awake()
        {
            _camera = FindObjectOfType<CameraMovement>();
            _instance = FindObjectOfType<LevelSelection>();

            _childs = transform.parent.Cast<Transform>().ToList();

            foreach (var item in _childs)
            {
                print(item);
            }       

            if (_instance.GetSceneIndex() == 1)
            {
                _animator = GameObject.Find(GlobalStringVariables.Elevator).GetComponent<Animator>();
            }        
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag(GlobalStringVariables.Mokujin))
            {
                print("You are dead!");
                _instance.LoadCurrentScene();
            }

            if (collision.gameObject.name == GlobalStringVariables.Elevator)
            {
                _animator.SetTrigger(GlobalStringVariables.Ascent);
            }

            if (collision.gameObject.layer == 4 && _childs != null)
            {
                print("Collision with lava!");

                _childs[0].gameObject.SetActive(false);
                _childs[1].gameObject.SetActive(false);
                _childs[2].transform.position = gameObject.transform.position;
                _childs[2].gameObject.SetActive(true);

                _camera.enabled = false;

                Destroy(transform.parent.gameObject, 4f);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag(GlobalStringVariables.Player))
            {
                print("You are dead!");
                _instance.LoadCurrentScene();
            }
        }
    }
}
