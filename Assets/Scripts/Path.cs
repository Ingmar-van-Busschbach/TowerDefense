using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField] public Checkpoint[] checkpoints;
    private Checkpoint checkpoint;
    private int index = 0;

    public Checkpoint GetNextWaypoint()
    {
        checkpoint = checkpoints[index];
        index++;
        return checkpoint;
    }

    public Checkpoint GetCurrentWaypoint() { return checkpoint; }
    public int GetPathLength() { return checkpoints.Length; }
}
