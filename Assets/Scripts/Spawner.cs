using System.Collections;
using UnityEngine;

namespace MyProject
{
    public class Spawner : MonoBehaviour
    {
        public Transform SpawnPos;
        public GameObject Enemy;

        private float _maxCount = 3;

        private void Start()
        {
            StartCoroutine(SpawnCD());
        }

        private void Repeat()
        {
            StartCoroutine(SpawnCD());
            _maxCount += 1;
        }
        IEnumerator SpawnCD()
        {
            if (_maxCount <= 3)
            {
                yield return new WaitForSeconds(5);
                Instantiate(Enemy, SpawnPos.position, Quaternion.identity);
                Repeat();
            }
        }
    }
}
