using UnityEngine;

namespace MyProject
{
    public class PlasmaTurFire : MonoBehaviour
    {
        [SerializeField] private GameObject _plasmaPref;
        [SerializeField] private Transform _plasmaStartPosition;
        [SerializeField] private float _reloadTime = 1;
        [SerializeField] private int _hp;

        public Transform player;
        private bool _reload = true;
        private int _maxHP = 100;

        private void Awake()
        {
            _hp = _maxHP;
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player") && _reload)
            {
                Fire();
            }
        }
        private void Fire()
        {
            var plasma = Instantiate(_plasmaPref, _plasmaStartPosition.position, transform.rotation);
            var d = plasma.GetComponent<Plasma>();
            d.Init();
            _reload = false;
            Invoke("Reload", _reloadTime);
        }
        private void Reload()
        {
            _reload = true;
        }
        public void TakeDamage(int damage)
        {
            _hp -= damage;
            if (_hp == 0 || _hp < 0)
            {
                Death();
            }
        }
        private void Death()
        {
            Destroy(gameObject);
        }
    }
}
