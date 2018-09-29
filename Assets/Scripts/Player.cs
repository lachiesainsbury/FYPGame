using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private float speed;
    [SerializeField]
    private Joystick joystick;
    [SerializeField]
    private GameObject screenFader;
    [SerializeField]
    private GameObject dialogueBox;

    private Animator animator;
    private Rigidbody2D rigidbody;
    
    private bool isWalking = false;

    void Start () {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        isWalking = false;

        // Checks if screen fader is not currently active
        if (!screenFader.GetComponent<ScreenFader>().GetIsFading() && !dialogueBox.GetComponent<DialogueBox>().IsDialogueActive()) {
            GetKeyboardInput();

            GetJoystickInput();
        } else {
            rigidbody.velocity = Vector2.zero;
        }

        // Update animator with walking status
        animator.SetBool("isWalking", isWalking);
    }

    void GetKeyboardInput() {
        // Get user input
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        // If user is pressing at least one key, set isWalking and the animator values
        if ((Mathf.Abs(inputX) + Mathf.Abs(inputY)) > 0)
        {
            isWalking = true;

            animator.SetFloat("x", inputX);
            animator.SetFloat("y", inputY);
        }

        // Apply a velocity to the rigidbody based on the user input * speed
        rigidbody.velocity = new Vector2(inputX, inputY).normalized * speed;
    }

    void GetJoystickInput() {
        // Get user input
        Vector3 moveVector = (Vector3.right * joystick.Horizontal + Vector3.up * joystick.Vertical);

        // If user is moving, set isWalking and the animator values
        if (moveVector != Vector3.zero)
        {
            isWalking = true;

            animator.SetFloat("x", moveVector.x);
            animator.SetFloat("y", moveVector.y);
        }

        // Apply a velocity to the rigidbody based on the movement vector * speed
        rigidbody.velocity = moveVector * speed;
    }
}
