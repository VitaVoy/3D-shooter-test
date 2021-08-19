using UnityEngine;

namespace MyProject
{

    public class Move : MonoBehaviour
    {
        [SerializeField] private GameObject _bulletPref;
        [SerializeField] private Transform _bulletStartPosition;
        [SerializeField] private GameObject _minePref;
        [SerializeField] private Transform _mineStartPosition;
        [SerializeField] private float _speedMove;
        [SerializeField] private float _reloadTime = 1;

        private Vector3 _dir;
        private bool _reload = true;
        private float _speedWalk = 3;
        private float _speedRun = 10;
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }


        private void Update()
        {
            _dir.x = Input.GetAxis("Horizontal");
            _dir.z = Input.GetAxis("Vertical");

            if (Input.GetKeyDown(KeyCode.Mouse0) && _reload)
            {
                RaycastFire();
                _audioSource.Play();
            }

            else if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                Mine();
            }

            Debug.DrawRay(_bulletStartPosition.position, transform.forward, Color.red);
        }

        private void FixedUpdate()
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _speedMove = _speedRun;
            }
            else
            {
                _speedMove = _speedWalk;
            }
            var speed = _dir * _speedMove * Time.fixedDeltaTime;
            transform.Translate(speed);
        }

        private void Fire()
        {
            var bullet = Instantiate(_bulletPref, _bulletStartPosition.position, transform.rotation);
            var b = bullet.GetComponent<Bullet>();
            b.Init();
            _reload = false;
            Invoke("Reload", _reloadTime);
        }

        private void RaycastFire()
        {
            RaycastHit hit;
            var rayCast = Physics.Raycast(_bulletStartPosition.position, transform.forward, out hit, Mathf.Infinity);

            if (rayCast)
            {
                if (hit.collider.CompareTag("Enemy"))
                    hit.collider.GetComponent<Enemy>().TakeDamage(50);
                else if (hit.collider.CompareTag("PlasmaTur"))
                    hit.collider.GetComponent<PlasmaTurFire>().TakeDamage(50);
                else if (hit.collider.CompareTag("Boss"))
                    hit.collider.GetComponent<Boss>().TakeDamage(50);

                _reload = false;
                Invoke("Reload", _reloadTime);
            }

        }

        private void Mine()
        {
            var mine = Instantiate(_minePref, _mineStartPosition.position, Quaternion.identity);
            var c = mine.GetComponent<Mine>();
            c.Init();
        }
        private void Reload()
        {
            _reload = true;
        }
    }
}
