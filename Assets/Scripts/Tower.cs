using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    protected TowerRangeCheck _rangeChecker;

    private void Awake()
    {
        _rangeChecker = GetComponent<TowerRangeCheck>();
    }

    void Update()
    {
        if (CanAttack())
        {
            Attack();
        }
    }

    protected virtual bool CanAttack()
    {
        return false;
    }

    protected virtual void Attack()
    {

    }
}