using UnityEngine;
using UnityEngine.AI;

namespace MyProject
{
    public class Boss : MonoBehaviour
    {
        [SerializeField] private int _hp;
        [SerializeField] private GameObject _missilePref;
        [SerializeField] private Transform _missileStartPosition;
        [SerializeField] private float _reloadTime = 1;
        [SerializeField] private Transform _target;
        [SerializeField] private Animator _animator;
        [SerializeField] private float _checkDisanceToPlayer = 15f;

        private int _maxHP = 1000;
        private bool _reload = true;
        private NavMeshAgent _agent;
        public GameObject player;
        private AudioSource _audioSource;

        public NavMeshAgent navMeshAgent;
        public Transform[] _waypoints;
        private int _randomSpot;
        int _CurrentWaypointIndex;

        private void Awake()
        {
            _hp = _maxHP;
            _agent = GetComponent<NavMeshAgent>();
            _agent.SetDestination(_target.position);
            _animator = GetComponent<Animator>();
            _randomSpot = Random.Range(0, _waypoints.Length);
            _audioSource = GetComponent<AudioSource>();
        }
        void Start()
        {
            navMeshAgent.SetDestination(_waypoints[0].position);
        }
        private void Update()
        {

            if (_checkDisanceToPlayer >= Vector3.Distance(transform.position, _target.position))
            {
                _agent.SetDestination(_target.position);
                _audioSource.Play();
            }
            else if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
            {
                _CurrentWaypointIndex = (_CurrentWaypointIndex + 1) % _waypoints.Length;
                navMeshAgent.SetDestination(_waypoints[_CurrentWaypointIndex].position);
                _animator.SetBool("Walk", true);
                _audioSource.Play();
            }
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

        private void OnTriggerStay(Collider other)
        {

            if (other.CompareTag("Player") && _reload)
            {
                Fire();
            }
        }
        private void Fire()
        {
            var missile = Instantiate(_missilePref, _missileStartPosition.position, transform.rotation);
            var e = missile.GetComponent<Missile>();
            e.Init();
            _reload = false;
            Invoke("Reload", _reloadTime);
        }
        private void Reload()
        {
            _reload = true;
        }
    }
}
