using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    private const int numberOfInventorySlots = 6;
    private GameObject[] inventorySlots;

    [SerializeField]
    private GameObject inventorySlotPrefab;

    [SerializeField]
    private Transform inventorySlotsGroup;

    // Use this for initialization
    void Start () {
        inventorySlots = new GameObject[numberOfInventorySlots];

        for (int i=0; i < numberOfInventorySlots; i++) {
            GameObject newInventorySlot = Instantiate(inventorySlotPrefab);
            newInventorySlot.transform.SetParent(inventorySlotsGroup);

            inventorySlots[i] = newInventorySlot;
        }
	}

    public void ToggleWindow() {
        gameObject.SetActive(!gameObject.activeSelf);
    }

    public void AddFood(Food food) {
        foreach (GameObject slot in inventorySlots) {
            InventorySlot inventorySlot = slot.GetComponent<InventorySlot>();

            if (inventorySlot.GetFood() == null) {
                inventorySlot.AddFood(food);
                return;
            }
        }

        Debug.Log("Inventory is full.");
    }
}
