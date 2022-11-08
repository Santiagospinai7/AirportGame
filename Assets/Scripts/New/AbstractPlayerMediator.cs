using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Windows;

namespace ComputacionGrafica.Airport
{
    public abstract class AbstractPlayerMediator : AbstractPlayer
    {
        [SerializeField] protected PlayerMovementController _playerMovementController;
        [SerializeField] protected CharacterController _characterController;
        [SerializeField] protected NavMeshAgent _navMeshController;

        [SerializeField] private Transform _head;
        [SerializeField] private Transform _rightHand;
        [SerializeField] private Transform _rightFoot;
        [SerializeField] private Transform _leftFoot;
        [SerializeField] private Transform _centerFoots;
        [SerializeField] private Transform _followCameraTransform;
        [SerializeField] private Transform _lookAtCameraTransform;
        [SerializeField] protected CinemachineImpulseSource _cinemachineImpulseSource;
        public CinemachineFreeLook CinemachineFreeLook;

        public NavMeshAgent NavMeshAgentController => _navMeshController;
        public Transform FollowCameraTransform => _followCameraTransform;
        public Transform LookAtCameraTransform => _lookAtCameraTransform;
        public Transform Head => _head;
        public Transform RightHand => _rightHand;
        public Transform RightFoot => _rightFoot;
        public Transform LeftFoot => _leftFoot;
        public Transform CenterFoots => _centerFoots;

        public abstract void Configure(bool useNormalMove);

        public IInput GetInput(bool useNormalMove)
        {
            if (!useNormalMove)
            {
                return new UnityAIInputAdapter();
            }

            return new UnityInputAdapter();
        }

        public void SetMove(bool useNormalMove)
        {
            _playerMovementController.SetMove(useNormalMove);
        }

        public void StopAmimations()
        {
            _baseAnimator.SetBool("isSprinting", false);
            _baseAnimator.SetBool("isShuriken", false);
            _baseAnimator.SetBool("isHit", false);
            _baseAnimator.SetBool("isFalling", false);
        }
    }
}
