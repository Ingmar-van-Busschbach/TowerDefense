using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMultishot : Tower
{
    [SerializeField] private float _fireDelay = 1.0f;
    [SerializeField] private int _damage = 1;
    [SerializeField] private int _maxTargets = 10;
    private GameObject[] _targets;
    private bool _isShooting = false;

    protected override bool CanAttack()
    {
        _targets = _rangeChecker.GetAllEnemiesInRange();
        return _targets.Length > 0;
    }

    protected override void Attack()
    {
        if (_isShooting == false)
        {
            _isShooting = true;
            StartCoroutine(Shoot());
        }
    }
    IEnumerator Shoot()
    {
        while (_targets != null)
        {
            int _length = Mathf.Min(_maxTargets, _targets.Length);
            for (int i = 0; i < _length; i++)
            {
                var enemyHealth = _targets[i].GetComponent<EnemyHealth>();
                enemyHealth.DealDamage(_damage);
            }
            yield return new WaitForSeconds(_fireDelay);
        }
        _isShooting = false;
    }
}
