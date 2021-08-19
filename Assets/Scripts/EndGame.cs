using UnityEngine;

namespace MyProject
{
    public class EndGame : MonoBehaviour
    {
        [SerializeField] private GameObject EndIm;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                EndIm.SetActive(true);
            }
        }
    }
}