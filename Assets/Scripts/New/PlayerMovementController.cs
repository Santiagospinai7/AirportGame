using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace ComputacionGrafica.Airport
{
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(NavMeshAgent))]
    public class PlayerMovementController : MonoBehaviour
    {
        [Header("Moving")]
        public float Speed = 2.0F;
        public float RunSpeed = 4.5f;
        public float TurnSpeed = 10.0f;

        [Header("Jumping")]
        public bool IsJumping;
        public bool IsFalling;
        public bool IsReallyJumping;
        public bool IsReallyGrounded;
        public float WaitForJump = 0.15f;
        public float JumpDistance = 2.5f;
        public float SmoothJump = 10.0f;
        public float FallingForce = 2.0f;
        public float JumpTime = 0.7f;
        [Range(0.17f, 0.25f)]
        public float GroundTolerance = 0.2f;
        public LayerMask GroundMask;
        [SerializeField] private Transform _groundCheck;
        public readonly float Gravity = 9.81f;

        [Space(10)]
        public Transform TargetLookAt;
        public GameObject TargetDestination;

        public IDetector Detector;
        [HideInInspector] public Camera MainCamera;
        [HideInInspector] public CharacterController CharacterController;
        [HideInInspector] public NavMeshAgent NavMeshAgent;

        [SerializeField] private Animator _baseAnimator;
        private AbstractPlayerMediator _player;
        private IPlayerMovement _playerNormalMovement;
        private IPlayerMovement _playerAIMovement;
        private IPlayerMovement _currentMovement;

        public void Configure(AbstractPlayerMediator player, IDetector detector, CharacterController characterController, NavMeshAgent navMeshAgent)
        {
            _player = player;
            Detector = detector;
            CharacterController = characterController;
            NavMeshAgent = navMeshAgent;
            MainCamera = Camera.main;

            TargetDestination = GameObject.Find("ArrowEffectOnClick");
            _playerNormalMovement = gameObject.AddComponent<PlayerNormalMovement>();
            _playerNormalMovement.Configure(_player, this);
        }

        void Update()
        {
            if (NavMeshAgent.enabled)
            {
                if (IsReallyGrounded)
                {
                    GetComponentInChildren<Animator>().SetBool("isGrounded", true);
                }
                else
                {
                    GetComponentInChildren<Animator>().SetBool("isGrounded", false);
                }

                if (IsFalling && !IsReallyJumping && !IsReallyGrounded)
                {
                    GetComponentInChildren<Animator>().Play("Falling");
                }
            }
            else
            {
                if (!CharacterController.isGrounded)
                {
                    GetComponentInChildren<Animator>().SetBool("isGrounded", false);

                    if (!IsReallyJumping)
                    {
                        IsFalling = true;
                    }

                    if (IsFalling && !IsReallyJumping)
                    {
                        GetComponentInChildren<Animator>().Play("Falling");
                    }
                }
                else
                {
                    GetComponentInChildren<Animator>().SetBool("isGrounded", true);
                    IsFalling = false;
                }
            }
        }

        public bool IsGrounded()
        {
            //return Physics.Raycast(transform.position, Vector3.down, GroundTolerance, GroundMask);
            return Physics.CheckSphere(_groundCheck.position, GroundTolerance, GroundMask);
        }

        public void SetMove(bool useNormalMove)
        {
            if (_currentMovement != null)
            {
                _currentMovement.Release();
            }

            _currentMovement = useNormalMove ? _playerNormalMovement : _playerAIMovement;
            _currentMovement.Init();
        }

        public void Move()
        {
            if (_currentMovement != null)
            {
                _currentMovement.Move();

                _baseAnimator.SetFloat("Direction", _currentMovement.GetDirection());
                _baseAnimator.SetFloat("Speed", _currentMovement.GetSpeed());
                _baseAnimator.SetBool("isSprinting", _currentMovement.GetSprinting());
            }
        }

        public bool IsSprinting()
        {
            return IsGrounded() && (_currentMovement.GetSpeed() >= RunSpeed);
        }

        public void StartJump()
        {
            IsReallyJumping = true;
            _baseAnimator.SetTrigger("isJumping");
            StartCoroutine(Jumping());
        }

        private IEnumerator Jumping()
        {
            yield return new WaitForSeconds(WaitForJump);

            IsJumping = true;

            yield return new WaitForSeconds(JumpTime);

            IsReallyJumping = false;
        }

        public void EndJump()
        {
            //GetComponentInChildren<Animator>().SetBool("isGrounded", true);

            GetComponentInChildren<Animator>().Play("Landing");
        }


        public void SetCameraYPosition()
        {
            FindObjectOfType<CameraFollow>().AlignIfJumping(this.transform.position.y);
        }
    }
}
