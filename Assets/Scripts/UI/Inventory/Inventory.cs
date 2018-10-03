using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    [SerializeField]
    private InventorySlot[] inventorySlots = new InventorySlot[1];

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ToggleWindow() {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
