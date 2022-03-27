using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class HealthBar : MonoBehaviour
{
    private Slider _slider;

    private void Start()
    {
        _slider = GetComponent<Slider>();
    }

    public void ShowNewHealth(float newHealth)
    {
        StartCoroutine(ChangeHealthBar(newHealth));
    }

    private IEnumerator ChangeHealthBar(float newHealth)
    {
        float maxHealth = 100f;
        float currentValue = _slider.value;
        float endValue = newHealth / maxHealth;

        while (currentValue != endValue)
        {
            float maxChanges = 0.001f;
            currentValue = Mathf.MoveTowards(currentValue, endValue, maxChanges);
            _slider.value = currentValue;

            yield return null;
        }
    }
}
