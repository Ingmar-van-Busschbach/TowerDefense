using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _health = 10.0f;
    [SerializeField] private Image _healthBarCore;
    [SerializeField] private Gradient damagedGradient;
    private int _targetHealth;
    private int _startHealth;
    void Start()
    {
        _targetHealth = (int)_health;
        _startHealth = (int)_health;
        GameEvents.current.onDealPlayerDamage += DealDamage;
    }

    private void DealDamage(int damage)
    {
        _targetHealth -= damage;
        if (_targetHealth <= 0)
        {
            OnDeath();
        }
        else
        {
            OnDamaged(damage);
        }
    }

    private void OnDamaged(int damage)
    {
        //Debug.Log("Player Takes " + damage + " Damage");
        //Debug.Log("Player Has " + _targetHealth + " Health Left");
        StartCoroutine(AnimateDamage());
    }
    private void OnDeath()
    {
        StartCoroutine(AnimateDamage());
        GameEvents.current.PlayerGameOver();
    }

    IEnumerator AnimateDamage()
    {
        var currentHealth = _health;
        Debug.Log(currentHealth);
        Debug.Log(_targetHealth);
        var t = 0.0f;
        while (_health != _targetHealth)
        {
            _health = Mathf.Lerp(currentHealth, _targetHealth, t);
            Debug.Log(_health);
            var healthBarTransform = _healthBarCore.transform as RectTransform;
            healthBarTransform.sizeDelta = new Vector2(_health*100/_startHealth, healthBarTransform.sizeDelta.y);
            _healthBarCore.color = damagedGradient.Evaluate(t);
            t += 0.25f;
            yield return new WaitForSeconds(0.2f);
        }
    }
}
