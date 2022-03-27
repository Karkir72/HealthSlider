using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class HealthBar : MonoBehaviour
{
    [SerializeField] float _changeSpeed;

    private IEnumerator _corutine;
    private Slider _slider;

    private void Start()
    {
        _slider = GetComponent<Slider>();
    }

    public void ChangeValue(float newHealth)
    {
        if (_corutine != null)
            StopCoroutine(_corutine);

        _corutine = ChangeHealthBar(newHealth);
        StartCoroutine(_corutine);
    }

    private IEnumerator ChangeHealthBar(float newHealth)
    {
        float maxHealth = 100f;
        float endValue = newHealth / maxHealth;

        while (_slider.value != endValue)
        {
            int speedDivider = 1000;
            _slider.value = Mathf.MoveTowards(_slider.value, endValue, _changeSpeed / speedDivider);

            yield return null;
        }
    }
}