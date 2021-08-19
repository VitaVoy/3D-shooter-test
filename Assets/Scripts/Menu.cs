using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MyProject
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private Button _start;
        [SerializeField] private Button _exit;
        [SerializeField] private Toggle _mute;
        [SerializeField] private Slider _volume;

        private bool _isMuted;
        private float _volumeNum;
        private void Awake()
        {
            _start.onClick.AddListener(StartGame);
            _exit.onClick.AddListener(ExitGame);
            _mute.onValueChanged.AddListener(Mute);
            _volume.onValueChanged.AddListener(Volume);
        }

        private void StartGame()
        {
            SceneManager.LoadScene("FirstLevel");
        }

        private void ExitGame()
        {
            Application.Quit();
        }

        private void Mute(bool value)
        {
            _isMuted = value;
        }

        private void Volume(float value)
        {
            _volumeNum = value;
        }
    }
}
