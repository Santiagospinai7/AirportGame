using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

namespace ComputacionGrafica.Airport
{
    public class PlayerNormalMovement : MonoBehaviour, IPlayerMovement
    {
        private AbstractPlayerMediator _player;
        private PlayerMovementController _playerMovementController;
        private CharacterController _characterController;
        private Vector3 _moveDirection = Vector3.zero;
        private Vector3 _targetDirection;
        private Quaternion _freeRotation;
        private IInput _input;
        private IDetector _detector;
        private bool _isPreparingJump;
        private float _jumpCurrentDistance;
        private float _direction = 0f;

        public float GetDirection() => _direction;

        public float GetSpeed()
        {
            float speed = Mathf.Abs(_input.GetDirection().x) + Mathf.Abs(_input.GetDirection().z);
            if (_input.RunActionPressed())
            {
                speed *= _playerMovementController.RunSpeed;
                speed = Mathf.Clamp(speed, 0f, _playerMovementController.RunSpeed);
                return speed;
            }

            speed *= _playerMovementController.Speed;
            speed = Mathf.Clamp(speed, 0f, _playerMovementController.Speed);
            return speed;
        }

        public bool GetSprinting()
        {
            return _input.RunActionPressed();
        }

        public void Configure(AbstractPlayerMediator player, PlayerMovementController playerMovementController)
        {
            _player = player;
            _playerMovementController = playerMovementController;
            _detector = _playerMovementController.Detector;
            _characterController = _playerMovementController.CharacterController;
            _input = new UnityInputAdapter();

            Init();
        }

        public void Init()
        {

        }

        public void Release()
        {

        }

        public void Move()
        {
            _direction = 0;

            UpdateMove();
            Rotate();

            if (_detector.IsDetected())
            {
                if (GetSpeed() == 0 || _player.IsAttacking)
                {
                    _direction = -1;
                    transform.LookAt(_detector.ObjectDetected().transform.position);
                }

            }
        }

        private void UpdateMove()
        {
            if (_characterController.isGrounded)
            {
                _moveDirection = transform.forward * GetSpeed();
                if (!_isPreparingJump && !_playerMovementController.IsJumping && _input.JumpActionPressed())
                {
                    _isPreparingJump = true;
                    _jumpCurrentDistance = transform.position.y + _playerMovementController.JumpDistance;
                    _playerMovementController.StartJump();
                }
            }

            if (_playerMovementController.IsJumping)
            {
                if (_moveDirection.y >= _jumpCurrentDistance)
                {
                    _jumpCurrentDistance = 0f;
                    _isPreparingJump = false;
                    _playerMovementController.IsJumping = false;

                }
                _moveDirection.y += _playerMovementController.Gravity * Time.deltaTime * _playerMovementController.SmoothJump;

                //_playerMovementController.IsFalling();
            }
            else
            {
                _moveDirection.y -= _playerMovementController.Gravity * Time.deltaTime * _playerMovementController.FallingForce;
            }

            _characterController.Move(_moveDirection * Time.deltaTime);
        }

        private void Rotate()
        {
            // Update target direction relative to the camera view (or not if the Keep Direction option is checked)
            UpdateTargetDirection();
            if (_input.GetDirection() != Vector3.zero && _targetDirection.magnitude > 0.1f)
            {
                Vector3 lookDirection = _targetDirection.normalized;
                _freeRotation = Quaternion.LookRotation(lookDirection, transform.up);
                var diferenceRotation = _freeRotation.eulerAngles.y - transform.eulerAngles.y;
                var eulerY = transform.eulerAngles.y;

                if (diferenceRotation < 0 || diferenceRotation > 0) eulerY = _freeRotation.eulerAngles.y;
                var euler = new Vector3(0, eulerY, 0);

                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(euler), _playerMovementController.TurnSpeed * Time.deltaTime);
            }
        }

        private void UpdateTargetDirection()
        {
            var forward = _playerMovementController.MainCamera.transform.TransformDirection(Vector3.forward);
            forward.y = 0;

            //get the right-facing direction of the referenceTransform
            var right = _playerMovementController.MainCamera.transform.TransformDirection(Vector3.right);

            // determine the direction the player will face based on input and the referenceTransform's right and forward directions
            _targetDirection = _input.GetDirection().x * right + _input.GetDirection().z * forward;
        }
    }
}
