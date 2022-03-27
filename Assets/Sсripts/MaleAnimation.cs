using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Health))]

public class MaleAnimation : MonoBehaviour
{
    private Animator _animator;
    private Health _health;
    private float _currentHealth;
    private float _minHealth;
    private float _maxHealth;

    private void Start()
    {
        _health = GetComponent<Health>();
        _animator = GetComponent<Animator>();
        _maxHealth = _health.MaxHealth;
        _minHealth = _health.MinHealth;
        _currentHealth = _maxHealth;
    }

    public void Animate(float newHealth)
    {
        if (newHealth == _minHealth)
            _animator.SetTrigger(AnimatorMale.Params.Die);
        else if (newHealth > _currentHealth)
            _animator.SetTrigger(AnimatorMale.Params.Heal);
        else if (newHealth < _currentHealth)
            _animator.SetTrigger(AnimatorMale.Params.Damage);
    }
}

public static class AnimatorMale
{
    public static class Params
    {
        public const string Damage = nameof(Damage);
        public const string Heal = nameof(Heal);
        public const string Die = nameof(Die);
    }

    public static class Male
    {
        public const string Idle = nameof(Idle);
        public const string Damage = nameof(Damage);
        public const string Heal = nameof(Heal);
        public const string Die = nameof(Die);
    }
}