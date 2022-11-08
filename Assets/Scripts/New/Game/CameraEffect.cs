using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ComputacionGrafica.Airport
{
    public class CameraEffect : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private float _cameraShakeTime = 1f;
        [SerializeField] private float _cameraShakeDuration = 0.5f;
        [SerializeField] private bool _isShake;

        private float _currentCameraShakeTime;
        private Quaternion _cameraInitialRotation;

        private void Awake()
        {
            _camera = GetComponent<Camera>();
            _cameraInitialRotation = _camera.transform.rotation;
            _currentCameraShakeTime = _cameraShakeTime;
        }

        public void Reset()
        {
            _currentCameraShakeTime = _cameraShakeTime;
        }

        public void Update()
        {
            if (_isShake)
            {
                if (_currentCameraShakeTime < _cameraShakeDuration)
                {
                    _currentCameraShakeTime += Time.deltaTime;
                    CameraShake();
                }
                else if (_camera.transform.localRotation != _cameraInitialRotation)
                {
                    _camera.transform.localRotation = _cameraInitialRotation;
                }
            }
        }

        public void SetShake1()
        {
            if (!_isShake)
            {
                return;
            }

            _currentCameraShakeTime = 0f;
        }

        private void CameraShake()
        {
            Vector3 euler = _camera.transform.eulerAngles;
            float shake = Random.Range(-1f, 1f);

            euler.x += shake;

            euler.x = Mathf.Clamp(euler.x, 33f, 34f);

            _camera.transform.localRotation = Quaternion.Euler(euler);
        }
    }
}
