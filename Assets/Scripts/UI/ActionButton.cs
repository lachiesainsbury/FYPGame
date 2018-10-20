using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionButton : MonoBehaviour {

    private bool clicked = false;
	
	// Update is called once per frame
	void LateUpdate () {
        clicked = false;
    }

    public void Click() {
        clicked = true;
    }

    public bool GetClicked() {
        if (clicked) {
            clicked = false;
            return true;
        } else {
            return false;
        }
    }
}
