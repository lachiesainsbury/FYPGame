using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWindow : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ExitWindow() {
        gameObject.SetActive(false);
    }

    public void ToggleWindow() {
        gameObject.SetActive(!gameObject.activeSelf);
    }

    public void Navigate(GameObject destination) {
        ExitWindow();

        destination.SetActive(true);
    }
}
