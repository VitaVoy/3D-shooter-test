using UnityEngine;
using UnityEngine.UI;

namespace MyProject
{
    public class HealthBar : MonoBehaviour
    {
        public Image _healtBar;
        public float _fill;

        private void Awake()
        {
            Player.changeHP += UpdateHP;
        }
        void Start()
        {
            _fill = 1f;
        }
        private void UpdateHP(int hp)
        {
            _healtBar.fillAmount = hp * 0.01f;
        }
    }
}
