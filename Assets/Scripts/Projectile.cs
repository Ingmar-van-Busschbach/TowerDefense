using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private EnemyHealth _enemyHealth;
    [SerializeField] private int damage;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            _enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            _enemyHealth.DealDamage(damage);
        }
        Destroy(this.gameObject);
    }
}