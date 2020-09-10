using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int _damage;
    public int _fireDelay;
    public int _currentDelay = 0;
    public Camera camReference;
    public GameObject _projectile;
    public GameObject player;
    private Vector3 direction;
    public float velocity = 50.0f;

    public virtual void TriggerDown()
    {

    }

    public virtual void TriggerHold()
    {

    }

    public virtual void TriggerUp()
    {

    }

    public virtual void Shoot()
    {
        RaycastHit hit;
        Ray ray = camReference.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 fromPosition = player.transform.position;
            Vector3 toPosition = new Vector3(hit.point.x, player.transform.position.y, hit.point.z);
            direction = toPosition - fromPosition;
            direction.Normalize();
            Vector3 spawn = fromPosition + (direction);

            GameObject projectile = Instantiate(_projectile, new Vector3(spawn.x, spawn.y, spawn.z), Quaternion.identity);
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.velocity = direction * velocity;
        }
    }
}
