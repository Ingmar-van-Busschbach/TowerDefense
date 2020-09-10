using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    CharacterController characterController;
    Rigidbody rigidBody;

    [SerializeField] private float speed = 6.0f;
    [SerializeField] private float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;
    private Quaternion rotation;
    private float currentRotation;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (characterController.isGrounded || true)
        {
            // We are grounded, so recalculate
            // move direction directly from axes

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            Vector3.Normalize(moveDirection);
            moveDirection *= speed;

            // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
            // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
            // as an acceleration (ms^-2)
            moveDirection.y -= gravity * Time.deltaTime;

            currentRotation += Input.GetAxis("Rotate");
            rotation = Quaternion.Euler(0.0f, currentRotation, 0.0f);
            //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 1);
            transform.rotation = Quaternion.Euler(0.0f, currentRotation, 0.0f);
            moveDirection = transform.rotation * moveDirection;
            // Move the controller
            var worldMove = transform.TransformDirection(moveDirection);
            characterController.Move(moveDirection * Time.deltaTime);
        }
    }
}
