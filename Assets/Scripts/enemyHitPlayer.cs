using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHitPlayer : MonoBehaviour
{
    private PlayerHealth _playerHealth;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            _playerHealth.DealDamage(10);
            Destroy(this.gameObject);
        }
    }
}
