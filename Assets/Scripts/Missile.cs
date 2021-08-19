using UnityEngine;

namespace MyProject
{
    public class Missile : MonoBehaviour
    {
        [SerializeField] private float _speed = 5f;
        [SerializeField] private int _damage = 50;

        public void Init()
        {
            Debug.Log("Create Missile");
        }

        void Update()
        {
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<Player>().TakeDamage(_damage);
            }

            if (!other.CompareTag("Boss"))
            {
                Destroy(gameObject);
            }
        }
    }
}
