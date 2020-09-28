using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRangeCheck : MonoBehaviour
{
    [SerializeField] internal float _range = 1.0f;
    [SerializeField] private LayerMask _layer;
    private void Update()
    {
        
    }

    public GameObject GetFirstEnemyInRange()
    {
        Collider[] hitCollider = Physics.OverlapSphere(this.transform.position, _range, _layer);
        if(hitCollider.Length > 0)
        {
            return hitCollider[0].gameObject;
        }
        return null;
    }

    public GameObject[] GetAllEnemiesInRange()
    {
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, _range, _layer);
        GameObject[] targets = new GameObject[hitColliders.Length];
        for (int i = 0; i < hitColliders.Length; i++)
        {
            targets[i] = hitColliders[i].gameObject;
        }
        return targets;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(this.transform.position, _range);
    }

    void CheckRange(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        foreach (var hitCollider in hitColliders)
        {
            Debug.Log(hitCollider.gameObject);
        }
    }
}
