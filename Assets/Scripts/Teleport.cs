using UnityEngine;

namespace MyProject
{
    public class Teleport : MonoBehaviour
    {
        public bool _teleported = false;
        public Teleport _target;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (!_teleported)
                {
                    _target._teleported = true;
                    other.gameObject.transform.position = _target.gameObject.transform.position;
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _teleported = false;

            }
        }
    }
}
