using UnityEngine;

namespace MyProject
{
    public class FirstAidKit : MonoBehaviour
    {
        [SerializeField] private int _health;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<Player>().Treatment(_health);
            }
            Destroy(gameObject);
        }
    }
}
