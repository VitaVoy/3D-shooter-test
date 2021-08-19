using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace MyProject
{

    public class Enemy : MonoBehaviour
    {
        [SerializeField] private int _hp;
        [SerializeField] private Transform _target;
        [SerializeField] private Color _deathColor;
        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private float _checkDisanceToPlayer = 15f;
        [SerializeField] private GameObject _bulletPref;
        [SerializeField] private Transform _bulletStartPosition;
        [SerializeField] private float _reloadTime;
        [SerializeField] private ParticleSystem _particleSystem;


        private bool _reload = true;

        private int _maxHP = 100;
        private NavMeshAgent _agent;


        private void Awake()
        {
            _hp = _maxHP;
            _agent = GetComponent<NavMeshAgent>();
            _agent.SetDestination(_target.position);
        }

        public void Init(Transform target)
        {
            _target = target;
        }

        private void Update()
        {
            if (_checkDisanceToPlayer >= Vector3.Distance(transform.position, _target.position))
            {
                _agent.SetDestination(_target.position);
                Fire();
            }
        }
        public void TakeDamage(int damage)
        {
            _particleSystem.Play();
            _hp -= damage;
            if (_hp < 0)
            {
                StartCoroutine(Death(0.01f));
            }
        }
        private IEnumerator Death(float changeTime)
        {
            var material = _meshRenderer.material;
            while (material.color != _deathColor)
            {
                material.color = Color.Lerp(material.color, _deathColor, changeTime);
                yield return null;
            }
            Destroy(gameObject);
        }

        private void Fire()
        {
            var bullet = Instantiate(_bulletPref, _bulletStartPosition.position, transform.rotation);
            var b = bullet.GetComponent<Bullet>();
            b.Init();
            _reload = false;
            Invoke("Reload", _reloadTime);
        }

        private void Reload()
        {
            _reload = true;
        }
    }
}
