using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

    private DialogueManager dialogueManager;

	// Use this for initialization
	void Start () {
        dialogueManager = FindObjectOfType<DialogueManager>();
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        dialogueManager.StartDialogue();
    }
}
