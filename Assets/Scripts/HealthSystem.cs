using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] public float health = 100;

    public void DealDamage(float damage)
    {
        health = health - damage;
        if (health <= 0)
        {
            OnDeath();
        }
        OnDamaged();
    }
    public virtual void OnDeath()
    {

    }
    public virtual void OnDamaged()
    {

    }
}
