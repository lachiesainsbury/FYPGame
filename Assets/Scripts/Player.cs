using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private float speed;
    [SerializeField]
    private Joystick joystick;


    private Animator animator;
    private Rigidbody2D rigidbody;


    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        bool isWalking = false;

        // Get user input
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        // If user is pressing at least one key, set isWalking and the animator values
        if ((Mathf.Abs(inputX) + Mathf.Abs(inputY)) > 0) {
            isWalking = true;

            animator.SetFloat("x", inputX);
            animator.SetFloat("y", inputY);

            
        }

        //
        Vector3 moveVector = (Vector3.right * joystick.Horizontal + Vector3.up * joystick.Vertical);

        if (moveVector != Vector3.zero) {
            isWalking = true;

            animator.SetFloat("x", moveVector.x);
            animator.SetFloat("y", moveVector.y);
        }
        //

        animator.SetBool("isWalking", isWalking);

        // Apply a velocity to the rigidbody based on the user input * speed
        rigidbody.velocity = new Vector2(inputX, inputY).normalized * speed;

        //
        //transform.rotation = Quaternion.LookRotation(Vector3.forward, moveVector);
        //transform.Translate(moveVector * speed * Time.deltaTime, Space.World);

        rigidbody.velocity = moveVector * speed;
        //
    }
}
