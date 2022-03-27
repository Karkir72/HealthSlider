using UnityEngine.Events;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _changingValue;
    [SerializeField] private UnityEvent<float> _changed;

    public float MaxHealth { get; private set; } = 100f;
    public float MinHealth { get; private set; } = 0f;
    private float _health;

    private void Start()
    {
        _health = MaxHealth;
    }

    public void Damage()
    {
        if (_health > MinHealth)
        {            
            _health = Mathf.Clamp(_health - _changingValue, MinHealth, MaxHealth);
            _changed.Invoke(_health);
        }
    }

    public void Heal()
    {
        if (_health > MinHealth)
        {
            _health = Mathf.Clamp(_health + _changingValue, MinHealth, MaxHealth);
            _changed.Invoke(_health);
        }
    }
}