using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

    [SerializeField]
    private GameObject dialogueBox;

	// Use this for initialization
	void Start () {
        
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        dialogueBox.GetComponent<DialogueBox>().StartDialogue();
    }
}
