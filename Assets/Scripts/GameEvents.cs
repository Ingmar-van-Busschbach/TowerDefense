using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake()
    {
        current = this;
    }

    public event Action<int> onDealPlayerDamage;
    public void DealPlayerDamage(int damage = 0)
    {
        if (onDealPlayerDamage != null)
        {
            onDealPlayerDamage(damage);
        }
    }
    public event Action<int> onDealEnemyDamage;
    public void DealEnemyDamage(int damage = 0)
    {
        if (onDealEnemyDamage != null)
        {
            onDealEnemyDamage(damage);
        }
    }
}
