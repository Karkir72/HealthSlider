using UnityEngine;

[RequireComponent(typeof(MaleAnimation))]

public class Health : MonoBehaviour
{
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private float _changingValue;

    private float _maxHealth = 100f;
    private float _minHealth = 0f;
    private MaleAnimation _animation;
    private float _health;

    private void Start()
    {
        _health = _maxHealth;
        _animation = GetComponent<MaleAnimation>();
    }

    public void Damage()
    {
        if (_health > 0)
        {            
            _health = Mathf.Clamp(_health - _changingValue, _minHealth, _maxHealth);
            _healthBar.ChangeValue(_health);
            _animation.Damage();

            if (_health == _minHealth)
            {
                _animation.Die();
            }
        }
    }

    public void Heal()
    {
        if (_health > 0)
        {
            _health = Mathf.Clamp(_health + _changingValue, _minHealth, _maxHealth);
            _healthBar.ChangeValue(_health);
            _animation.Heal();
        }
    }
}