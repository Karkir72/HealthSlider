using UnityEngine.Events;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _damageValue;
    [SerializeField] private UnityEvent<float> _changed;

    private float _health;
    public float MaxHealth { get; private set; } = 100f;
    public float MinHealth { get; private set; } = 0f;

    private void Start()
    {
        _health = MaxHealth;
    }

    public void Damage()
    {
        if (_health > MinHealth)
        {            
            _health = Mathf.Clamp(_health - _damageValue, MinHealth, MaxHealth);
            _changed.Invoke(_health);
        }
    }

    public void Heal()
    {
        if (_health > MinHealth)
        {
            _health = Mathf.Clamp(_health + _damageValue, MinHealth, MaxHealth);
            _changed.Invoke(_health);
        }
    }
}