using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionButton : MonoBehaviour {

    private bool clicked = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
        clicked = false;
    }

    public void Click() {
        clicked = true;
    }

    public bool GetClicked() {
        return clicked;
    }
}
