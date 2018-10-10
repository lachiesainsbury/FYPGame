using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWindow : MonoBehaviour {

    [SerializeField]
    private GameObject joystick, actionButton;

    public void OpenWindow() {
        ToggleJoystickAndActionButton(false);
        this.gameObject.SetActive(true);
    }

    public void ExitWindow() {
        this.gameObject.SetActive(false);
        ToggleJoystickAndActionButton(true);
    }

    public void Navigate(GameObject destination) {
        this.gameObject.SetActive(false);

        destination.SetActive(true);
    }

    private void ToggleJoystickAndActionButton(bool toggle) {
        joystick.SetActive(toggle);
        actionButton.SetActive(toggle);

        if (!toggle) {
            joystick.GetComponent<FixedJoystick>().ResetJoystick();
        }
    }

    public bool IsActive() {
        return this.gameObject.activeSelf;
    }
}

