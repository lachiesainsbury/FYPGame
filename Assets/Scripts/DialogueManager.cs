using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour {

    [SerializeField]
    private GameObject dialogueBox;

    private bool dialogueActive;

	// Use this for initialization
	void Start () {
        dialogueBox = GameObject.FindGameObjectWithTag("DialogueBox");
        EndDialogue();
    }

    void Update() {
        if (dialogueActive && Input.GetKeyDown(KeyCode.Space)) {
            EndDialogue();
        }
    }

    public void StartDialogue() {
        dialogueBox.SetActive(true);
        dialogueActive = true;
    }

    public void EndDialogue() {
        dialogueBox.SetActive(false);
        dialogueActive = false;
    }
}
