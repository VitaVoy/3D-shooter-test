using UnityEngine;

namespace MyProject
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Vector3 _targetRotation;

        private bool _isOpen = false;

        private void Update()
        {
            if (_isOpen)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(_targetRotation), _speed * Time.deltaTime);
            }
        }

        public void Open()
        {
            _isOpen = true;
        }
    }
}