using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {

    [SerializeField]
    private Image icon;

    private Food item;

    public void AddItem(Food newItem) {
        item = newItem;
        UpdateIcon();
    }

    public void ClearSlot() {
        // Remove the current item and icon, and reset the alpha to 0
        item = null;
        icon.sprite = null;
        
        Color minAlpha = icon.color;
        minAlpha.a = 0f;
        icon.color = minAlpha;
    }

    private void UpdateIcon() {
        // If item has a sprite, set that sprite to the icon and maximise the alpha.
        icon.sprite = Resources.Load<Sprite>("Foods/" + item.seedIcon);

        Color maxAlpha = icon.color;
        maxAlpha.a = 1f;
        icon.color = maxAlpha;
    }

    public Food GetItem() {
        return item;
    }

    public bool HasItem() {
        if (item != null) {
            return true;
        } else {
            return false;
        }
    }
}
