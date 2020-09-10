using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public Camera camReference;
    private bool _hasCast;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_hasCast == false)
        {
            _hasCast = true;
            RaycastHit hit;
            Ray ray = camReference.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Transform objectHit = hit.transform;
                Vector3 hitVector = hit.point;
                Debug.DrawRay(Input.mousePosition, hitVector, Color.white, 2.5f);
                // Do something with the object that was hit by the raycast.
            }
        }
    }
}
