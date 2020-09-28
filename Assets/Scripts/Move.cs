using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    [SerializeField] private Path path;

    private Vector3 location;

    private Rigidbody rb;
    private int index;
    private int pathLength;
    private bool arrived = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        location = this.transform.position;
        pathLength = path.GetPathLength();
    }

    void FixedUpdate()
    {
        if (Vector3.Distance(this.transform.position, location) < 1 && arrived == false)
        {
            index++;
            /* if(path.GetCurrentWaypoint() != null)
            {
                //Debug.Log(path.GetCurrentWaypoint());
            }
            else
            {
                //Debug.Log("Start");
            }*/
            if (index <= pathLength)
            {
                location = path.GetNextWaypoint().Position;
            }
            else
            {
                //Debug.Log("Arrived");
                GameEvents.current.DealPlayerDamage(1);
                arrived = true;
            }
        }
        else if (index <= pathLength)
        {
            rb.MovePosition(this.transform.position + (location - this.transform.position) * speed / Vector3.Distance(this.transform.position, location) * Time.fixedDeltaTime);
        }
    }
}
