using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {

    [SerializeField]
    private Image icon;

    private Item item;

	// Use this for initialization
	void Start () {
        AddItem(new Carrot());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddItem(Item newItem) {
        item = newItem;
        updateIcon();
    }

    public void ClearSlot() {
        item = null;
        //updateIcon();
    }

    private void updateIcon() {
        if (item.GetIcon() == null) {
            Debug.Log("Items icon is null");
        }
    }
}
