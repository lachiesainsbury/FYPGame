using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITrigger : MonoBehaviour {

    [SerializeField]
    private GameObject UIElement;

    private ActionButton actionButton;

    private bool playerWithinZone, windowOpen;

	// Use this for initialization
	void Start () {
        actionButton = GameObject.FindGameObjectWithTag("ActionButton").GetComponent<ActionButton>();
	}
	
	// Update is called once per frame
	void Update () {
        if (playerWithinZone && !windowOpen && actionButton.GetClicked()) {
            windowOpen = true;
            UIElement.GetComponent<UIWindow>().OpenWindow();
        }
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        playerWithinZone = true;
    }

    private void OnTriggerExit2D(Collider2D collision) {
        playerWithinZone = false;
        windowOpen = false;
    }
}
