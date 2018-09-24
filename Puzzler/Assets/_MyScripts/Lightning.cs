using System.Linq;
using UnityEngine;

namespace _MyScripts {
    [RequireComponent(typeof(Light))]
    public class Lightning : MonoBehaviour {
        private Light       _light;
        private AudioSource _audioSource;

        private void Awake() {
            _light         = GetComponent<Light>();
            _light.enabled = false;
            if (_light.type != LightType.Directional) _light.type = LightType.Directional;

            _audioSource = GetComponents<AudioSource>().Last();
        }

        [SerializeField] private float _minTime    = 0.5f;
        [SerializeField] private float _threshhold = 0.75f;

        private float _lastTimeStamp;

        private void Update() {
            if (Time.time - _lastTimeStamp < _minTime) return;
            if (Random.value > _threshhold) {
                if (!_audioSource.isPlaying || _audioSource.time > _audioSource.clip.length/3)
                    _audioSource.Play();
                _light.enabled = true;
            } else {
                _light.enabled = false;
            }

            _lastTimeStamp = Time.time;
        }
    }
}