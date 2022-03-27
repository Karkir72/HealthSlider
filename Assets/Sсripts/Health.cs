using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Health : MonoBehaviour
{
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private float _changingValue;

    private float _maxHealth = 100f;
    private bool _isAlive = true;

    private float _health;
    private Animator _animator;

    private void Start()
    {
        _health = _maxHealth;
        _animator = GetComponent<Animator>();
    }

    public void Hit()
    {
        if (_isAlive)
        {
            float minHealth = 0f;

            _animator.SetTrigger(AnimatorMale.Params.Hit);
            _health = _health - _changingValue < minHealth ? minHealth : _health - _changingValue;
            _healthBar.ShowNewHealth(_health);

            if (_health == minHealth)
            {
                _isAlive = false;
                _animator.SetTrigger(AnimatorMale.Params.Die);
            }
        }
    }

    public void Cure()
    {
        if (_isAlive)
        {
            _animator.SetTrigger(AnimatorMale.Params.Cure);
            _health = _health + _changingValue > _maxHealth ? _maxHealth : _health + _changingValue;
            _healthBar.ShowNewHealth(_health);
        }
    }
}

public static class AnimatorMale
{
    public static class Params
    {
        public const string Hit = nameof(Hit);
        public const string Cure = nameof(Cure);
        public const string Die = nameof(Die);
    }

    public static class Male
    {
        public const string Idle = nameof(Idle);
        public const string Hit = nameof(Hit);
        public const string Cure = nameof(Cure);
        public const string Death = nameof(Death);
    }
}
