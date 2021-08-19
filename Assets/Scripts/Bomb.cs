using UnityEngine;

namespace MyProject
{
    public class Bomb : MonoBehaviour
    {
        [SerializeField] private int _damage = 50;

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
