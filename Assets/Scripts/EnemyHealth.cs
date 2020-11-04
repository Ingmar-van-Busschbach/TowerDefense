using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] internal int _health;
    private MeshRenderer _renderComponent;
    [SerializeField] private Color[] _healthColor;
    private Material newMaterial;

    void Start()
    {
        _healthColor = new Color[21] { Color.black, Color.red, Color.blue, Color.green, Color.white, Color.cyan, Color.black, Color.cyan, Color.black, Color.cyan, Color.black, Color.cyan, Color.black, Color.cyan, Color.black, Color.cyan, Color.black, Color.cyan, Color.black, Color.cyan, Color.black };
        _renderComponent = this.GetComponent<MeshRenderer>();
        newMaterial = Material.Instantiate(_renderComponent.material);
        _renderComponent.material = newMaterial;
        _renderComponent.material.color = _healthColor[_health];
        GameEvents.current.onDealEnemyDamage += DealDamage;
    }

    internal void DealDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
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
        _renderComponent.material = newMaterial;
        _renderComponent.material.color = _healthColor[_health];
    }
    private void OnDeath()
    {
        GameEvents.current.AddPlayerScore(1);
        Destroy(this.gameObject);
    }
}
