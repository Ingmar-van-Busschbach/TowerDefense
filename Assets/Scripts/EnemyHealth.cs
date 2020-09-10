using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : HealthSystem
{
    public override void OnDeath()
    {
        Destroy(this.gameObject);
    }
}
