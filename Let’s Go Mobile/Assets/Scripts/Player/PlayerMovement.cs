using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private CharacterController controller;
    private Vector3 moveVector;

    public static float speed = 20.0f;
    private float verticalVelocity = 0.0f;
    private float gravity = 12.0f;

	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        moveVector = Vector3.zero;

        if (controller.isGrounded)
        {
            verticalVelocity = -0.5f;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        // X - Left and Right
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
        // Y - Up and Down

        // Z - Forward and Backward
        moveVector.z = speed;

        controller.Move(moveVector * Time.deltaTime);
	}
}
