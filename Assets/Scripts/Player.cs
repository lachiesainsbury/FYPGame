using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    /* MOVEMENT */
    [SerializeField]
    private float speed;
    [SerializeField]
    private Joystick joystick;

    private Animator animator;
    private new Rigidbody2D rigidbody;
    private ScreenFader screenFader;
    
    private bool isWalking = false;

    /* QUESTS */
    private Quest activeQuest;

    void Start () {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        screenFader = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();
    }
	
	void Update () {
        isWalking = false;

        // Checks if screen fader is not currently active
        if (!screenFader.GetIsFading() && !AreUIWindowsActive()) {
            GetJoystickInput();
        } else {
            rigidbody.velocity = Vector2.zero;
        }

        // Update animator with walking status
        animator.SetBool("isWalking", isWalking);
    }

    private void GetJoystickInput() {
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

    private bool AreUIWindowsActive() {
        if (GameObject.FindObjectsOfType<UIWindow>().Length > 0) {
            return true;
        } else {
            return false;
        }
    }

    public Vector3Int GetPlayerDirection() {
        float x = animator.GetFloat("x");
        float y = animator.GetFloat("y");

        if (Mathf.Abs(x) >= Mathf.Abs(y)) {
            if (x > 0) {
                return Vector3Int.right;
            } else {
                return Vector3Int.left;
            }
        } else {
            if (y > 0) {
                return Vector3Int.up;
            } else {
                return Vector3Int.down;
            }
        }
    }

    public bool HasQuest() {
        if (activeQuest == null) {
            return false;
        } else {
            return true;
        }
    }

    public void AddNewQuest(Quest quest) {
        if (!HasQuest()) {
            activeQuest = quest;
        } else {
            Debug.Log("Player already has a quest.");
        }
    }
}
