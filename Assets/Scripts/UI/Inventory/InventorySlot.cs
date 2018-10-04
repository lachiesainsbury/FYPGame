using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {

    [SerializeField]
    private Image icon;

    /*
    private Item item;

	// Use this for initialization
	void Start () {
        AddItem(new Carrot());
    }

    public void AddItem(Item newItem) {
        item = newItem;
        updateIcon();
    }

    public void ClearSlot() {
        // Remove the current item and icon, and reset the alpha to 0.
        item = null;
        icon.sprite = null;
        icon.color += new Color(0, 0, 0, -255);
    }

    private void updateIcon() {
        // If item has a sprite, set that sprite to the icon and maximise the alpha.
        if (item.GetIcon() != null) {
            icon.sprite = item.GetIcon();
            icon.color += new Color(0, 0, 0, 255);
        }
    }*/
}
