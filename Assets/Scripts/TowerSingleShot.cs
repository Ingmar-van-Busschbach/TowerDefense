using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSingleShot : Tower
{
    [SerializeField] private float _fireDelay = 1.0f;
    [SerializeField] private int _damage = 1;
    private GameObject _child;
    private GameObject _target;
    private bool _isShooting = false;
    Quaternion offsetRotation = Quaternion.Euler(0, -90, 0);

    private void Start()
    {
        _child = this.transform.GetChild(0).gameObject;
    }

    protected override bool CanAttack()
    {
        _target = _rangeChecker.GetFirstEnemyInRange();
        return _target != null;
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
        while (_target != null)
        {
            var enemyHealth = _target.GetComponent<EnemyHealth>();
            Vector3 relativePos = _target.transform.position - _child.transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
            rotation = rotation * offsetRotation;
            _child.transform.rotation = rotation;
            enemyHealth.DealDamage(_damage);
            yield return new WaitForSeconds(_fireDelay);
        }
        _isShooting = false;
    }
}
