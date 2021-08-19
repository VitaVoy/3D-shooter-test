using System;
using UnityEngine;

namespace MyProject
{

    public class Player : MonoBehaviour
    {
        [SerializeField] private int _hp;
        [SerializeField] private Animator _animator;

        private int _maxHP = 100;
        public static Action<int> changeHP;

        private void Awake()
        {
            _hp = _maxHP;
            _animator = GetComponent<Animator>();
        }

        public void TakeDamage(int damage)
        {
            _hp -= damage;
            changeHP?.Invoke(_hp);
            if (_hp == 0 || _hp < 0)
            {
                _animator.SetTrigger("Death");
                Death();
            }
        }
        private void Death()
        {
            Destroy(gameObject);
        }
        public void Treatment(int health)
        {
            if (_hp < 100)
            {
                _hp += health;
            }
        }
    }
}
