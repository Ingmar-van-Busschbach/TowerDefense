using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    [SerializeField] private float velocity = 50.0f;
    [SerializeField] private Camera camReference;
    [SerializeField] private GameObject _projectile;
    [SerializeField] private GameObject player;
    private Vector3 direction;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")|| Input.GetKeyDown("mouse 0"))
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
}
