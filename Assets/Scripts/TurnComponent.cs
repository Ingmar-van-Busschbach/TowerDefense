using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnComponent : MonoBehaviour
{
    [SerializeField] private Quaternion rotationSpeed;

    private void Update()
    {
        float x = rotationSpeed.x * Time.deltaTime;
        float y = rotationSpeed.y * Time.deltaTime;
        float z = rotationSpeed.z * Time.deltaTime;
        var rotationResult = Quaternion.Euler(x, y, z);
        this.transform.rotation = this.transform.rotation * rotationResult;
    }
}
