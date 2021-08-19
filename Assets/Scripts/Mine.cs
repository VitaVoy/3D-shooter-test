using UnityEngine;

namespace MyProject
{
    public class Mine : MonoBehaviour
    {
        [SerializeField] private float _speed;
        public void Init()
        {
            Debug.Log("Create Mine");
        }
        void Update()
        {
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        }
    }
}
