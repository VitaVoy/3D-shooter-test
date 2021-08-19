using UnityEngine;

namespace MyProject
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private int _damage = 20;

        public void Init()
        {
            Debug.Log("Create Bullet");

        }

        private void Update()
        {
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                other.GetComponent<Enemy>().TakeDamage(_damage);
            }
            else if (other.CompareTag("Player"))
            {
                other.GetComponent<Player>().TakeDamage(_damage);
            }
            else if (other.CompareTag("Boss"))
            {
                other.GetComponent<Boss>().TakeDamage(_damage);
            }
            else if (other.CompareTag("PlasmaTur"))
            {
                other.GetComponent<PlasmaTurFire>().TakeDamage(_damage);
            }


            Destroy(gameObject);
        }
    }
}
