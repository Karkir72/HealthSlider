using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class HealthBar : MonoBehaviour
{
    [SerializeField] float _changeSpeed;

    private Coroutine _corutine;
    private Slider _slider;

    private void Start()
    {
        _slider = GetComponent<Slider>();
    }

    public void ChangeValue(float newHealth)
    {
        if (_corutine != null)
            StopCoroutine(_corutine);

        _corutine = StartCoroutine(Change(newHealth));
    }

    private IEnumerator Change(float newHealth)
    {
        float maxHealth = 100f;
        float endValue = newHealth / maxHealth;

        while (_slider.value != endValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, endValue, _changeSpeed);

            yield return null;
        }
    }
}