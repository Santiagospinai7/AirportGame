using UnityEngine;

namespace ComputacionGrafica.Airport
{
    public abstract class AbstractPlayer : MonoBehaviour
    {
        [SerializeField] private bool _isDead;
        [SerializeField] private float _maxHealth = 100f;
        [SerializeField] private float _currentHealth = 100f;
        [SerializeField] protected FieldOfViewDetector _detector;
        [SerializeField] protected Animator _baseAnimator;
        [SerializeField] protected AudioSource _audio;

        protected bool _canMove;
        public bool IsSprinting { get; set; }
        public bool IsJumping { get; set; }
        public bool IsDead { get => _isDead; set => _isDead = value; }

        public bool CanMove { get; set; }

        protected IInput _input;

        public string Id { get; set; }
        public bool IsAttacking { get; set; }
        public bool IsLocal { get; set; }
        public abstract void Init();

        public abstract void ReceiveDamage(float damage, string keyFx, Vector3 target);

        public abstract void OnDead();
    }
}