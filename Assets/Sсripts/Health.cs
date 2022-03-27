using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Health : MonoBehaviour
{
    [SerializeField] private Slider _slider;
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
            _animator.SetTrigger(AnimatorMale.Params.Hit);
            float endHealth = _health - _changingValue < 0 ? 0 : _health - _changingValue;
            StartCoroutine(ChangeHealth(_health, endHealth));
            _health = endHealth;

            if (_health == 0)
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
            float endHealth = _health + _changingValue > 100 ? 100 : _health + _changingValue;
            StartCoroutine(ChangeHealth(_health, endHealth));
            _health = endHealth;
        }
    }

    private IEnumerator ChangeHealth(float startValue, float endValue)
    {
        float currentValue = startValue;

        while (currentValue != endValue)
        {
            float minChanges = 0.1f;
            currentValue = Mathf.MoveTowards(currentValue, endValue, minChanges);
            _slider.value = currentValue / _maxHealth;
            yield return null;
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
