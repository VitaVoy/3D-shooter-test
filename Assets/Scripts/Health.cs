using UnityEngine;

namespace MyProject
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int _health;
        [SerializeField] private int _maxHealth;

        //public int _health;
        //public int _maxHealth;

        public void TakeDamage(int damage)
        {
            _health -= damage;
            if (_health <= 0)
            {
                Destroy(gameObject);
            }
        }

        public void SetHealth(int bonusHealth)
        {
            _health += bonusHealth;
            if (_health > _maxHealth)
            {
                _health = _maxHealth;
            }
        }
    }
}
