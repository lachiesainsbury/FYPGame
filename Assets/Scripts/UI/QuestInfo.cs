using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestInfo : MonoBehaviour {

    [SerializeField]
    private GameObject inventory;

    public void ToggleWindow() {
        if (inventory.activeInHierarchy) {
            inventory.SetActive(false);
        }

        gameObject.SetActive(!gameObject.activeSelf);
    }
}
