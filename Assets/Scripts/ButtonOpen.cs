
using UnityEngine;

namespace MyProject
{
    public class ButtonOpen : MonoBehaviour
    {
        [SerializeField] private Door _door;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _door.Open();
            }
        }
    }
}
