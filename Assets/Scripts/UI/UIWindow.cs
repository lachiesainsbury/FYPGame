using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWindow : MonoBehaviour {

    private bool windowActive = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ExitWindow() {
        gameObject.SetActive(false);
        windowActive = false;
    }

    public void ToggleWindow() {
        gameObject.SetActive(!gameObject.activeSelf);
        windowActive = true;
    }

    public void Navigate(GameObject destination) {
        ExitWindow();

        destination.SetActive(true);
    }

    public bool IsWindowActive() {
        return windowActive;
    }
}
