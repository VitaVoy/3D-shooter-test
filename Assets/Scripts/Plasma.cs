using UnityEngine;

namespace MyProject
{
    public class Plasma : MonoBehaviour
    {
        [SerializeField] private float _speed = 10f;
        [SerializeField] private int _damage = 20;
        [SerializeField] private ParticleSystem _particleSystem;

        public void Init()
        {
            Debug.Log("Create Plasma");
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
            Destroy(gameObject);
        }
    }
}
