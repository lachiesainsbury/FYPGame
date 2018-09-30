using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBox : MonoBehaviour {

    [SerializeField]
    private GameObject joystick;
    [SerializeField]
    private GameObject actionButton;

    private bool dialogueActive;

	// Use this for initialization
	void Start () {

    }

    void Update() {
        if (dialogueActive && Input.GetKeyDown(KeyCode.Space)) {
            EndDialogue();
        }
    }

    public void StartDialogue() {
        joystick.SetActive(false);
        actionButton.SetActive(false);
        joystick.GetComponent<FixedJoystick>().ResetJoystick();

        this.gameObject.SetActive(true);
        dialogueActive = true;
    }

    public void EndDialogue() {
        this.gameObject.SetActive(false);
        dialogueActive = false;

        joystick.SetActive(true);
        actionButton.SetActive(true);
    }

    public bool IsDialogueActive() {
        return dialogueActive;
    }
}
